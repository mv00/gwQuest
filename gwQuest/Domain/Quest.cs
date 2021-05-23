
using System;

namespace gwQuest.Domain
{
    public class Quest
    {
        public string Name { get; }
        public Uri Uri { get; }
        public bool Primary { get; }
        public Profession Profession { get; }
        public Campaign Campaign { get; }
        public Region Region { get; }
        public bool Completed { get; set; }

        public Quest(string name, Uri uri, bool primary, Profession profession, Campaign campaign, Region region, bool completed)
        {
            Name = name;
            Uri = uri;
            Primary = primary;
            Profession = profession;
            Campaign = campaign;
            Region = region;
            Completed = completed;
        }

        public Quest Clone()
        {
            return new Quest(Name, new Uri(Uri.ToString()), Primary, Profession, Campaign, Region, Completed);
        }
    }
}
