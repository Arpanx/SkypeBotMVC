using Microsoft.AspNetCore.SignalR;
using SKYPE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKYPE.Controllers.hub
{
    public class ChatHub : Hub
    {
        private readonly IBotService _botService;

        public ChatHub(IBotService botService)
        {
            _botService = botService;
        }

        public async Task Send(string message, string userName)
        {
            await Clients.All.InvokeAsync("Send", message, userName);
            if (userName == "Bot") { 
              _botService.SendToSkype(message);
            }
        }

        public void SetSkypeLogin(string skypeLogin, string userName)
        {
            _botService.SetSkypeLogin(skypeLogin);
        }
    }
}
