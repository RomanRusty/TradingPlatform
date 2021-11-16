using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.WebMvc.Models
{
    public class AddItemToCartViewModel
    {
        public Product Product {  get; set; }
        public SelectList Orders {  get; set; }
        public ProductOrder ProductOrder {  get; set; }
    }
}