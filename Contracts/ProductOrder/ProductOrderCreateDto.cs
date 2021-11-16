using System.ComponentModel.DataAnnotations;
using TradingPlatform.DatabaseService.Contracts.Order;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.DatabaseService.Contracts.ProductOrder
{
    public class ProductOrderCreateDto
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual OrderReadDto Order { get; set; }
        public virtual ProductReadDto Product { get; set; }

        public int OrderIdSelect { get; set; }
        public int ProductIdSelect { get; set; }
    }
}
