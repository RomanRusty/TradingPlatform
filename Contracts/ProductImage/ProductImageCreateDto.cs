using System.ComponentModel.DataAnnotations;
using TradingPlatform.Contracts.Product;

namespace TradingPlatform.Contracts.ProductImage
{
    public class ProductImageCreateDto
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        [Required]
        public virtual ProductReadDto Product { get; set; }
    }
}
