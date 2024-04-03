using Microsoft.EntityFrameworkCore;
using Wardrobe.Data.Contexts;
using Wardrobe.Data.Interfaces;
using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Repos
{


    public class ProductRepo : IProductRepo
    {
        private readonly WardrobeContext _context;

        public ProductRepo(WardrobeContext context) {
            _context = context;
        }

        public async Task<bool> AddProduct(Product product) {
            try {
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public async Task<Product> GetProductById(int id) {
            return await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> RemoveProduct(Product product) {
            var potproduct = await _context.Users.FindAsync(product.ProductId);
            if (potproduct != null) {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICollection<Product>> SearchProducts(string term) {
            var products = await _context.Products.Where(p => p.Productname.Contains(term)).ToListAsync();
            
             return products;
             //check if count != 0 in the service layer
            
        }

        public async Task<bool> UpdateProduct(Product product) {
            var existingProduct = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (existingProduct != null) {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
