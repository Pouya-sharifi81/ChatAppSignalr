using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModels.Chats
{
    public class CreateGroupViewModel
    {
        public long UserId { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        public string GroupName { get; set; }
    }
}
