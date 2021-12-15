using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Contracts.Products
{
    public class ProductCreateViewModel
    {
        public IFormFile ImageThumbnail { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public ProductCreateDto ProductCreate { get; set; }
        public SelectList Categories { get; set; }
    }
}
