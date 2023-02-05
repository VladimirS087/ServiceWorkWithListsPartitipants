using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Solution_1_OOP.Objects
{
    public class ParticipantXml : Participants
    {
        public static List<Participants> participantsXmlList = new List<Participants>();
        public static void ReadParticipantsToList(string path)
        {
            var cultureInfo = new CultureInfo("ru-Ru");

            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement element = xml.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                ParticipantXml participant = new ParticipantXml();

                foreach (XmlNode childNode in xnode.ChildNodes)
                {
                    if (childNode.Name == "Name")
                        participant.FirstName = childNode.InnerText;
                    if (childNode.Name == "Surname")
                        participant.LastName = childNode.InnerText;
                    if (childNode.Name == "RegisterDate")
                        participant.DateTimeReg = DateTime.Parse(childNode.InnerText, cultureInfo);

                }
                participant.Provider = "Provider 3 - Xml";
                participantsXmlList.Add(participant);
            }

        }

    }
}
