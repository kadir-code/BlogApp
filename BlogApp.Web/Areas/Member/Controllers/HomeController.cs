using AutoMapper;
using BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories;
using BlogApp.Model.Enums;
using BlogApp.Web.Areas.Admin.Models.DTOs;
using BlogApp.Web.Areas.Admin.Models.VMs;
using BlogApp.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Member.Controllers
{
    [Area("Member")]

    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public HomeController(IArticleRepository articleRepository,
                             IMapper mapper)
        {
            this._articleRepository = articleRepository;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var articleList = _articleRepository.GetByDefaults(
                selector: x => new GetHomeArticleVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreateDate = x.CreateDate,
                    Image = x.Image,
                    CommentCount = x.Comments.Count,
                    LikeCount = x.Likes.Count,
                    AuthorImage = x.AppUser.Image,
                    AuthorName = x.AppUser.FullName
                },
                expression: x => x.Status != Status.Passive);
            return View(articleList);
        }
        public IActionResult Details(int id)
        {
            var articleDetails = _articleRepository.GetByDefault(
                selector: x => new GetArticleDetailsVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreateDate = x.CreateDate,
                    Image = x.Image,
                    AuthorName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.Image,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count,
                    Comments = x.Comments.Where(z => z.ArticleId == id)
                                         .OrderByDescending(z => z.CreateDate)
                                         .Select(z => new CommentDTO
                                         {
                                             Id = z.Id,
                                             Text = z.Text,
                                             UserImage = z.AppUser.Image,
                                             FullName = z.AppUser.FullName,
                                             CreateDate = z.CreateDate
                                         }).ToList(),
                },
                expression: x => x.Id == id,
                include: x => x.Include(z => z.AppUser).ThenInclude(z => z.Comments));

            return View(articleDetails);
        }
    }
}
