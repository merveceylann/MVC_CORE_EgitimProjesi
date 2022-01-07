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
    public class PersonsController : ControllerBase
    {
        IServices<Person> _perService;

        public PersonsController(IServices<Person> perService)
        {
            _perService = perService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var per = await _perService.GetAllAsync();
            return Ok(per);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var per = await _perService.GetByIdAsync(id);
            return Ok(per);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person pers)
        {
            var per = await _perService.AddAsync(pers);
            return Ok(per);
        }

        [HttpPut]
        public IActionResult Update(Person pers)
        {
            var per = _perService.Update(pers);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            var per = _perService.GetByIdAsync(id).Result;
            _perService.Remove(per);
            return NoContent();
        }

    }
}
