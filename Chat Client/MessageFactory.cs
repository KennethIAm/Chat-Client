using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    public class MessageFactory
    {
        // Creates a Message object from a string.
        public static Message CreateMessage(string messageText, byte messageType)
        {
            if (messageType == 1)
            {
                // Creates a Message.
                return new Message(messageText);
            }
            else if (messageType == 2)
            {
                // Creates an XMLMessage.
                throw new NotImplementedException();
                // return new XMLMessage(messageText);
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
        public static Message CreateMessage(string messageText, byte[] publicKey, byte[] privateKey)
        {
            // Creates an AsymmetricMessage.
            throw new NotImplementedException();
            // return new AsymmetricMessage(messageText, key);
        }
    }
}
