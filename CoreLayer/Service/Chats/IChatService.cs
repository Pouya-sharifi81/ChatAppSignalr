using CoreLayer.ViewModels.Chats;
using DataLayer.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.Chats
{
    public interface IChatService
    {
        Task SendMassage(Chat chat);
        Task<List<ChatViewModel>> GetChatGroup(long groupId);
    }
}
