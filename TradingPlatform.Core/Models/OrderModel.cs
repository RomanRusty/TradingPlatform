using System.Collections.Generic;
using TradingPlatform.DataAccess;

namespace TradingPlatform.Models
{
    public class OrderModel
    {
        public string CustumerName;
        public virtual IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
