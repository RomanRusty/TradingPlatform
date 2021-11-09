using System.Collections.Generic;
using TradingPlatform.Contracts.Product;

namespace TradingPlatform.Contracts.Category
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<ProductReadDto> Products { get; set; }
    }
}
