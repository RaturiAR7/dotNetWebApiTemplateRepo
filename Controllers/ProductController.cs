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
            var allProducts=_context.Products.ToList();
            return Ok(allProducts);
        }   
        ///Using DTO
        // [HttpGet]
        // public IActionResult GetAll()
        // {
                ///Removed createdat field using DTO 
        //     var allProducts=_context.Products.ToList()
        //     .Select(s=>s.ToProductDto());
        //     return Ok(allProducts);
        // }   
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var oneProduct=_context.Products.Find(id);
            if(oneProduct==null)
            {
                return NotFound();
            }
            return Ok(oneProduct.ToProductDto());
        }
        ///Without using DTO
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
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
            var productToUpdate=_context.Products.FirstOrDefault(x=>x.Id==id);
            if(productToUpdate==null)
            {
                return NotFound();
            }
            productToUpdate.Name=product.Name;
            productToUpdate.Brand=product.Brand;
            productToUpdate.Category=product.Category;
            productToUpdate.Description=product.Description;
            productToUpdate.Price=product.Price;
            _context.SaveChanges();
            return Ok(productToUpdate);
        }

        /////Delete
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var productToDelete=_context.Products.FirstOrDefault(x=>x.Id==id);
            if(productToDelete==null)
            {
                return NotFound();
            }
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return NoContent();
        }
    }
}