using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solution_1_OOP.Objects
{
    internal class ParticipantCsv : Participants

    {
        public static List<Participants> participantsCsvList = new List<Participants>();
        public static void ReadParticipantsToList(string path)
        {
            var cultureInfo = new CultureInfo("ru-Ru");

            using (TextFieldParser tfp = new TextFieldParser(path))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");

                while (!tfp.EndOfData)
                {
                    ParticipantCsv participant = new ParticipantCsv();

                    string[] fields = tfp.ReadFields();

                    participant.FirstName = fields[0];
                    participant.LastName = fields[1];
                    participant.DateTimeReg = DateTime.Parse(fields[2], cultureInfo);
                    participant.Provider = "Provider 1 - CSV";

                    participantsCsvList.Add(participant);
                }
            }
        }

    }
    
}
