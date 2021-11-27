using BlogApp.Web.Areas.Admin.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Models.VMs
{
    public class GetArticleDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime? CreateDate { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        public List<CommentDTO> Comments { get; set; }
    }
}
