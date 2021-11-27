using BlogApp.Model.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Models.DTOs
{
    public class CreateAppUserDTO
    {
        [Required(ErrorMessage = "Must to type into first name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must to type into last name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must to type into user name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must to type into password")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Role Role { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }
    }
}
