using Wardrobe.Models.Entities;

namespace Wardrobe.Models.DTO
{
    public class UserOutDTO
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
         //works?
    }
}
