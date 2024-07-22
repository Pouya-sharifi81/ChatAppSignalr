using DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Chats
{
    public class ChatGroup : BaseEntity
    {
        public string GroupTitle { get; set; }
        public string GroupToken { get; set; }
        public long OwnerId { get; set; }
        public string ImageName { get; set; }
    

        [ForeignKey("OwnerId")]
        public UserEntity user { get; set; }
        

        public ICollection<Chat> chats { get; set; }
        public ICollection<UserGroup> userGroups { get; set; }

    }
}
