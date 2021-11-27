using AutoMapper;
using BlogApp.Model.Entities.Concrete;
using BlogApp.Web.Areas.Admin.Models.DTOs;
using BlogApp.Web.Areas.Admin.Models.VMs;
using BlogApp.Web.Areas.Member.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Models.Mapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, CreateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, GetUserVM>().ReverseMap();
            CreateMap<AppUser, GetAppUserDetailsVM>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryVM>().ReverseMap();

            CreateMap<Article, CreateArticleDTO>().ReverseMap();
            CreateMap<Article, UpdateArticleDTO>().ReverseMap();
            CreateMap<Article, GetArticleVM>().ReverseMap();
            CreateMap<Article, GetHomeArticleVM>().ReverseMap();

            CreateMap<Comment, CommandListVM>().ReverseMap();
        }
    }
}
