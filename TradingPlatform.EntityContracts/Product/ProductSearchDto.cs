using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.EntityContracts.Product
{
    public class ProductSearchDto
    {
        public string Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public string CategoryName { get; set; }
    }
}
