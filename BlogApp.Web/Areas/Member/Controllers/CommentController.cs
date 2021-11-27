using BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories;
using BlogApp.Model.Entities.Concrete;
using BlogApp.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Member.Controllers
{
    [Area("Member")]

    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }
        public JsonResult DeleteComment(int id)
        {
            Comment comment = _commentRepository.GetDefault(x => x.Id == id);
            _commentRepository.Delete(comment);
            return Json("");
        }
        public JsonResult AddComment(string userComment, int articleId)
        {
            Comment comment = new Comment();
            comment.AppUserId = 1;
            comment.Text = userComment;
            comment.ArticleId = articleId;
            _commentRepository.Create(comment);
            return Json("");
        }
        public JsonResult GetArticleComment(int id)
        {
            var comment = _commentRepository.GetByDefaults(
                selector: x => new CommandListVM
                {
                    AppUserImage = x.AppUser.Image,
                    FullName = x.AppUser.FullName,
                    CreateDate = x.CreateDate,
                },
                orderby: x => x.OrderByDescending(z => z.CreateDate),
                expression: x => x.ArticleId == id).Take(1);
            return Json(comment);

        }
    }
}
