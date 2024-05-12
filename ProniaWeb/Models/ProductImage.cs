namespace ProniaWeb.Models
{
    public class ProductImage
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
