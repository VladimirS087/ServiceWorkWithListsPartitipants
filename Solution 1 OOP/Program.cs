using Solution_1_OOP.Service;

internal class Program
{
    static void Main(string[] args)
    {
        ParticipantService participantService = new ParticipantService();

        ConsoleUserService userService = new ConsoleUserService();

        participantService.ReadAllParticipantsToList();

        participantService.DeleteDublicate();

        participantService.SortByDateTimeReg();

        userService.ConsoleUserCommand();

    }
}
