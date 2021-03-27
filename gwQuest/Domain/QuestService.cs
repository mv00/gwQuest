using gwQuest.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace gwQuest.Domain
{
    public interface IQuestService
    {
        void Update(Quest quest);
        IEnumerable<Quest> GetQuests(Campaign campaign, Region region);

        int CompletedQuests();
        int CompletedQuests(Region region);
        int CompletedQuests(Campaign campaign);

        int AvailableQuests();
        int AvailableQuests(Region region);
        int AvailableQuests(Campaign campaign);

        IEnumerable<Region> GetRegions(Campaign campaign);
    }

    public class QuestService : IQuestService
    {
        private readonly IQuestRepository _questRepository;

        public QuestService(IQuestRepository questRepository)
        {
            _questRepository = questRepository;
        }

        public int AvailableQuests()
        {
            return _questRepository.GetQuests().Count();
        }

        public int AvailableQuests(Region region)
        {
            return _questRepository.GetQuests(q => q.Region == region).Count();
        }

        public int AvailableQuests(Campaign campaign)
        {
            return _questRepository.GetQuests(q => q.Campaign == campaign).Count();
        }

        public int CompletedQuests()
        {
            return _questRepository.GetQuests(q => q.Completed == true).Count();
        }

        public int CompletedQuests(Region region)
        {
            return _questRepository.GetQuests(q => q.Completed == true && q.Region == region).Count();
        }

        public int CompletedQuests(Campaign campaign)
        {
            return _questRepository.GetQuests(q => q.Completed == true && q.Campaign == campaign).Count();
        }

        public IEnumerable<Quest> GetQuests(Campaign campaign, Region region)
        {
            return _questRepository.GetQuests().Where(q => q.Campaign == campaign && q.Region == region);
        }

        public IEnumerable<Region> GetRegions(Campaign campaign)
        {
            return campaign switch
            {
                Campaign.Prophecies => new HashSet<Region>() { Region.Ascalon, Region.NorthernShiverpeaks, Region.Kryta, Region.MaguumaJungle, Region.CrystalDesert, Region.SouthernShiverpeaks, Region.RingOfFireIslands },
                Campaign.Cantha => new HashSet<Region>() { Region.ShingJea },
                Campaign.Nightfall => new HashSet<Region>(),
                Campaign.EyeOfTheNorth => new HashSet<Region>(),
                _ => throw new ArgumentException($"Inavlid Campaign {campaign}"),
            };
        }

        public void Update(Quest quest)
        {
            _questRepository.Update(quest);
        }
    }
}
