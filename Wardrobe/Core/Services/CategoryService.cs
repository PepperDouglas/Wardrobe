using Wardrobe.Core.Interfaces;
using Wardrobe.Data.Interfaces;
using Wardrobe.Helpers;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo) {
            _categoryRepo = categoryRepo;
        }

        public async Task<bool> CategoryExists(string name) {
            return await _categoryRepo.CategoryExists(name);
        }

        public async Task<ResultFlag> CreateCategory(Category category) {
            ResultFlag result = new ResultFlag(false, "");
            try {
                await _categoryRepo.CreateCategory(category);
                result.Message = "Category created";
                result.Success = true;
            } catch (Exception ex) {
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ICollection<Category>> GetCategories() {
            return await _categoryRepo.GetCategories();
        }

        public async Task<Category> GetCategory(int id) {
            return await _categoryRepo.GetCategory(id);
        }

        public async Task<Category> GetCategoryByName(string name) {
            return await _categoryRepo.GetCategoryByName(name);
        }
    }
}
