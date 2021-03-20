using gwQuest.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace gwQuest.Repository
{
    public interface IQuestRepository
    {
        void Update(Quest quest);
        void Load();      
        void Save();
        IEnumerable<Quest> GetQuests();

    }
    public class QuestRepository : IQuestRepository
    {
        private string _filePath;
        private List<Quest> _quests;

        public QuestRepository(string filePath)
        {
            if (filePath != null)
            {
                _filePath = filePath;
                Load();
            }
        }

        public IEnumerable<Quest> GetQuests()
        {
            if (_quests == null)
                Load();

            return _quests;
        }

        public void Load()
        {
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, _filePath)))
            {
                using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("gwQuest.Repository.quests.json");
                using StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();
                _quests = JsonConvert.DeserializeObject<List<Quest>>(result);

                return;
            }

            string text = File.ReadAllText(_filePath);
            _quests = JsonConvert.DeserializeObject<List<Quest>>(text);
        }

        public void Save()
        {
            string text = JsonConvert.SerializeObject(_quests, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }

        public void Update(Quest quest)
        {
            _quests.Remove(_quests.Find(q => q.Name == quest.Name));
            _quests.Add(quest);

            Save();
        }
    }
}
