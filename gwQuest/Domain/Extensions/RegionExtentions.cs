using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace gwQuest.Domain
{
    public static class RegionExtentions
    {
        public static Region ToRegion(this string @object)
        {
            return (Region)Enum.Parse(typeof(Region), @object.Replace(" ", ""), ignoreCase: true);
        }

        public static string ToReadableString(this Region region)
        {
            var spaced = Regex.Replace(region.ToString(), "([a-z])([A-Z])", "$1 $2");
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            return ti.ToTitleCase(spaced);
        }
    }
}
