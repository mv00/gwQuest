
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
        public bool Completed { get; set; }

        public Quest(string name, Uri uri, bool primary, Profession profession, Campaign campaign,bool completed)
        {
            Name = name;
            Uri = uri;
            Primary = primary;
            Profession = profession;
            Campaign = campaign;
            Completed = completed;
        }
    }
}
