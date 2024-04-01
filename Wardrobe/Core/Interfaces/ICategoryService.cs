using Wardrobe.Helpers;
using Wardrobe.Models.Entities;

namespace Wardrobe.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<ResultFlag> CreateCategory(Category category);

        Task<Category> GetCategory(int id);

        Task<ICollection<Category>> GetCategories();

        Task<bool> CategoryExists(string name);

        Task<Category> GetCategoryByName(string name);
    }
}
