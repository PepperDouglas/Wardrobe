using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wardrobe.Models.Entities
{
    public class User
    {

        public User()
        {
            Orders = new HashSet<Order>();
        }


        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
