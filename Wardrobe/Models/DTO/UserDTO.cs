using Wardrobe.Models.Entities;

namespace Wardrobe.Models.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }
        
        //ett concern var att om vi vill få ut en orderdetalj
        //så blir det fel, men dessa orders är bara för vår
        //userdto, så dessa ordrar kan också vara en dto
        //eftersom de annars chainar ner rekursivt
    }
}
