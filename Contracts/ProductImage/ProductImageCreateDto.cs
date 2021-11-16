using System.ComponentModel.DataAnnotations;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.DatabaseService.Contracts.ProductImage
{
    public class ProductImageCreateDto
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        [Required]
        public virtual ProductReadDto Product { get; set; }
    }
}
