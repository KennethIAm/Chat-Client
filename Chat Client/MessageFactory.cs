using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Chat_Client
{
    public class MessageFactory
    {
        // Creates a Message object from a string.
        public static Message CreateMessage(byte messageType, string messageText, User to, User from)
        {
            if (messageType == 1)
            {
                // Creates a Message.
                return new Message(to, from, new MessageBody(messageText));
            }
            else if (messageType == 2)
            {
                Message message = new Message(to, from, new MessageBody(messageText));

                // Creates an XMLMessage.
                return new XMLMessage(to, from, new MessageBody(messageText), SerializeElement(message));
            }
            else
            {
                // Returns null in case of error.
                return null;
            }
        }

        // Creates a Message object from a string, encrypting it with a key.
        public static Message CreateMessage(string messageText, byte[] key)
        {
            // Creates a SymmetricMessage.
            throw new NotImplementedException();
            // return new SymmetricMessage(messageText, key);
        }

        public static byte[] SerializeElement(Message message)
        {
            XmlSerializer ser = new XmlSerializer(message.GetType());
            byte[] bufferStream = new byte[1024];
            MemoryStream s = new MemoryStream(bufferStream);
            ser.Serialize(s, message);
            return bufferStream;
        }
    }
}
