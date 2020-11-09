using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    interface ICommunicationHandler
    {
        void Send(string userMessage, string SenderIP, string SenderName, string ReceiverIP, string ReceiverName);
        string Receive();
        bool Listen();
    }
}
