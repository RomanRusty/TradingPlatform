using System.Collections.Generic;
using TradingPlatform.DataAccess;

namespace TradingPlatform.Models
{
    public class CartModel
    {
        public List<Order> Orders {  get; set; }
    }
}
