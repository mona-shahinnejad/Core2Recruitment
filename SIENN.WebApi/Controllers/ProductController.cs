using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SIENN.Services.DTO;
using SIENN.Services.IServices;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductDto input)
        {
            if (ModelState.IsValid && _productService.Add(input))
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
        public IActionResult AdUpdated(ProductDto input)
        {
            if (ModelState.IsValid && _productService.Update(input))
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
        public IActionResult Delete(ProductDto input)
        {
            if (ModelState.IsValid && _productService.Delete(input))
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
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GeTAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("find")]
        [ProducesResponseType(typeof(ProductDto), 200)]
        public IActionResult Find(string code)
        {
            try
            {
                return Ok(_productService.Find(code));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("findbyname")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        public IActionResult FindByName(string name)
        {
            try
            {
                return Ok(_productService.FindByName(name));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getavailableproducts")]
        [ProducesResponseType(typeof(PagingDto<ProductDto>), 200)]
        public IActionResult GetAvailableProducts(PagingRequestDto request)
        {
            try
            {
                return Ok(_productService.GetAvailableProducts(request));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getproducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
        public IActionResult GetProducts(ProductFilterDto filters)
        {
            try
            {
                return Ok(_productService.GetProducts(filters));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getproductcustomviews")]
        [ProducesResponseType(typeof(PagingDto<ProductCustomViewDto>), 200)]
        public IActionResult GetProductCustomViews(PagingRequestDto request)
        {
            try
            {
                return Ok(_productService.GetProductCustomViews(request));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}