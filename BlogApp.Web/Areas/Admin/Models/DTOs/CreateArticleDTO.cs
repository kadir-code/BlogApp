using BlogApp.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Models.DTOs
{
    public class CreateArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public IFormFile ImagePath { get; set; }

        public int CategoryId { get; set; }
        public int AppUserId { get; set; }


        public List<GetCategoryVM> Categories { get; set; }
        public List<GetUserVM> AppUsers { get; set; }
    }
}
