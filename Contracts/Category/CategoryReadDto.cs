using System.Collections.Generic;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.DatabaseService.Contracts.Category
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual IEnumerable<CategoryReadDto> Categories { get; set; }
    }
}
