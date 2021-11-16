using System;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.DatabaseService.Contracts.Complaint
{
    public class ComplaintReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        //public virtual ProductReadDto Product { get; set; }
    }
}
