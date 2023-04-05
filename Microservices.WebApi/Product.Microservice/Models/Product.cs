namespace Product.Microservice.Models
{
    public class Products : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
    }
}
