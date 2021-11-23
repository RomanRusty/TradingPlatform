using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Contracts.Home
{
    public class IndexViewModel
    {
      public  List<List<ProductReadDto>> Products { get; set; }
    }
}
