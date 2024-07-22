using DataLayer.Entities.Chats;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.User
{
    public class UserEntity : BaseEntity
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        [MinLength(6)]
        public string Password { get; set; }
        [MaxLength(110)]
        public string Avatar { get; set; }

        [InverseProperty("user")]
        public ICollection<ChatGroup> chatGroups { get; set; }
        
        
        public ICollection<Chat> chats { get; set; }
        public ICollection<UserRole> userRoles { get; set; }
        public ICollection<UserGroup> userGroups { get; set; }
    }
}
