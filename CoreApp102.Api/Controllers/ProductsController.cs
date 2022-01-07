using AutoMapper;
using CoreApp102.Api.DTOs;
using CoreApp102.Api.Filters;
using CoreApp102.Core.Models;
using CoreApp102.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _proService;
        private IMapper _mapper;

        public ProductsController(IProductService proService, IMapper mapper)
        {
            _proService = proService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pro = await _proService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(pro));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pro = await _proService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(pro));
        }
        //categorilerle gelen bir listeleme yani get daha yappp

        //[ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto proDto)
        {
            var Pro = await _proService.AddAsync(_mapper.Map<Product>(proDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(Pro));
        }

        [HttpPut]
        public IActionResult Update(ProductDto proDto)
        {
            if (string.IsNullOrEmpty(proDto.Id.ToString()) || proDto.Id == 0)
            {
                throw new Exception("Id alani zorunludur.");
            }
            var Pro = _proService.Update(_mapper.Map<Product>(proDto));
            return NoContent();
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var pro = _proService.GetByIdAsync(id).Result;
            _proService.Remove(pro);
            return NoContent();
        }

    }
}

