using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using Microsoft.AspNet.SignalR.Hubs;

namespace DamMonWebConsole.Hubs
{
    public class ChatHub : Hub
    {
        [HubMethodName("wyslijWiadomosci")]
        public void WyslijWiadomosci(string nazwa, string wiadomosc)
        {
            Clients.All.nadajWiadomosc(nazwa, wiadomosc);
        }
    }
}