using AutoMapper;
using BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories;
using BlogApp.Model.Entities.Concrete;
using BlogApp.Model.Enums;
using BlogApp.Web.Areas.Admin.Models.DTOs;
using BlogApp.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,
                                  IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                _categoryRepository.Create(category);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult List()
        {
            var category = _categoryRepository.GetByDefaults(
                selector: x => new GetCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                },
                expression: x => x.Status != Status.Passive);

            return View(category);
        }
        public IActionResult Update(int id)
        {
            Category category = _categoryRepository.GetDefault(x => x.Id == id);
            var categoryObj = _mapper.Map<UpdateCategoryDTO>(category);
            return View(categoryObj);
        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);
                _categoryRepository.Update(category);
                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetDefault(x => x.Id == id);
            _categoryRepository.Delete(category);
            return RedirectToAction("List");
        }
    }
}
