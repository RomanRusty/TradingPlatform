using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Complaints;
using TradingPlatform.EntityContracts.Complaint;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IComplaintService
    {
        Task<IEnumerable<ComplaintReadDto>> IndexAsync();
        Task<ComplaintReadDto> DetailsAsync(int id);
        ComplaintCreateViewModel CreateGetAsync(int productId);
        Task CreatePostAsync(ComplaintCreateDto complaintCreateDto);
        Task<ComplaintEditViewModel> EditGetAsync(int id);
        Task EditPostAsync(int id, ComplaintCreateDto complaintCreateDto);

        Task DeleteAsync(int id);
    }
}
