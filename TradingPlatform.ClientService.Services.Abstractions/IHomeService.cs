using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Home;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IHomeService
    {
        Task<IndexViewModel> IndexAsync(string sortOrder, string sortDirection, string currentFilter, string searchString, string category, int page);
        Task BecomeSeller();
    }
}
