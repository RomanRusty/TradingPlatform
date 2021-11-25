using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Complaint;

namespace TradingPlatform.ClientService.Domain.HttpInterfaces
{
    public interface IComplaintHttpClient
    {
        public Task<IEnumerable<ComplaintReadDto>> GetAllAsync();
        public Task<ComplaintReadDto> GetByIdAsync(int id);
        public Task UpdateAsync(int id, ComplaintCreateDto complaintCreateDto);
        public Task<ComplaintReadDto> CreateAsync(ComplaintCreateDto complaintCreateDto);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<ComplaintReadDto>> FindBySearchAsync(ComplaintSearchDto complaintSearchDto);
    }
}
