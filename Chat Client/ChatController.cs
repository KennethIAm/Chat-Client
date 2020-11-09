using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat_Client
{
    class ChatController
    {
        private User sender;
        private User receiver;
        private byte messageType;
        private ICommunicationHandler handler;
        private List<string> chatLog = new List<string>();

        public User Sender { get => sender; set => sender = value; }
        public User Receiver { get => receiver; set => receiver = value; }
        public byte MessageType { get => messageType; set => messageType = value; }
        public ICommunicationHandler Handler { get => handler; set => handler = value; }
        public List<string> ChatLog { get => chatLog; set => chatLog = value; }

        public ChatController(string receiverIP, string senderIP, byte messageType, ICommunicationHandler handler,
            string senderName, string receiverName )
        {
            Sender.Name = senderName;
            Sender.Ip = senderIP;

            Receiver.Name = receiverName;
            Receiver.Ip = receiverIP;

            MessageType = messageType;
            Handler = handler;

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
            if (userMessage.Remove(1, userMessage.Length - 1) == "/")
            {
                HandleCommand(userMessage);
            }
            else
            {
                UpdateChatLog(Sender.Name, userMessage);
                //MessageFactory.CreateMessage(userMessage, 1);

                Handler.Send(userMessage, Sender.Ip, Sender.Name, Receiver.Ip, Receiver.Name);
            }

            UpdateUI();
        }

        // Handles commands.
        public void HandleCommand(string userMessage)
        {
            if (userMessage.Contains("/ip ") && userMessage.Remove(4, userMessage.Length - 4).ToLower() == "/ip ")
            {
                UpdateReceiver(userMessage);
            }
            else
            {
                chatLog.Add("Error: " + userMessage + " is an unknown command.");
                UpdateUI();
            }
        }

        // Updates either ReceiverIP or ReceiverIP and ReceiverName
        public void UpdateReceiver(string userMessage)
        {
            if (userMessage.Contains(":"))
            {
                Receiver.Ip = userMessage.Remove(0, 4);
                Receiver.Ip = "172.16.2." + Receiver.Ip.Remove(receiver.Ip.IndexOf(":"), Receiver.Ip.Length - Receiver.Ip.IndexOf(":"));
                Receiver.Name = userMessage.Remove(0, 7);
            }
            else
            {
                Receiver.Ip = "172.16.2." + userMessage.Remove(0, 4);
            }
        }

        // Recieves a message fromt he server.
        public void ReceiveMessage()
        {
            string returnValue;
            while (true)
            {
                returnValue = Handler.Receive();


                if (returnValue != null)
                {
                    string user = returnValue.Substring(0, returnValue.IndexOf(':'));
                    string post = "";

                    for (int i = 0; i < 4; i++)
                    {
                        post = returnValue.Substring(returnValue.LastIndexOf(':') + 1);
                    }


                    UpdateChatLog(user, post.Replace("\0", "").Replace("\n", ""));
                    UpdateUI(); 
                    returnValue = null;
                }
                else
                {
                    returnValue = null;
                }
            }
        }

        public void GetKey()
        {

        }

        // Updates the ChatLog with the new message.
        public void UpdateChatLog(string user, string post)
        {
            ChatLog.Add("[" + DateTime.Now.ToString() + "] " + user + " : " + post);
        }
        
        // Updates the UI
        public void UpdateUI()
        {
            Console.Clear();

            foreach (string s in ChatLog)
            {
                if (s.Remove(0, 22).Substring(0, 11) == "USER-ONLINE" || s == "~~ Welcome to Chat3000 - the chat client of the future ~~" || s.Substring(0, 2) == "OK")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(s);
                }
                else if (s.Remove(0, 22).Substring(0, Sender.Name.Length) == Sender.Name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(s);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("_________________________________________________________");
            Console.Write("Enter Message: ");
        }
    }
}
