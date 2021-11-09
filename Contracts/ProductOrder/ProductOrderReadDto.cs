using TradingPlatform.Contracts.Order;
using TradingPlatform.Contracts.Product;

namespace TradingPlatform.Contracts.ProductOrder
{
    public class ProductOrderReadDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual OrderReadDto Order { get; set; }
        public virtual ProductReadDto Product { get; set; }
    }
}
