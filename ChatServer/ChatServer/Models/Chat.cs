﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ApplicationUser Creator { get; set; }
        public List<ApplicationUser> Members { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public Chat()
        {
            Members = new List<ApplicationUser>();
            Messages = new List<ChatMessage>();
        }
    }
}