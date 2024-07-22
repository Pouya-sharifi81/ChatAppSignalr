using CoreLayer.ViewModels.Chats;
using DataLayer.Context;
using DataLayer.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.Chats
{
    public class ChatService : BaseService, IChatService
    {
        public ChatService(EchatDbContex context) : base(context)
        {
        }

        public async Task<List<ChatViewModel>> GetChatGroup(long groupId)
        {
            return await Table<Chat>()
                .Include(c => c.user)
                .Include(c => c.chatGroup)
                .Where(g => g.GroupId == groupId)
                .Select(s => new ChatViewModel()
                {
                    UserName = s.user.UserName,
                    CreateDate = $"{s.CreateDate.Hour} : {s.CreateDate.Minute}",
                    ChatBody = s.ChatBody,
                    GroupName = s.chatGroup.GroupTitle,
                    UserId = s.UserId,
                    GroupId = s.GroupId
                }).ToListAsync();
        }

        public async Task SendMassage(Chat chat)
        {
            Insert(chat);
            await Save();
        }

       
    }
}
