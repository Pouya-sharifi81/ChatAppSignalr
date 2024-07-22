using CoreLayer.ViewModels.Chats;
using DataLayer.Context;
using DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreLayer.Service.User.UserGroups
{
    public class UserGroupService : BaseService, IUserGroupService
    {
        public UserGroupService(EchatDbContex context) : base(context)
        {
        }

        public async Task<List<UserGroupViewModel>> GetUserGroups(long userId)
        {
            var result = Table<UserGroup>()
                .Include(c => c.chatGroup.chats)
                .Where(g => g.UserId == userId)
                .Select(s => new UserGroupViewModel()
                {
                    ImageName = s.chatGroup.ImageName,
                    GroupName = s.chatGroup.GroupTitle,
                    LastChat = s.chatGroup.chats.OrderBy(d => d.CreateDate).First(),
                    Token = s.chatGroup.GroupToken
                });

            return await result.ToListAsync();
        }

        public async Task<List<string>> GetUserIds(long groupId)
        {
            return await Table<UserGroup>().Where(g=> g.GroupId == groupId)
                .Select(s=>s.UserId.ToString()).ToListAsync();
        }

        public async Task<bool> IsUserInGroup(long userId, long groupId)
        {
           return await Table<UserGroup>().AnyAsync(s=> s.GroupId == groupId && s.UserId == userId);
        }

        public async Task<bool> IsUserInGroup(long userId, string token)
        {
            return await Table<UserGroup>()
                .Include(t=>t.chatGroup)
                .AnyAsync(s => s.UserId == userId && s.chatGroup.GroupToken == token);

        }

        public async Task JoinGroup(long userId, long GroupId)
        {
            var model = new UserGroup()
            {
                CreateDate = DateTime.Now,
                GroupId = GroupId,
                UserId = userId
            };
            Insert(model);
            await Save();
        }
    }
}
