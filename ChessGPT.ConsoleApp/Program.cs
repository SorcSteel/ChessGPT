using ChessGPT.ConsoleApp;

internal class Program
{

    private static string DrawMenu()
    {
        Console.WriteLine("Which operation do you wish to perform");
        Console.WriteLine("connect to a channel (c)");
        Console.WriteLine("send a message to the channel (s)");
        Console.WriteLine("exit (x)");

        string operation = Console.ReadLine();
        return operation;
    }
    private static void Main(string[] args)
    {
        string user = "Kaiden";
        string hubAddress = "https://localhost:7230/chessgpthub";

        string operation = DrawMenu();

        var signalRConnection = new SignalRConnection(hubAddress);

        while (operation != "x")
        {
            switch (operation)
            {
                case "x":
                    break;

                case "c":
                    signalRConnection.ConnectToChannel(user);
                    break;

                case "d":
                    break;
            }
            operation = DrawMenu();
        }
    }
}