using System;
using TradingPlatform.EntityContracts.Enums;

namespace TradingPlatform.EntityContracts.Complaint
{
    public class ComplaintReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public ComplaintType Type { get; set; }
        public int ProductId { get; set; }
    }
}
