using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.DataAccess;

namespace TradingPlatform.Models
{
    public class ProductModel
    {
        public Product Product {  get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
