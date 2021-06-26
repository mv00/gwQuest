using System;
using System.Collections.Generic;

namespace gwQuest.Domain
{
    public class QuestList
    {
        public MetaData MetaData { get; }
        public HashSet<Quest> Quests { get; }

        public QuestList(MetaData metaData, HashSet<Quest> quests)
        {
            MetaData = metaData;
            Quests = quests;
        }
    }

    public class MetaData
    {
        public Version Version { get; }

        public MetaData(Version version)
        {
            Version = version;
        }
    }
}
