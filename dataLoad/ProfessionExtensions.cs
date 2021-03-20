using gwQuest.Domain;

namespace dataLoad
{
    public static class ProfessionExtensions
    {
        public static bool IsProfession(this string @string)
        {

            if (string.IsNullOrEmpty(@string))
                return false;

            return @string == Profession.Elementalist.ToString()
                   || @string == Profession.Ranger.ToString()
                   || @string == Profession.Mesmer.ToString()
                   || @string == Profession.Monk.ToString()
                   || @string == Profession.Warrior.ToString()
                   || @string == Profession.Necromancer.ToString();
        }

        public static Profession GetProfession(this string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
                return Profession.None;

            if (@string.Equals(Profession.Elementalist.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                return Profession.Elementalist;

            if (@string.Equals(Profession.Ranger.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                return Profession.Ranger;

            if (@string.Equals(Profession.Mesmer.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                return Profession.Mesmer;

            if (@string.Equals(Profession.Monk.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                return Profession.Monk;

            if (@string.Equals(Profession.Warrior.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                return Profession.Warrior;

            if (@string.Equals(Profession.Necromancer.ToString(), System.StringComparison.InvariantCultureIgnoreCase))
                return Profession.Necromancer;

            return Profession.None;
        }
    }
}
