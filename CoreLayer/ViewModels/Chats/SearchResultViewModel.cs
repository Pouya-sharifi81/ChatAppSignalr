using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.ViewModels.Chats
{
    public class SearchResultViewModel
    {
        public string Title { get; set; }
        public string Token { get; set; }
        public string ImageName { get; set; }
        public bool IsUser { get; set; }
    }
}
