using Solution_1_OOP.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1_OOP.Service
{
    public class ParticipantService
    {

        public List<Participants> ReadAllParticipantsToList()
        {
           var allParticipantsList = new List<Participants>();

            ParticipantCsv.ReadParticipantsToList(@"C:\Users\Admin\Desktop\Подготовка\Тестовое задание\participants.csv");

            ParticipantJson.ReadParticipantsToList(@"C:\Users\Admin\Desktop\Подготовка\Тестовое задание\participants.json");

            ParticipantXml.ReadParticipantsToList(@"C:\Users\Admin\Desktop\Подготовка\Тестовое задание\participants.xml");

            foreach (var item in ParticipantCsv.participantsCsvList)
                allParticipantsList.Add(item);

            foreach (var item in ParticipantJson.participantsJsonList)
                allParticipantsList.Add(item);

            foreach (var item in ParticipantXml.participantsXmlList)
                allParticipantsList.Add(item);

            return allParticipantsList;

        }

        public List<Participants> DeleteDublicate()
        {
            var allParticipantsList = ReadAllParticipantsToList();

            var allParticipantsListWithoutDublicate = new List<Participants>();

            //ищем совпадения по имени и фамилии, добавляем в новый список.
            //минимум один элемент в цикле добавится (когда сравнит с самим собой)
            List<Participants> listforsort = new List<Participants>();
            List<Participants> listforsortbydate = new List<Participants>();

            foreach (var item in allParticipantsList)
            {
                for (int i = 0; i < allParticipantsList.Count; i++)
                {
                    if ((item.FirstName == allParticipantsList[i].FirstName)
                        && (item.LastName == allParticipantsList[i].LastName))
                    {
                        listforsort.Add(allParticipantsList[i]);
                    }
                }
                //    //сортируем по дате, чтобы выбрать самого раннего 
                listforsortbydate = listforsort.OrderBy(l => l.DateTimeReg).ToList();

                //    //проверяем, нет ли уже такого в итоговом списке, тогда добавляем
                if (!(allParticipantsListWithoutDublicate.Contains(listforsortbydate[0])))
                    allParticipantsListWithoutDublicate.Add(listforsortbydate[0]);

                listforsort.Clear();
                listforsortbydate.Clear();

                //понял, что все вышеизложенное можно заменить этим кодом, но не успел разобраться в синтаксисе
                //allParticipantsListWithoutDublicate = ReadAllParticipantsToList().GroupBy(p => new
                // (p.FirstName, p.LastName)).
                //    Select(g => g.OrderBy(p => p.DateTimeReg));
            }
            return allParticipantsListWithoutDublicate;
        }

        public List<Participants> SortByDateTimeReg()
        {

           var FinallyParticipantsListSortByDate = DeleteDublicate().OrderBy(s => s.DateTimeReg).ToList();
            return FinallyParticipantsListSortByDate;

        }

    }
}
