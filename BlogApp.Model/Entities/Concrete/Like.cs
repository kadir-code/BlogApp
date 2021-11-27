using BlogApp.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model.Entities.Concrete
{
    public class Like : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
