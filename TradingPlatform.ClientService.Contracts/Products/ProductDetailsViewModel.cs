using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Contracts.Products
{
    public class ProductDetailsViewModel
    {
        public ProductReadDto Product { get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
