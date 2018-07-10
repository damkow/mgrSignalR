using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using Microsoft.AspNet.SignalR.Hubs;
using DamMonWebConsole.Models;

namespace DamMonWebConsole.Hubs
{
    public class PomiaryHub : Hub
    {
        
        [HubMethodName("wyslijPomiary")]
        public static void WyslijPomiary()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PomiaryHub>();
            context.Clients.All.aktualizujPomiary();
        }
        [HubMethodName("wyslijPomiary")]
        public static void WyslijPomiary(Pomiar pomiar)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PomiaryHub>();
            context.Clients.All.aktualizujPomiary(pomiar);
        }
    }
}