using System;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.DataAccess;

namespace TradingPlatform.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
