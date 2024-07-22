using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModels.Chats
{
    public class ChatViewModel
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }
        public string ChatBody { get; set; }
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public string CreateDate { get; set; }
    }
}
