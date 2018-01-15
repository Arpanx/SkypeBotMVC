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
        protected static string _skypeLogin;

        public BotService(
            IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async void Send(Activity activity)
        { 
            var baseUrl = this.configuration.GetSection("LocalHubSignalrURL").Get<string>();
            var connection = new HubConnectionBuilder()
                .WithUrl(baseUrl)
                .WithConsoleLogger()
                .Build();

            await connection.StartAsync();
            await connection.InvokeAsync<ChatHub>("Send", activity.Text, activity.From.Name);
        }

        public async void SendToSkype(string txtMessage)
        {            
            string _skypeApiURL = this.configuration.GetSection("SkypeApiURL").Get<string>();
            
            MicrosoftAppCredentials.TrustServiceUrl(_skypeApiURL, DateTime.MaxValue);
            MicrosoftAppCredentials appCredentials = new MicrosoftAppCredentials(this.configuration);
            var connector = new ConnectorClient(new Uri(_skypeApiURL), appCredentials);
            
            IMessageActivity messageNew = Activity.CreateMessageActivity();

            try 
            {
                if (_skypeLogin == null)
                {
                    throw new System.ArgumentException("Skype login cannot be null", "_skypeLogin");
                }
                var conversationId = "8:" + _skypeLogin?.Trim().ToLower();
                messageNew.Conversation = new ConversationAccount(isGroup: false, id: conversationId);
                messageNew.Text = txtMessage.ToString();
                messageNew.Locale = "en-Us";
                await connector.Conversations.SendToConversationAsync((Activity)messageNew);
            }
            catch (Exception e)
            {
                var baseUrl = this.configuration.GetSection("LocalHubSignalrURL").Get<string>();
                var connection = new HubConnectionBuilder()
                    .WithUrl(baseUrl)
                    .WithConsoleLogger()
                    .Build();

                await connection.StartAsync();
                await connection.InvokeAsync<ChatHub>("Send", e.Message, "Error ");
            }
        }

        public void SetSkypeLogin(string skypeLogin)
        {
            _skypeLogin = skypeLogin;
        }
    }
}
