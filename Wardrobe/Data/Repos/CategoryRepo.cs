using Microsoft.EntityFrameworkCore;
using Wardrobe.Data.Contexts;
using Wardrobe.Data.Interfaces;
using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly WardrobeContext _context;

        public CategoryRepo(WardrobeContext context) {
            _context = context;
        }

        public async Task CreateCategory(Category category) {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public async Task<ICollection<Category>> GetCategories() {
            return _context.Categories.ToList<Category>();
        }

        public async Task<Category> GetCategory(int id) {
            return _context.Categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public async Task<bool> CategoryExists(string name) {
            return _context.Categories.Any(c => EF.Functions.Like(c.Categoryname.ToLower(), name.ToLower()));
        }

        public async Task<Category> GetCategoryByName(string name) {
            return _context.Categories.SingleOrDefault(c => c.Categoryname.ToLower() == name.ToLower());
        }

    }
}
