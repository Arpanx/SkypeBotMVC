using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SignalR;
using SKYPE.Services;

namespace SKYPE.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IBotService _botService;

        public MessagesController(
            IBotService botService)
        {
            _botService = botService;
        }

        [Authorize(Roles = "Bot")]
        [HttpPost]
        public async Task<OkResult> Post([FromBody] Activity activity)
        {
        if (activity.Type == ActivityTypes.Message)
            { 
                _botService.Send(activity);
            }

            return Ok();
        }
    }
}
