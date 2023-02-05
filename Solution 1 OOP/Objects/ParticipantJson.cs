using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solution_1_OOP.Objects
{
    public class ParticipantJson : Participants
    {
        public static List<Participants> participantsJsonList = new List<Participants>();
        public static void ReadParticipantsToList(string path)
        {
            var cultureInfo = new CultureInfo("ru-Ru");

            string json = File.ReadAllText(path);

            participantsJsonList = JsonConvert.DeserializeObject<List<Participants>>(json);

            participantsJsonList.ForEach(x => x.Provider = "Provider 2 - Json");

        }
    }
}

