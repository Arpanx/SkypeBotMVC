using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKYPE.Services
{
    public interface IBotService
    {
        void Send(Activity activity);
        void SendToSkype(string txtMessage);
        void SetSkypeLogin(string skypeLogin);
    }
}
