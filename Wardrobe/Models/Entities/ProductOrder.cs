using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Models.Entities
{
    public class ProductOrder
    {
        [Key]
        public int ProductOrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
