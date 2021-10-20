using System.ComponentModel.DataAnnotations;

namespace TradingPlatform.Dtos
{
    public class ProductOrderCreateDto
    {
        [Required]
        public int Quantity { get; set; }
        public virtual OrderReadDto Order { get; set; }
        public virtual ProductReadDto Product { get; set; }

        public int OrderIdSelect { get; set; }
        public int ProductIdSelect { get; set; }
    }
}
