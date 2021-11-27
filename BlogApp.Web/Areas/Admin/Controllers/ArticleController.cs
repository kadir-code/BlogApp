using AutoMapper;
using BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories;
using BlogApp.Model.Entities.Concrete;
using BlogApp.Model.Enums;
using BlogApp.Web.Areas.Admin.Models.DTOs;
using BlogApp.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepository articleRepository,
                                 ICategoryRepository categoryRepository,
                                 IAppUserRepository appUserRepository,
                                 IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._articleRepository = articleRepository;
            this._appUserRepository = appUserRepository;
            this._mapper = mapper;

        }

        public IActionResult Create()
        {
            CreateArticleDTO model = new CreateArticleDTO()
            {
                Categories = _categoryRepository.GetByDefaults(
                    selector: x => new GetCategoryVM
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    expression: x => x.Status != Status.Passive),

                AppUsers = _appUserRepository.GetByDefaults(
                    selector: x => new GetUserVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    },
                    expression: x => x.Status != Status.Passive && x.Role != Role.Member)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(model);

                if (article.ImagePath != null)
                {
                    using var image = Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    Guid guid = Guid.NewGuid();
                    image.Save($"wwwroot/images/{guid}.jpg");
                    article.Image = ($"/images/{guid}.jpg");
                    _articleRepository.Create(article);
                    return RedirectToAction("List");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult List()
        {
            var articleList = _articleRepository.GetByDefaults(
                selector: x => new GetArticleVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Image = x.Image,
                    CategoryName = x.Category.Name,
                    AuthorName = x.AppUser.FullName
                },
                expression: x => x.Status != Status.Passive,
                include: x => x.Include(z => z.Category).Include(z => z.AppUser));

            return View(articleList);
        }

        public IActionResult Details(int id)
        {
            var articleDetails = _articleRepository.GetByDefault(
                selector: x => new GetArticleDetailsVM
                {
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
        public IActionResult Update(int id)
        {
            Article article = _articleRepository.GetDefault(x=>x.Id==id);
            var articleObj = _mapper.Map<UpdateArticleDTO>(article);
            return View(articleObj);
        }
        [HttpPost]
        public IActionResult Update(UpdateArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(model);
                _articleRepository.Update(article);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            Article article = _articleRepository.GetDefault(x=>x.Id==id);
            _articleRepository.Delete(article);
            return RedirectToAction("List");
        }
    }
}
