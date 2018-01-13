using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;
using SKYPE.Controllers.hub;

namespace SKYPE.Controllers
{
    public class CustomWebAPIController : Controller
    {
        private readonly IConfiguration configuration;
        public CustomWebAPIController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("api/show")]
        public async Task<HttpResponseMessage> Show()
        {   var botAccount = new ChannelAccount("28:505b3669-e6be-49cd-8877-60c5525a2ccc", "Arpanx4");
            var userAccount = new ChannelAccount(name: "Писецкий Александр Васильевич", id: "29:1GBGRMNxxLAbYtO89zx0K2eGD9CeqmuhD6EJaGUZvbaI");
            var connector1 = new ConnectorClient(new System.Uri("https://smba.trafficmanager.net/apis/"), "505b3669-e6be-49cd-8877-60c5525a2ccc", "arkEW72 +| oqpiHWJOG005 *{");
            var conversationId = await connector1.Conversations.CreateDirectConversationAsync(botAccount, userAccount);

            IMessageActivity message = Activity.CreateMessageActivity();
            message.From = botAccount;
            message.Recipient = userAccount;
            message.Conversation = new ConversationAccount(id: conversationId.Id, isGroup: false);
            message.Text = "Hi there";
            message.Locale = "en-Us";
            await connector1.Conversations.SendToConversationAsync((Activity)message);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }
    }
}
