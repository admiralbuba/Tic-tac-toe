using Core;
using Core.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_tac_toe.SignalrRHub
{
    public class SignalRHub
    {
        private static SignalRHub instance;
        public static SignalRHub Instance => instance ??= new SignalRHub();
        public HubConnection connection;
        public SignalRHub()
        {
            connection = new HubConnectionBuilder()
        .WithUrl("http://localhost:5000/gamestate", Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets)
        .Build();
            connection.StartAsync();
            connection.On<ButtonInfo>("ChangeButton", button => TicTacToe.Instance.MakeTurn(button.Id, button.Value, MainWindow.Instance, MainWindow.Instance));
        }
    }
}
