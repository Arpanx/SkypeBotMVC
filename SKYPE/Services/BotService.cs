using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;
using SKYPE.Controllers.hub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SKYPE.Services
{
    public class BotService : IBotService
    {
        private readonly IConfiguration configuration;
        protected static string _skypeLogin = "do230379pav";

        public BotService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async void Send(Activity activity)
        { 
            var baseUrl = "http://localhost:52901/chat";
            var connection = new HubConnectionBuilder()
                .WithUrl(baseUrl)
                .WithConsoleLogger()
                .Build();

            await connection.StartAsync();
            await connection.InvokeAsync<ChatHub>("Send", activity.Text, activity.From.Name);
        }

        public async void SendToSkype(string txtMessage)
        {
            MicrosoftAppCredentials appCredentials = new MicrosoftAppCredentials(this.configuration);
            var connector = new ConnectorClient(new Uri("https://smba.trafficmanager.net/apis/"), appCredentials);
            
            IMessageActivity messagenew = Activity.CreateMessageActivity();

            try 
            { 
                var conversationId = "8:" + _skypeLogin.Trim().ToLower();
                messagenew.Conversation = new ConversationAccount(isGroup: false, id: conversationId);
                messagenew.Text = txtMessage.ToString();
                messagenew.Locale = "en-Us";
                await connector.Conversations.SendToConversationAsync((Activity)messagenew);
            }
            catch (Exception e)
            {
                var baseUrl = "http://localhost:52901/chat";
                var connection = new HubConnectionBuilder()
                    .WithUrl(baseUrl)
                    .WithConsoleLogger()
                    .Build();

                await connection.StartAsync();
                await connection.InvokeAsync<ChatHub>("Send", "Error: " + e.InnerException, "Bot");
            }
        }

        public void SetSkypeLogin(string skypeLogin)
        {
            _skypeLogin = skypeLogin;
        }
    }
}
