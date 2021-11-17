using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.EntityContracts.ProductImage
{
    public class ProductImageCreateDto
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        [Required]
        public virtual ProductReadDto Product { get; set; }
    }
}
