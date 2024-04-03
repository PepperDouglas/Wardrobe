namespace Wardrobe.Models.DTO
{
    public class ProductDTO
    {
        //ProductId used on update, not create
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
