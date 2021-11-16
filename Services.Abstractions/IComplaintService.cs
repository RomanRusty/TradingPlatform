using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Contracts.Complaint;

namespace TradingPlatform.DatabaseService.Services.Abstractions
{
    public interface IComplaintService
    {
        Task<IEnumerable<ComplaintReadDto>> GetAllAsync();
        Task<ComplaintReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, ComplaintCreateDto productReadDto);
        Task<ComplaintReadDto> CreateAsync(ComplaintCreateDto productCreateDto);
        Task DeleteAsync(int id);
    }
}
