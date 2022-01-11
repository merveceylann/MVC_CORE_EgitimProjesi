using AutoMapper;
using CoreApp102.Core.Models;
using CoreApp102.Core.Services;
using CoreApp102.Mvc.DTOs;
using CoreApp102.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //mapsiz hali
            //IEnumerable<Category> cat = await _categoryService.GetAllAsync();
            //var cat1 = (from s in cat select new { id = s.Id, name = s.Name }).ToList();
            //linq ile de istedigim alanlari getirebilirim ama mapper daha avantajli ama o da sistemi yavaslatiyo
            //return View(cat1);

            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        //[ServiceFilter(typeof(NotFoundFilter))]
        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            //RESULT ONEMLİ UNUTMA
            _categoryService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
