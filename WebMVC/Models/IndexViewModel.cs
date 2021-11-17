using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.WebMvc.Models
{
    public class IndexViewModel
    {
        public List<List<ProductReadDto>> Products {  get; set; }
        public SearchViewModel Search {  get; set; }
        public ItemPaginationViewModel ItemPagination {  get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
