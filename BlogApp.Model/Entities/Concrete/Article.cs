using BlogApp.Model.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogApp.Model.Entities.Concrete
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        [NotMapped] 
        public IFormFile ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
