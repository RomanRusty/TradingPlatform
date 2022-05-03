using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IPaymentService
    {
        Task<string> CreateAsync(int orderId);
    }
}