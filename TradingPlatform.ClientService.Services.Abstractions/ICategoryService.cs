using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> IndexAsync();
        Task<CategoryReadDto> DetailsAsync(int id);
    }
}
