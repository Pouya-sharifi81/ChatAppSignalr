using CoreLayer.Service.User.UserGroups;
using CoreLayer.Utilitiy;
using CoreLayer.ViewModels.Chats;
using DataLayer.Context;
using DataLayer.Entities.Chats;
using DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.Chats.ChatGroups
{
    public class ChatGroupService :BaseService, IChatGroupService
    {
        private IUserGroupService _Usergroup;

        public ChatGroupService(EchatDbContex context, IUserGroupService usergroup) : base(context)
        {
            _Usergroup = usergroup;
        }

        public async Task<ChatGroup> GetGroupBy(string token)
        {
            return await Table<ChatGroup>()
               .FirstOrDefaultAsync(g => g.GroupToken == token);
        }

        public async Task<ChatGroup> GetGroupBy(long id)
        {
            return await GetById<ChatGroup>(id);
        }

        public async Task<List<ChatGroup>> GetUserGroups(long userId)
        {
            return await Table<ChatGroup>()
                .Include(c => c.chats)
                .Where(g => g.OwnerId == userId)
                .OrderByDescending(d => d.CreateDate).ToListAsync();
        }

        public async Task<ChatGroup> InsertGroup(CreateGroupViewModel model)
        {
            if (model.ImageFile == null || !FileValidation.IsValidImageFile(model.ImageFile.FileName))
                throw new Exception();


            var imageName = await model.ImageFile.SaveFile("wwwroot/image/groups");

            var chatGroup = new ChatGroup()
            {
                CreateDate = DateTime.Now,
                GroupTitle = model.GroupName,
                OwnerId = model.UserId,
                GroupToken = Guid.NewGuid().ToString(),
                ImageName = imageName
            };
            Insert(chatGroup);
            await Save();
            await _Usergroup.JoinGroup(model.UserId, chatGroup.Id);
            return chatGroup;
        }

        public async Task<List<SearchResultViewModel>> Search(string title)
        {
            var result = new List<SearchResultViewModel>();
            if (string.IsNullOrWhiteSpace(title))
            {
                return result;
            }
            var group = await Table<ChatGroup>()
                .Where(t => t.GroupTitle.Contains(title))
                .Select(t => new SearchResultViewModel()
                {
                    ImageName = t.ImageName,
                    Token = t.GroupToken,
                    IsUser = false,
                    Title = t.GroupTitle
                }).ToListAsync();
            var users = await Table<UserEntity>()
                .Where(t => t.UserName.Contains(title))
                .Select(t => new SearchResultViewModel()
                {
                    ImageName = t.Avatar,
                    Token = t.Id.ToString(),
                    IsUser = true,
                    Title = t.UserName
                }).ToListAsync();
            result.AddRange(group);
            result.AddRange(users);

            return result;
        }
    }
}
