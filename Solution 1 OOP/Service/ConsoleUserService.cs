using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solution_1_OOP.Service
{
    public class ConsoleUserService
    {
        public void ConsoleUserCommand()
        {
            string userCommand;

            while (true)
            {
                Console.WriteLine("\n\nWhat do you want to do with the list of participants? \n" +
                "Enter \"get page\" to view list page \n" +
                "Enter \"search\" to search by first name or last name \n" +
                "Enter \"stop\" to exit \n");

                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "get page":
                        Console.WriteLine("Enter page number");
                        GetPage(int.Parse(Console.ReadLine()));
                        break;

                    case "search":
                        Console.WriteLine("Enter part of the name");
                        SearchByList(Console.ReadLine());
                        break;

                    case "stop":
                        break;

                    default:
                        Console.WriteLine("Incorrect command");
                        break;

                }

                if (userCommand == "stop")
                    break;
            }

        }

        public void GetPage(int pageNumber)
        {
            Console.Clear();

            var participantService = new ParticipantService();

            var FinallyParticipantsListSortByDate = participantService.SortByDateTimeReg();

            int firstElementForPage = (pageNumber - 1) * 5;
            int lastElementForPage;

            if (FinallyParticipantsListSortByDate.Count() > firstElementForPage)
            {
                Console.WriteLine(ConsoleColumnOutput());

                if ((FinallyParticipantsListSortByDate.Count() - firstElementForPage) >= 5)
                    lastElementForPage = firstElementForPage + 5;
                else
                    lastElementForPage = FinallyParticipantsListSortByDate.Count();

                for (int i = firstElementForPage; i < lastElementForPage; i++)
                {
                    Console.WriteLine(ConsoleParticipantOutput(
                        FinallyParticipantsListSortByDate[i].FirstName
                        , FinallyParticipantsListSortByDate[i].LastName
                        , $"{FinallyParticipantsListSortByDate[i].DateTimeReg:g}"
                        , FinallyParticipantsListSortByDate[i].Provider));
                }
            }
        }

        public void SearchByList(string partOfName)
        {
            Console.Clear();

            var participantService = new ParticipantService();

            var FinallyParticipantsListSortByDate = participantService.SortByDateTimeReg();

            var selectedParticipants = from p in FinallyParticipantsListSortByDate
                                       where p.FirstName.Contains(partOfName) || p.LastName.Contains(partOfName)
                                       orderby p
                                       select p;

            if (selectedParticipants.Any())
            {
                ConsoleColumnOutput();

                foreach (var participant in selectedParticipants)
                    Console.WriteLine(ConsoleParticipantOutput(
                        participant.FirstName
                        , participant.LastName
                        , $"{participant.DateTimeReg:g}"
                        , participant.Provider));
            }
            else
                Console.WriteLine("No values");

        }

        public string ConsoleColumnOutput()
        {
            string stringForConsole = String.Format("| {0,-15} | {1,-15} | {2,-18} | {3,-18} |"
                                , "Имя"
                                , "Фамилия"
                                , "Дата регистрации"
                                , "Поставщик"); ;

            return stringForConsole;
        }

        public string ConsoleParticipantOutput(string column1, string column2, string column3, string column4)
        {
            string stringForConsole = String.Format("| {0,-15} | {1,-15} | {2,-18} | {3,-18} |"
                                , column1
                                , column2
                                , column3
                                , column4);

            return stringForConsole;
        }
    }
}
