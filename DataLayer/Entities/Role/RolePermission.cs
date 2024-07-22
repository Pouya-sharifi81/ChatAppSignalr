using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Role
{
    public class RolePermission:BaseEntity
    {
        public long RoleId { get; set; }
        
        public Permission permission { get; set; }

        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }

    }
}
