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

                return;
            }
            else
            {
                string text = File.ReadAllText(_filePath);
                _quests = JsonConvert.DeserializeObject<HashSet<Quest>>(text);
            }

            if(_quests.All(q => q.Campaign == Campaign.Prophecies) && _quests.Count == 153)
            {
                using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("gwQuest.Repository.quests.json");
                using StreamReader reader = new(stream);
                string result = reader.ReadToEnd();
                HashSet<Quest> nonProphQuests = JsonConvert.DeserializeObject<HashSet<Quest>>(result)
                    .Where(q => q.Campaign != Campaign.Prophecies)
                    .ToHashSet();

                foreach(var quest in nonProphQuests)
                {
                    _quests.Add(quest);
                }
            }
        }

        private void Save()
        {
            var questsToSave = _quests.OrderBy(q => q.Campaign).ThenBy(q => q.Region).ThenBy(q => q.Name);
            string text = JsonConvert.SerializeObject(questsToSave, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }
    }
}
