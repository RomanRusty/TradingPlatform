using System.Collections.Generic;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.Models
{
    public class CartModel
    {
        public List<Order> Orders {  get; set; }
    }
}
