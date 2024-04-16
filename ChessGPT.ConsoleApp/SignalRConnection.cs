using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.ConsoleApp
{
    internal class SignalRConnection
    {
        private string hubAdress;
        HubConnection _connection;
        string user;

        public SignalRConnection(string hubAdress)
        {
            this.hubAdress = hubAdress;
        }
        public void Start()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubAdress)
                .Build();

            _connection.On<string, string>("ReceiveMessage", (s1, s2) => OnSend(s1, s2));

            _connection.StartAsync();
        }

        private void OnSend(string user, string message)
        {
            Console.WriteLine(user = ": " + message);
        }

        public void ConnectToChannel(string user)
        {
            Start();
            string message = user + " Connected";
            try
            {
                _connection.InvokeAsync("SendMessage", "System", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
