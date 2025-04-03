using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products=_context.Products.ToList();
            return Ok(products);
        }   
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product=_context.Products.Find(id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);

        }
    }
}