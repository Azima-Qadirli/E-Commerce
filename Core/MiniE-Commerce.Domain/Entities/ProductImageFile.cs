namespace MiniE_Commerce.Domain.Entities
{
    public class ProductImageFile : File
    {
        public ICollection<Product> Product { get; set; }
    }
}
