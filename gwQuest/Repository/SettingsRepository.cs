using gwQuest.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace gwQuest.Repository
{
    public interface ISettingsRepository
    {
        void Load();
        void Save(Settings settings);
        Settings GetSettings();
    }

    public class SettingsRepository : ISettingsRepository
    {
        private const string _filePath = "settings.json";
        private Settings _settings;

        public SettingsRepository()
        {
            Load();
        }

        public Settings GetSettings()
        {
            if (_settings == null)
                Load();

            return _settings;
        }

        public void Load()
        {
            try
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, _filePath)))
                {
                    _settings = new Settings { Campaign = Campaign.Prophecies, Region = Region.Ascalon, Professions = new Profession[] { 0, 0 } };
                    return;
                }
            }
            catch (Exception)
            {
                var message = $"Environment.CurrentDirectory: {Environment.CurrentDirectory}";
                throw new Exception(message);
            }

            string text = File.ReadAllText(_filePath);

            try
            {
                _settings = JsonConvert.DeserializeObject<Settings>(text);
            }

            catch(JsonSerializationException)
            {
                List<Profession> list = JsonConvert.DeserializeObject<List<Profession>>(text);
                _settings = new Settings { Campaign = Campaign.Prophecies, Region = Region.Ascalon, Professions = new Profession[] { list[0], list[1] } };
            }
        }

        public void Save(Settings settings)
        {
            _settings = settings;

            string text = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }
    }
}
