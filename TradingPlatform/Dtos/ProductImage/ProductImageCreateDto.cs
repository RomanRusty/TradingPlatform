using System.ComponentModel.DataAnnotations;

namespace TradingPlatform.Dtos
{
    public class ProductImageCreateDto
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        [Required]
        public virtual ProductReadDto Product { get; set; }
    }
}
