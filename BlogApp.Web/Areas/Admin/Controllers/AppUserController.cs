using AutoMapper;
using BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories;
using BlogApp.Model.Entities.Concrete;
using BlogApp.Model.Enums;
using BlogApp.Web.Areas.Admin.Models.DTOs;
using BlogApp.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserRepository appUserRepository, IMapper mapper)
        {
            this._appUserRepository = appUserRepository;
            this._mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                if (model.ImagePath != null)
                {
                    using var image = Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save($"wwwroot/images/{user.UserName}.jpg");
                    _appUserRepository.Create(user);
                    return RedirectToAction("List");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult List()
        {
            var user = _appUserRepository.GetByDefaults(
                selector: x => new GetUserVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Password = x.Password,
                    Role = x.Role,
                    Image = x.Image
                },
                expression: x => x.Status != Status.Passive);

            return View(user);
        }
        public IActionResult Delete(int id)
        {
            AppUser user = _appUserRepository.GetDefault(x=>x.Id==id);
            _appUserRepository.Delete(user);
            return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            AppUser user = _appUserRepository.GetDefault(x=>x.Id==id);
            var userUpdate = _mapper.Map<UpdateAppUserDTO>(user);
            return View(userUpdate);
        }
        [HttpPost]
        public IActionResult Update(UpdateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                _appUserRepository.Update(user);
                return RedirectToAction("List");

            }
            else
            {
                return View(model);

            }
        }
    }
}
