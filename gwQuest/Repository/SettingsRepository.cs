using gwQuest.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace gwQuest.Repository
{
    public interface ISettingsRepository
    {
        void Load();
        void Save(IEnumerable<Profession> professions);
        IEnumerable<Profession> GetProfessions();
    }

    public class SettingsRepository : ISettingsRepository
    {
        private readonly string _filePath;
        private IEnumerable<Profession> _professions;

        public SettingsRepository(string filePath)
        {
            if (filePath != null)
            {
                _filePath = filePath;
                Load();
            }
        }

        public IEnumerable<Profession> GetProfessions()
        {
            if (_professions == null)
                Load();

            return _professions;
        }

        public void Load()
        {
            try
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, _filePath)))
                {
                    using Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream("gwQuest.Repository.settings.json");
                    using StreamReader reader = new StreamReader(stream);
                    string result = reader.ReadToEnd();
                    _professions = JsonConvert.DeserializeObject<List<Profession>>(result);

                    return;
                }
            }
            catch (System.Exception e)
            {
                var message = $"Environment.CurrentDirectory: {Environment.CurrentDirectory}";
                throw new System.Exception(message);
            }

            string text = File.ReadAllText(_filePath);
            _professions = JsonConvert.DeserializeObject<List<Profession>>(text);
        }

        public void Save(IEnumerable<Profession> professions)
        {
            _professions = professions;

            string text = JsonConvert.SerializeObject(_professions, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }
    }
}
