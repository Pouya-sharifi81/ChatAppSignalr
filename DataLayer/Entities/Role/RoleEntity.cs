using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Role
{
    public class RoleEntity : BaseEntity
    {
        [MaxLength(50)]
        public long Title { get; set; }
    }
}
