using CoreLayer.ViewModels.Chats;
using DataLayer.Entities.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.Chats.ChatGroups
{
    public interface IChatGroupService
    {
        Task<List<SearchResultViewModel>> Search(string title);
        Task<List<ChatGroup>> GetUserGroups(long userId);
        Task<ChatGroup> InsertGroup(CreateGroupViewModel model);
        Task<ChatGroup> GetGroupBy(string token);
        Task<ChatGroup> GetGroupBy(long id);

    }
}
