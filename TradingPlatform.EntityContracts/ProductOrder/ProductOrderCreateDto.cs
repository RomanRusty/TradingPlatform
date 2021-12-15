using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.EntityContracts.ProductOrder
{
    public class ProductOrderCreateDto
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int OrderIdSelect { get; set; }
        public int ProductIdSelect { get; set; }
    }
}
