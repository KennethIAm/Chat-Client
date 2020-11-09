using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Chat_Client
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.Write("Enter Username: ");
            string userInput = Console.ReadLine();
            ChatController chatController = new ChatController(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(),
                "Placeholder", 1, new SocketHandler(), userInput);
            chatController.Connect();

            Console.ReadLine();
            while (true)
            {
                Console.Clear();

                foreach (string s in chatController.ChatLog)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("_________________________________________________________");
                Console.Write("Enter Message: ");
                chatController.SendMessage(Console.ReadLine());
            }
        }
    }
}
