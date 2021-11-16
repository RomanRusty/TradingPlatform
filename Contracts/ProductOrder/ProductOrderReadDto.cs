using TradingPlatform.DatabaseService.Contracts.Order;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.DatabaseService.Contracts.ProductOrder
{
    public class ProductOrderReadDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        //public virtual OrderReadDto Order { get; set; }
        //public virtual ProductReadDto Product { get; set; }
    }
}
