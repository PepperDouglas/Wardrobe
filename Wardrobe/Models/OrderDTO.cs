using Wardrobe.Models.DTO;
using Wardrobe.Models.Entities;

namespace Wardrobe.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public ICollection<ProductOrderDTO>? ProductOrders { get; set; }
        // Depending on your design, you might want a ProductOrderDTO instead
    }
}
