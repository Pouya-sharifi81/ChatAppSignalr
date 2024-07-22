using CoreLayer.ViewModels.Chats;
using DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.User.UserGroups
{
    public interface IUserGroupService
    {
        Task<List<UserGroupViewModel>> GetUserGroups(long userId);
        Task JoinGroup(long userId , long GroupId);
        Task<bool> IsUserInGroup(long userId, long groupId);
        Task<bool> IsUserInGroup(long userId, string token);
        Task<List<string>> GetUserIds(long groupId);
    }
}

