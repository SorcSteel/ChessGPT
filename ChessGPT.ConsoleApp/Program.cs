using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // URL of the SignalR hub
        var hubUrl = "https://localhost:7230/chessgpthub";

        // Create a new connection to the hub
        var connection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .Build();

        // Subscribe to the "ReceiveMessage" event
        connection.On<string>("ReceiveMessage", (message) =>
        {
            Console.WriteLine($"Received message: {message}");
        });

        try
        {
            // Start the connection
            await connection.StartAsync();

            // Send a test message
            string testMessage = "This is a test message from the console app";
            await connection.SendAsync("SendMessage", testMessage);

            Console.WriteLine("Message sent successfully.");

            // Wait for user input to stop the application
            Console.ReadLine();

            // Stop the connection
            await connection.StopAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}