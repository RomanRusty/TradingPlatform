using System.Collections.Generic;

namespace TradingPlatform.Dtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<ProductReadDto> Products { get; set; }
    }
}
