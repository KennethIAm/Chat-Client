using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace Chat_Client
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Final Receiver IP Digits: ");
            string receiverIP = "172.16.2." + Console.ReadLine();
            Console.Write("Enter Receiver's Name: ");
            string receiverName = Console.ReadLine();
            ChatController chatController = new ChatController(receiverIP, Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(),
                1, new SocketHandler(), userName, receiverName);

            Console.Clear();
            
            Thread loadingThread = new Thread(new ThreadStart(chatController.Connect));

            loadingThread.Start();
            while (loadingThread.IsAlive)
            {
                Console.WriteLine("LOADING");
                Console.WriteLine();
                Console.Write(". ");

                Thread.Sleep(1000);

                Console.Write(". ");

                Thread.Sleep(1000);

                Console.Write(". ");

                Thread.Sleep(1000);

                Console.Clear();
            }

            chatController.UpdateUI();

            Thread receiveThread = new Thread(new ThreadStart(chatController.ReceiveMessage));

            receiveThread.Start();

            while (true)
            {
                chatController.SendMessage(Console.ReadLine());
            }
        }
    }
}
