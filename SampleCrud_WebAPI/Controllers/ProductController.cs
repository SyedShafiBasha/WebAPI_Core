using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCrud_WebAPI.Models;
using SampleCrud_WebAPI.Repositories;

namespace SampleCrud_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IDataAccess<Product, int> _productRepo;
        public ProductController(IDataAccess<Product, int> id)
        {
            _productRepo = id;

        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _productRepo.GetProducts();
            return products;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productRepo.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            int res = _productRepo.AddProduct(product);
            if (res != 0)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                int res = _productRepo.UpdateProduct(id, product);
                if (res != 0)
                {
                    return Ok(res);
                }
                return NotFound();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int res = _productRepo.DeleteProduct(id);
            if (res != 0)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}