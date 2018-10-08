﻿using ChatServer.EF;
using ChatServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Repositories
{
    public class ChatRepository:RepositoryBase<Chat>,IChatRepository
    {
        private ApplicationContext _db;

        public ChatRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Chat>> GetChatList()
        {
            return await _db.Chats.ToListAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetChatMessages(int chatId)
        {
            return await _db.ChatMessages.Where(c => c.Chat.Id == chatId).ToListAsync();
        }

        public void SaveMessages(int chatId,ChatMessage chatMessage)
        {
            var chat = _db.Chats.FirstOrDefault(c => c.Id == chatId);
            if(chat == null)
            {
                return;
            }
            chat.Messages.Add(chatMessage);
        }
    }
}
