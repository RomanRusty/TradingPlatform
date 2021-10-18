using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TradingPlatform.DataAccess;

namespace TradingPlatform.Models
{
    public class IndexViewModel
    {
        public List<List<Product>> Products {  get; set; }
        public SearchViewModel Search {  get; set; }
        public ItemPaginationViewModel ItemPagination {  get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
