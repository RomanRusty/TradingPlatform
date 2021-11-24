﻿using System.Collections.Generic;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.EntityContracts.ApplicationUser
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