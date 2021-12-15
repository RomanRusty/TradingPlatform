﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Contracts.Modals
{
    public class AddItemToCartViewModel
    {
        public ProductReadDto Product { get; set; }
        public SelectList Orders { get; set; }
        public ProductOrderCreateDto ProductOrder { get; set; }
    }
}
