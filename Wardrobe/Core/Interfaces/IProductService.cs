﻿using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Interfaces
{
    public interface IProductService
    {
        Task<ResultFlag> AddProduct(ProductDTO product);

        Task<ResultFlag> RemoveProduct(Product product);

        Task<ResultFlag> UpdateProduct(ProductDTO product);
        //For this case we have the product DTO, where we include the update id

        Task<Product> GetProductById(int id);

        Task<ICollection<Product>> SearchProducts(string term);
    }
}
