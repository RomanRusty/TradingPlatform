using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Models
{
    public class AddItemToCartViewModel
    {
        public Product Product {  get; set; }
        public SelectList Orders {  get; set; }
        public ProductOrder ProductOrder {  get; set; }
    }
}