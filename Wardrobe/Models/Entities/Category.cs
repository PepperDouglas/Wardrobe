using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Models.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }


        [Key]
        public int CategoryId { get; set; }
        [StringLength(40)]
        public string Categoryname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
