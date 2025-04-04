using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos.Product;
using Models;

namespace Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id=productModel.Id,
                Name=productModel.Name,
                Brand=productModel.Brand,
                Category=productModel.Category,
                Price=productModel.Price,
                Description=productModel.Description,
            };
        }
        public static Product ToProductCreateDTO(this CreateProductRequestDto productDto)
        {
            return new Product
            {
                Name=productDto.Name,
                Brand=productDto.Brand,
                Category=productDto.Category,
                Price=productDto.Price,
                Description=productDto.Description,
                CreateAt=productDto.CreateAt,
            };
        }
    }
}