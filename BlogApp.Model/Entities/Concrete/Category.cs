using BlogApp.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Article> Articles { get; set; }
    }
}
