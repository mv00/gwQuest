using System;
using System.Collections.Generic;
using System.Linq;

namespace gwQuest.Domain
{
    public static class CampaignExtensions
    {
        private static IEnumerable<string> propheciesRegions;
        private static IEnumerable<string> canthanRegions;

        public static IEnumerable<string> GetRegions(this Campaign campaign)
        {
            if(propheciesRegions == null)
            {
                propheciesRegions = Enum.GetValues(typeof(Region))
                    .Cast<Region>()
                    .Where(reg => (int)reg < (int)Region.ShingJea)
                    .Select(r => r.ToReadableString()).ToList();
            }
            if(canthanRegions == null)
            {
                canthanRegions = Enum.GetValues(typeof(Region))
                    .Cast<Region>()
                    .Where(reg => (int)reg >= (int)Region.ShingJea)
                    .Select(r => r.ToReadableString()).ToList();
            }

            return campaign switch
            {
                Campaign.Prophecies => propheciesRegions,
                Campaign.Cantha => canthanRegions,
                Campaign.Nightfall => throw new KeyNotFoundException(),
                Campaign.EyeOfTheNorth => throw new KeyNotFoundException(),
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