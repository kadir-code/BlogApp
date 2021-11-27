using BlogApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Models.VMs
{
    public class GetUserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }

        public string Image { get; set; }
    }
}
