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
    }
}