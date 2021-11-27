using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Must to type int name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type int description")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Description { get; set; }
    }
}
