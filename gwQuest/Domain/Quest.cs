﻿
using System;

namespace gwQuest.Domain
{
    public class Quest
    {
        public string Name { get; }
        public Uri Uri { get; }
        public bool Primary { get; }
        public Profession Profession { get; }
        public bool Completed { get; }

        public Quest(string name, Uri uri, bool primary, Profession profession, bool completed)
        {
            Name = name;
            Uri = uri;
            Primary = primary;
            Profession = profession;
            Completed = completed;
        }
    }
}
