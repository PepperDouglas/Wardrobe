using AutoMapper;
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
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, ICategoryRepo categoryRepo, IMapper mapper) {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<ResultFlag> AddProduct(ProductDTO product) {
            ResultFlag flag = new ResultFlag(false, "Could not add product");
            //get the category bool
            var catExists = await _categoryRepo.GetCategoryByName(product.Category);
            if (catExists == null) {
                flag.Message = "Category does not exist";
                return flag;
            }
            //map
            var domainProduct = _mapper.Map<Product>(product);
            //also manual mapping
            domainProduct.CategoryId = catExists.CategoryId;
            var result = await _productRepo.AddProduct(domainProduct);
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
            ResultFlag flag = new ResultFlag(false, "Update failed");
            //get category valid
            var catExists = await _categoryRepo.GetCategoryByName(product.Category);
            if (catExists == null) {
                flag.Message = "Category does not exist";
                return flag;
            }
            //map that
            var domainProduct = _mapper.Map<Product>(product);
            //also manual mapping
            domainProduct.CategoryId = catExists.CategoryId;
            var result = await _productRepo.UpdateProduct(domainProduct);
            if (result) {
                flag.Success = true;
                flag.Message = "Update successful";
            }
            return flag;
        }
    }
}
