using Wardrobe.Models.Entities;

namespace Wardrobe.Models.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }
    }
}
