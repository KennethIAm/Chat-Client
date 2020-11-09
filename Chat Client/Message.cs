using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    public class Message
    {
        private string messageString;
        private string receiverIP;
        private string senderIP;
        public string MessageString { get => messageString; set => messageString = value; }
        public string ReceiverIP { get => receiverIP; set => receiverIP = value; }
        public string SenderIP { get => senderIP; set => senderIP = value; }

        public Message(string message)
        {
            MessageString = message;
            ReceiverIP = receiverIP;
            SenderIP = senderIP;
        }
    }
}
