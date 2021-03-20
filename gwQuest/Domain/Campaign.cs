namespace gwQuest.Domain
{
    public class Campaign
    {
        public string Name { get; }

        public Campaign(string name)
        {
            Name = name;
        }

        public static Campaign Prophecies => new Campaign("Prophecies");
        public static Campaign Cantha => new Campaign("Cantha");
        public static Campaign Nightfall => new Campaign("Nightfall");
        public static Campaign EyeOfTheNorth => new Campaign("Eye of the North");

    }
}
