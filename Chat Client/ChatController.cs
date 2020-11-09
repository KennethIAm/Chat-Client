using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    class ChatController
    {
        private string senderName;
        private string receiverIP;
        private string senderIP;
        private byte messageType;
        private ICommunicationHandler handler;
        private List<string> chatLog = new List<string>();

        public string SenderName { get => senderName; set => senderName = value; }
        public string ReceiverIP { get => receiverIP; set => receiverIP = value; }
        public string SenderIP { get => senderIP; set => senderIP = value; }
        public byte MessageType { get => messageType; set => messageType = value; }
        public ICommunicationHandler Handler { get => handler; set => handler = value; }
        public List<string> ChatLog { get => chatLog; set => chatLog = value; }

        public ChatController(string receiverIP, string senderIP, byte messageType, ICommunicationHandler handler,
            string senderName)
        {
            ReceiverIP = receiverIP;
            SenderIP = senderIP;
            MessageType = messageType;
            Handler = handler;
            SenderName = senderName;
            ChatLog.Add("~~ Welcome to Chat3000 - the chat client of the future ~~");
        }

        // Connects to the server if the handler implements IConnect.
        public void Connect()
        {
            if (Handler is IConnect)
            {
                IConnect sHandler = (IConnect)handler;
                sHandler.Connect();
            }
        }

        // Creates and sends a message.
        public void SendMessage(string userMessage)
        {
            UpdateChatLog(SenderName, userMessage);
            MessageFactory.CreateMessage(userMessage, 1);
        }

        public void GetKey()
        {

        }

        // Updates the ChatLog with the new message.
        public void UpdateChatLog(string user, string post)
        {
            ChatLog.Add(user + " : " + post);
        }
    }
}
