using System;

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
