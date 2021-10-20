using System.Collections.Generic;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Models
{
    public class CartModel
    {
        public List<Order> Orders {  get; set; }
    }
}
