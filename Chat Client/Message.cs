using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    public class Message
    {
        public User To { get; set; }
        public User From { get; set; }
        public MessageBody Mb { get; set; }
        public byte[] MessageBuffer { get; set; }

        public Message(User to, User from, MessageBody mb, byte[] messageBuffer)
        {
            To = to;
            From = from;
            Mb = mb;
            MessageBuffer = messageBuffer;
        }

        public Message(User to, User from, MessageBody mb)
        {
            To = to;
            From = from;
            Mb = mb;

            MessageBuffer = Encoding.ASCII.GetBytes(From.Name + ":" + From.Ip + ":" + To.Name + ":" + From.Ip + ":" + Mb.Body + "\r\n");

        }
    }
}
