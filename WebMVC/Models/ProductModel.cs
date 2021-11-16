using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.WebMvc.Models
{
    public class ProductModel
    {
        public Product Product {  get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
