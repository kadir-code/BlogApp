using BlogApp.Model.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Models.DTOs
{
    public class UpdateAppUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }
    }
}
