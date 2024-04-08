using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Interfaces
{
    public interface IProductRepo
    {
        Task<bool> AddProduct(Product product);

        Task<bool> RemoveProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<Product> GetProductById(int id);

        Task<ICollection<Product>> SearchProducts(string term);
    }
}
