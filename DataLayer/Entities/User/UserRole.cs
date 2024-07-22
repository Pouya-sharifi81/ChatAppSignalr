using DataLayer.Entities.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.User
{
    public class UserRole : BaseEntity
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }


        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        [ForeignKey("RoleId")]

        public RoleEntity Role { get; set; }
    }
}
