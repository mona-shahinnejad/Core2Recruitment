using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SIENN.Services.DTO;
using SIENN.Services.IServices;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(UnitDto input)
        {
            if (ModelState.IsValid && _unitService.Add(input))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult AdUpdated(UnitDto input)
        {
            if (ModelState.IsValid && _unitService.Update(input))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("add")]
        public IActionResult Delete(UnitDto input)
        {
            if (ModelState.IsValid && _unitService.Delete(input))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(IEnumerable<UnitDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_unitService.GeTAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("find")]
        [ProducesResponseType(typeof(UnitDto), 200)]
        public IActionResult Find(string code)
        {
            try
            {
                return Ok(_unitService.Find(code));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("findbyname")]
        [ProducesResponseType(typeof(IEnumerable<UnitDto>), 200)]
        public IActionResult FindByName(string name)
        {
            try
            {
                return Ok(_unitService.FindByName(name));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}