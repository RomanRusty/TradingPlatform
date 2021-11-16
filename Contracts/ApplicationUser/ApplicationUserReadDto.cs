using System.Collections.Generic;
using TradingPlatform.DatabaseService.Contracts.Order;

namespace TradingPlatform.DatabaseService.Contracts.ApplicationUser
{
    public class ApplicationUserReadDto
    {
        public string Id { get; set; } 
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        //public IEnumerable<OrderReadDto> Orders { get; set; }

    }
}
