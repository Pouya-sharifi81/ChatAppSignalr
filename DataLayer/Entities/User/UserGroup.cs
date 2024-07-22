using DataLayer.Entities.Chats;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.User
{
    public class UserGroup:BaseEntity
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }

        #region relation
        [ForeignKey("UserId")]
        public UserEntity user { get; set; }
        [ForeignKey("GroupId")]
        public ChatGroup chatGroup { get; set; }

        #endregion
    }
}
