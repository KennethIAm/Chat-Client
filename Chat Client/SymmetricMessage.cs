﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    class SymmetricMessage : Message
    {
        public SymmetricMessage(User to, User from, MessageBody mb) : base(to, from, mb)
        {

        }
    }
}
