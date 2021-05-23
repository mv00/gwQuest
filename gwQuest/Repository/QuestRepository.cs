using gwQuest.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace gwQuest.Repository
{
    public interface IQuestRepository
    {
        void Update(Quest quest);
        IEnumerable<Quest> GetQuests(Func<Quest, bool> filter = null);
    }

    public class QuestRepository : IQuestRepository
    {
        private readonly string _filePath;
        private HashSet<Quest> _quests;
        private HashSet<Quest> _originalQuests;

        public QuestRepository(string filePath)
        {
            if (filePath != null)
            {
                _filePath = filePath;
                Load();
            }
        }

        public IEnumerable<Quest> GetQuests(Func<Quest, bool> filter = null)
        {
            if (_quests == null)
                Load();

            return _quests.Where(filter ?? (p => true));
        }

        public void Update(Quest quest)
        {
            _quests.RemoveWhere(q => q.Name == quest.Name);
            _quests.Add(quest);

            Save();
        }

        private void Load()
        {
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, _filePath)))
            {
                using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("gwQuest.Repository.quests.json");
                using StreamReader reader = new(stream);
                string result = reader.ReadToEnd();
                _quests = JsonConvert.DeserializeObject<HashSet<Quest>>(result);
                _originalQuests = new HashSet<Quest>(_quests.Select(q => q.Clone()));

                return;
            }
            else
            {
                string text = File.ReadAllText(_filePath);
                _quests = JsonConvert.DeserializeObject<HashSet<Quest>>(text);
                _originalQuests = new HashSet<Quest>(_quests.Select(q => q.Clone()));
            }           

            if (_quests.All(q => q.Campaign == Campaign.Prophecies) && _quests.Count == 153)
            {
                using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("gwQuest.Repository.quests.json");
                using StreamReader reader = new(stream);
                string result = reader.ReadToEnd();
                HashSet<Quest> nonProphQuests = JsonConvert.DeserializeObject<HashSet<Quest>>(result)
                    .Where(q => q.Campaign != Campaign.Prophecies)
                    .ToHashSet();

                foreach (var quest in nonProphQuests)
                {
                    _quests.Add(quest);
                }
            }

            if (!_quests.Any(q => q.Campaign == Campaign.Nightfall && q.Name == "Mysterious Message (Nightfall quest)"))
            {
                _quests.Add(
                    new Quest("Mysterious Message (Nightfall quest)",
                        new Uri("https://wiki.guildwars.com/wiki/Mysterious_Message_(Nightfall_quest)"),
                        true,
                        Profession.None,
                        Campaign.Nightfall,
                        Region.Kourna,
                        false));
            }

            var lastDay = _quests.Where(q => q.Name == "The Titan Source");
            if (lastDay.Count() == 2)
            {
                _quests.Remove(lastDay.First());
            }

            var lastDayHM = _quests.Where(q => q.Name == "The Titan Source (Hard mode)");
            if (lastDayHM.Count() == 2)
            {
                _quests.Remove(lastDayHM.First());
            }

            if (!_quests.Any(q => q.Name == "A Land of Heroes"))
            {
                _quests.Add(new Quest("A Land of Heroes",
                    new Uri("https://wiki.guildwars.com/wiki/A_Land_of_Heroes"),
                    true,
                    Profession.None,
                    Campaign.Nightfall,
                    Region.Istan,
                    false));
            }
            if (!_quests.Any(q => q.Name == "Battle Preparations"))
            {
                _quests.Add(new Quest("Battle Preparations",
                    new Uri("https://wiki.guildwars.com/wiki/Battle_Preparations"),
                    true,
                    Profession.None,
                    Campaign.Nightfall,
                    Region.Istan,
                    false));
            }
            if (!_quests.Any(q => q.Name == "Securing Champion's Dawn"))
            {
                _quests.Add(new Quest("Securing Champion's Dawn",
                    new Uri("https://wiki.guildwars.com/wiki/Securing_Champion%27s_Dawn"),
                    true,
                    Profession.None,
                    Campaign.Nightfall,
                    Region.Istan,
                    false));
            }

            var battleOfJahai = _quests.Where(q => q.Name == "The Battle of Jahai").FirstOrDefault();
            if (battleOfJahai != null)
            {
                _quests.Remove(battleOfJahai);
            }

            Save();
        }

        private void Save()
        {
            _quests = _quests.OrderBy(q => q.Campaign).ThenBy(q => q.Region).ThenBy(q => q.Name).ToHashSet();

            if (_quests.SequenceEqual(_originalQuests))
                return;

            string text = JsonConvert.SerializeObject(_quests, Formatting.Indented);
            File.WriteAllText(_filePath, text);
            _originalQuests = new HashSet<Quest>(_quests.Select(q => q.Clone()));
        }
    }
}
