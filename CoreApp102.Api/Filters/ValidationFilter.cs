using CoreApp102.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Api.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrosDto errosDto = new ErrosDto();
                errosDto.Status = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(s => s.Errors);

                modelErrors.ToList().ForEach(s =>
                {
                    errosDto.Errors.Add(s.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errosDto);
            }
        }
    }
}
