namespace Entity.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? description { get; set; }
        public float prix { get; set; }
        public ProductModel()
        {
            Name = "";
            description = "";
        }
    }
}
