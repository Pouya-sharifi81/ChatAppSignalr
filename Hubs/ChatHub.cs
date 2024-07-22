using CoreLayer.Service.Chats;
using CoreLayer.Service.Chats.ChatGroups;
using CoreLayer.Service.User.UserGroups;
using CoreLayer.Utilitiy;
using CoreLayer.ViewModels.Chats;
using DataLayer.Entities.Chats;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Signalr.Hubs
{
    public class ChatHub : Hub, IChatHub
    {
        private IChatGroupService _groupService;
        private IUserGroupService _userGroup;
        private IChatService _chatService;

        public ChatHub(IChatGroupService groupService, IUserGroupService userGroup, IChatService chatService)
        {
            _groupService = groupService;
            _userGroup = userGroup;
            _chatService = chatService;
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Welcome", Context.User.GetUserId());
            return base.OnConnectedAsync();
        }

        public async Task JoinGroup(string token, long currentGroupId)
        {
            var group = await _groupService.GetGroupBy(token);
            if (group == null)
                await Clients.Caller.SendAsync("Error", "Group Not Found");
            else
            {
                var chats = await _chatService.GetChatGroup(group.Id);
                if (!await _userGroup.IsUserInGroup(Context.User.GetUserId(), token))
                {
                    await _userGroup.JoinGroup(Context.User.GetUserId(), group.Id);
                    await Clients.Caller.SendAsync("NewGroup", group.GroupTitle, group.GroupToken, group.ImageName);
                }
                if (currentGroupId > 0)
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentGroupId.ToString());

                await Groups.AddToGroupAsync(Context.ConnectionId, group.Id.ToString());
                await Clients.Group(group.Id.ToString()).SendAsync("JoinGroup", group , chats);
            }
        }

        public async Task SendMessage(string text, long groupId)
        {
            var group = await _groupService.GetGroupBy(groupId);
            if (group == null)
                return;
            var chat = new Chat()
            {
                ChatBody = text,
                GroupId = groupId,
                CreateDate = DateTime.Now,
                UserId = Context.User.GetUserId()
            };
            await _chatService.SendMassage(chat);
            var chatModel = new ChatViewModel()
            {
                ChatBody = text,
                UserName = Context.User.GetUserName(),
                CreateDate = $"{chat.CreateDate.Hour} : {chat.CreateDate.Minute}",
                UserId = Context.User.GetUserId(),
                GroupName = group.GroupTitle,
                GroupId = groupId
            };
            var userIds = await _userGroup.GetUserIds(groupId);
            await Clients.Users(userIds).SendAsync("ReceiveNotification", chatModel);
            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", chatModel);
        }

    }
}
