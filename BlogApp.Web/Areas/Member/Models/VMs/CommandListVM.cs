using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Member.Models.VMs
{
    public class CommandListVM
    {
        public string AppUserImage { get; set; }
        public string FullName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CommentText { get; set; }
        public int CommentCount { get; set; }
    }
}
