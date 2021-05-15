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
        static void Main()
        {
            var doc = File.ReadAllText(@"file.html");
            doc = doc.Replace("<br>", "");
            doc = doc.Replace("&nbsp;", "");
            doc = doc.Replace("height=\"19\">", "height=\"19\"/>");
            doc = doc.Replace("height=\"20\">", "height=\"20\"/>");

            var xml = new XmlDocument();
            xml.LoadXml(doc);

            XmlNode thead = xml.SelectSingleNode("table/thead");
            if (thead != null) thead.ParentNode.RemoveChild(thead);

            XmlNodeList quests = xml.GetElementsByTagName("tr");

            List<Quest> questList = new();

            foreach (XmlNode quest in quests)
            {
                XmlNodeList questInfo = quest.ChildNodes;

                var name = questInfo[0].InnerText;
                var uri = new Uri(questInfo[0].FirstChild.Attributes["href"].Value);
                var primary = questInfo[1].InnerText == "Primary";

                var profession = questInfo[2]?.FirstChild?.FirstChild?.Value;
                var professionToAdd = profession.IsProfession() ? Profession.None : profession.GetProfession();

                if (uri.ToString().EndsWith("_(Hard_mode)"))
                    name += " (Hard mode)";

                var questItem = new Quest(name, uri, primary, professionToAdd, Campaign.Beyond, Region.WindsOfChange, false);
                questList.Add(questItem);
            }

            #pragma warning disable IDE0059 // Unnecessary assignment of a value
            var json = JsonConvert.SerializeObject(questList, Newtonsoft.Json.Formatting.Indented);
            #pragma warning restore IDE0059 // Unnecessary assignment of a value
        }
    }
}
