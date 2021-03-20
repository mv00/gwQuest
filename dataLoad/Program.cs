using gwQuest.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace dataLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = File.ReadAllText(@"C:\Users\Matte\Downloads\ns.html");
            var xml = new XmlDocument();
            xml.LoadXml(doc);

            XmlNodeList quests = xml.GetElementsByTagName("tr");

            List<Quest> questList = new List<Quest>();

            foreach(XmlNode quest in quests)
            {
                var innerXml = quest.InnerText;
                XmlNodeList questInfo = quest.ChildNodes;

                
               
                var name = questInfo[0].InnerText;
                var uri = new Uri(questInfo[0].FirstChild.Attributes["href"].Value);
                var primary = questInfo[1].InnerText == "Primary";

                var profession = questInfo[2]?.FirstChild?.FirstChild?.Value;
                var professionToAdd = profession.IsProfession() ? Profession.None : profession.GetProfession();

                var questItem = new Quest(name, uri, primary, professionToAdd, Campaign.Prophecies, Region.NorthernShiverpeaks, false);
                questList.Add(questItem);
            }

            var json = JsonConvert.SerializeObject(questList, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
