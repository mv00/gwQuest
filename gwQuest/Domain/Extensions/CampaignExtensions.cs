using System;
using System.Collections.Generic;
using System.Linq;

namespace gwQuest.Domain
{
    public static class CampaignExtensions
    {
        private static IEnumerable<string> propheciesRegions;
        private static IEnumerable<string> canthanRegions;
        private static IEnumerable<string> nfRegions;
        private static IEnumerable<string> eotnRegions;

        public static IEnumerable<string> GetRegions(this Campaign campaign)
        {
            var regions = Enum.GetValues(typeof(Region)).Cast<Region>();

            if (propheciesRegions == null)
            {
                propheciesRegions = regions.Where(reg => (int)reg < (int)Region.ShingJeaIsland)
                                           .Select(r => r.ToReadableString()).ToList();
            }
            if(canthanRegions == null)
            {
                canthanRegions = regions.Where(reg => (int)reg >= (int)Region.ShingJeaIsland && (int)reg <= (int) Region.TheJadeSea)
                                        .Select(r => r.ToReadableString()).ToList();
            }
            if (nfRegions == null)
            {
                nfRegions = regions.Where(reg => (int)reg >= (int)Region.Istan && (int)reg <= (int)Region.DomainOfAnguish)
                                   .Select(r => r.ToReadableString()).ToList();
            }
            if (eotnRegions == null)
            {
                eotnRegions = new List<string>();
            }

            return campaign switch
            {
                Campaign.Prophecies => propheciesRegions,
                Campaign.Cantha => canthanRegions,
                Campaign.Nightfall => nfRegions,
                Campaign.EyeOfTheNorth => eotnRegions,
                _ => throw new KeyNotFoundException(),
            };
        }

        public static Campaign ToCampaign(this string @object)
        {
            return (Campaign) Enum.Parse(typeof(Campaign), @object.Replace(" ", ""), ignoreCase: true);
        }

        public static IEnumerable<string> GetCampaigns()
        {
           return new string[] { Campaign.Prophecies.ToCapitalString(), 
                Campaign.Cantha.ToCapitalString(), 
                Campaign.Nightfall.ToCapitalString(),
                Campaign.EyeOfTheNorth.ToCapitalString() };
        }

        public static string ToCapitalString(this Campaign campaign)
        {
            return campaign switch
            {
                Campaign.Prophecies => "Prophecies",
                Campaign.Cantha => "Cantha",
                Campaign.Nightfall => "Nightfall",
                Campaign.EyeOfTheNorth => "Eye of the North",
                _ => throw new KeyNotFoundException(),
            };
        }
    }
}