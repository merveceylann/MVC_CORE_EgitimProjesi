using AutoMapper;
using CoreApp102.Core.Models;
using CoreApp102.Core.Services;
using CoreApp102.Mvc.ApiService;
using CoreApp102.Mvc.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Mvc.Controllers
{
    public class CategoryApiController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryApiController(CategoryApiService categoryApiService, IMapper mapper)
        {
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }
        //[UseSSL]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            //var category = 1;//await _categoryService.GetByIdAsync(id);
            //return View(_mapper.Map<CategoryDto>(category));
            return View();
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
          //  _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
           // var category = _categoryService.GetByIdAsync(id).Result;
          //  _categoryService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}

