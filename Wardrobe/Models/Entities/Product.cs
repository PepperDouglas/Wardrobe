using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Models.Entities
{
    public class Product
    {

        public Product() {
            ProductOrders = new HashSet<ProductOrder>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(30)]
        public string Productname { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public double Price { get; set; }
        //Conn
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
