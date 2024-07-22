using DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Chats
{
    public class Chat : BaseEntity
    {
        public string ChatBody { get; set; }
        public long UserId { get; set; }
        public long GroupId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity user { get; set; }
        [ForeignKey("GroupId")]
        public ChatGroup chatGroup  { get; set; }
    }
}
