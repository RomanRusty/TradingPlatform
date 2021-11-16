using System.Collections.Generic;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.WebMvc.Models
{
    public class CartModel
    {
        public List<Order> Orders {  get; set; }
    }
}
