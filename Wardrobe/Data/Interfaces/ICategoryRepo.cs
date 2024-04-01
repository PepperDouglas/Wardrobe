using Wardrobe.Models.Entities;

namespace Wardrobe.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task CreateCategory(Category category);

        Task<Category> GetCategory(int id);

        Task<ICollection<Category>> GetCategories();

        Task<bool> CategoryExists(string name);

        Task<Category> GetCategoryByName(string name);
    }
}
