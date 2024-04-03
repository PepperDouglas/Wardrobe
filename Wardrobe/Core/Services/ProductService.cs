using Wardrobe.Core.Interfaces;
using Wardrobe.Data.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo) {
            _productRepo = productRepo;
        }

        public async Task<ResultFlag> AddProduct(ProductDTO product) {
            //remake to a real product here
            ResultFlag flag = new ResultFlag(false, "Could not add product");
            var result = await _productRepo.AddProduct(product);
            if (result) {
                flag.Success = true;
                flag.Message = "Product added successfully!";
            }
            return flag;
        }

        public async Task<Product> GetProductById(int id) {
            var result = await _productRepo.GetProductById(id);
            if (result != null) {
                return result;
            }
            throw new Exception("No such product found");
        }

        public async Task<ResultFlag> RemoveProduct(Product product) {
            ResultFlag flag = new ResultFlag(false, "Product could not be removed");
            var result = await _productRepo.RemoveProduct(product);
            if (result) {
                flag.Success = true;
                flag.Message = "Product has been removed";
            }
            return flag;
        }

        public async Task<ICollection<Product>> SearchProducts(string term) {
            return await _productRepo.SearchProducts(term);
            
        }

        public async Task<ResultFlag> UpdateProduct(ProductDTO product) {
            //get old product here and remap with new data

            ResultFlag flag = new ResultFlag(false, "Update failed");
            var result = await _productRepo.UpdateProduct(product);
            if (result) {
                flag.Success = true;
                flag.Message = "Update successful";
            }
            return flag;
        }
    }
}
