using System;
using System.Collections.Generic;
using System.Linq;

namespace gwQuest.Domain
{
    public static class CampaignExtensions
    {
        private static IEnumerable<string> pRegions;

        public static IEnumerable<string> GetRegions(this Campaign campaign)
        {
            if(pRegions == null)
                pRegions = Enum.GetValues(typeof(Region)).Cast<Region>().Select(r => r.ToReadableString()).ToList();

            switch (campaign)
            {
                case Campaign.Prophecies:
                    return pRegions;
                case Campaign.Cantha:
                    throw new KeyNotFoundException();
                case Campaign.Nightfall:
                    throw new KeyNotFoundException();
                case Campaign.EyeOfTheNorth:
                    throw new KeyNotFoundException();
                default:
                    throw new KeyNotFoundException();
            }
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
            switch (campaign)
            {
                case Campaign.Prophecies:
                    return "Prophecies";
                case Campaign.Cantha:
                    return "Cantha";
                case Campaign.Nightfall:
                    return "Nightfall";
                case Campaign.EyeOfTheNorth:
                    return "Eye of the North";
                default:
                    throw new KeyNotFoundException();
            }
        }
    }
}