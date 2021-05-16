using Domain.Enums;

namespace Api.DTOs
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public EGroup Group { get; set; }
    }
}