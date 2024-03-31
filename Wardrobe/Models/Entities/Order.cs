using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Models.Entities
{
    public class Order
    {

        public Order() {
            ProductOrders = new HashSet<ProductOrder>();
        }

        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
