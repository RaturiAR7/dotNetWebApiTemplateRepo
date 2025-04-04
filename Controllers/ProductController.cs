using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Product;
using Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models;
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
            ////Without using DTO
            ////Also get created at field
            var products=_context.Products.ToList();
            return Ok(products);
        }   
        ///Using DTO
        // [HttpGet]
        // public IActionResult GetAll()
        // {
                ///Removed createdat field using DTO 
        //     var products=_context.Products.ToList()
        //     .Select(s=>s.ToProductDto());
        //     return Ok(products);
        // }   
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product=_context.Products.Find(id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
        ///Without using DTO
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            Console.WriteLine("Category length: " + product.Category.Length);
            Console.WriteLine("Category value: " + product.Category);

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        ////Using DTO
        // [HttpPost]
        // public IActionResult Create([FromBody] CreateProductRequestDto productDto)
        // {

        //     var productModel=productDto.ToProductCreateDTO();
        //     Console.WriteLine("Category length: " + productDto.Category.Length);
        //     Console.WriteLine("Category value: " + productDto.Category);
        //     _context.Products.Add(productModel);
        //     _context.SaveChanges();
        //     return CreatedAtAction(nameof(GetById),new{id=productModel.Id},productModel.ToProductDto());
        // }


        ///Update
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] Product product)
        {
            var prod=_context.Products.FirstOrDefault(x=>x.Id==id);
            if(prod==null)
            {
                return NotFound();
            }
            prod.Name=product.Name;
            prod.Brand=product.Brand;
            prod.Category=product.Category;
            prod.Description=product.Description;
            prod.Price=product.Price;
            _context.SaveChanges();
            return Ok(prod);
        }

    }
}