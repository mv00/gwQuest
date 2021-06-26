using gwQuest.Domain;
using System;
using System.Linq;

namespace gwQuest.Repository
{
    public static class Versioning
    {
        private static readonly Version LatestVersion = new(2, 0, 0, 0);

        public static bool IsUpgradeAvailable(this QuestList questList) => questList.MetaData.Version < LatestVersion;

        public static QuestList Upgrade(QuestList questList)
        {
            if (!questList.IsUpgradeAvailable())
                return questList;

            if(questList.MetaData.Version == new Version(1, 0, 0, 0))
            {
                questList = UpgradeVersion1ToVersion2(questList);
            }

            return questList;
        }

        public static QuestList UpgradeVersion1ToVersion2(QuestList questList)
        {
            if (questList.MetaData.Version != new Version(1, 0, 0, 0))
                return questList;

            //Add missing The Jade Quarry (kurzick)
            bool hasKurzickSideQuest = questList.Quests.Any(q => q.Name.Equals("The Jade Quarry") && q.Region == Region.EchovaldForest);
            if (!hasKurzickSideQuest)
            {
                questList.Quests.Add(
                    new Quest(
                        "The Jade Quarry",
                        new Uri("https://wiki.guildwars.com/wiki/The_Jade_Quarry_(Kurzick_quest)"),
                        true,
                        Profession.None,
                        Campaign.Cantha,
                        Region.EchovaldForest,
                        false));
            }

            //Add missing Scorched Earth
            bool hasNfScourchedEarth = questList.Quests.Any(q => q.Name.Equals("Scorched Earth") && q.Region == Region.Vabbi);
            if (!hasNfScourchedEarth)
            {
                questList.Quests.Add(
                    new Quest(
                        "Scorched Earth",
                        new Uri("https://wiki.guildwars.com/wiki/Scorched_Earth_(Nightfall_quest)"),
                        false,
                        Profession.None,
                        Campaign.Nightfall,
                        Region.Vabbi,
                        false));
            }

            //Set Primary on Jade Sea quests
            var jadeSeaPrimaryQuests = questList.Quests.Where(q => q.Name.Equals("Befriending the Luxons")
                                                                || q.Name.Equals("City Under Attack")
                                                                || q.Name.Equals("Fort Aspenwood")
                                                                || q.Name.Equals("Journey to the Whirlpool")
                                                                || q.Name.Equals("Stolen Eggs")
                                                                || q.Name.Equals("Taking Back the Palace")
                                                                || q.Name.Equals("The Jade Quarry")).ToList();
            
            questList.Quests.RemoveWhere(q => jadeSeaPrimaryQuests.Contains(q));
            jadeSeaPrimaryQuests.ForEach(q => questList.Quests.Add(new Quest(q.Name, q.Uri, true, q.Profession, q.Campaign, q.Region, q.Completed)));

            return new QuestList(new MetaData(new Version(2, 0, 0, 0)), questList.Quests);
        }
    }
}
