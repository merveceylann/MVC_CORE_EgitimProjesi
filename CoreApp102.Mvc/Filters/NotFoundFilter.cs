using CoreApp102.Core.Services;
using CoreApp102.Mvc.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Mvc.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault()!;
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                await next();
            }
            else
            {
                ErrosDto errorDto = new ErrosDto();
                errorDto.Status = 400;
                errorDto.Errors.Add($"Id si {id} olan kategori veritabaninda bulunamadi");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
