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
        private QuestList _questList;
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
            if (_questList.Quests == null)
                Load();

            return _questList.Quests.Where(filter ?? (p => true));
        }

        public void Update(Quest quest)
        {
            _questList.Quests.RemoveWhere(q => q.Name == quest.Name);
            _questList.Quests.Add(quest);

            Save();
        }

        private void Load()
        {
            string result;
            Stream stream;

            if (File.Exists(Path.Combine(Environment.CurrentDirectory, _filePath)))
                stream = new FileStream(_filePath, FileMode.Open);
            else
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("gwQuest.Repository.quests.json");

            using StreamReader reader = new(stream);
            result = reader.ReadToEnd();

            try
            {
                _questList = JsonConvert.DeserializeObject<QuestList>(result);
            }
            catch (JsonSerializationException)
            {
                var quests = JsonConvert.DeserializeObject<HashSet<Quest>>(result);
                _questList = new QuestList(new MetaData(new Version(1, 0, 0, 0)), quests);
            }

            _originalQuests = new HashSet<Quest>(_questList.Quests.Select(q => q.Clone()));
            stream.Dispose();

            if (_questList.IsUpgradeAvailable())
            {
                _questList = Versioning.Upgrade(_questList);
                Save();
            }
        }

        private void Save()
        {
            HashSet<Quest> sortedQuests = _questList.Quests.OrderBy(q => q.Campaign).ThenBy(q => q.Region).ThenBy(q => q.Name).ToHashSet();
            _questList = new QuestList(_questList.MetaData, sortedQuests);

            if (_questList.Quests.SequenceEqual(_originalQuests))
                return;

            string text = JsonConvert.SerializeObject(_questList, Formatting.Indented);
            File.WriteAllText(_filePath, text);
            _originalQuests = new HashSet<Quest>(_questList.Quests.Select(q => q.Clone()));
        }
    }
}
