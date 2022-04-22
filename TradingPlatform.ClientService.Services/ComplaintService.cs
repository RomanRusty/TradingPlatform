using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.ClientService.Contracts.Complaints;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.EntityContracts.Enums;
using TradingPlatform.EntityExceptions.Complaint;

namespace TradingPlatform.ClientService.Services
{
    public class ComplaintService : ServiceBase, IComplaintService
    {
        public ComplaintService(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper) : base(client, contextAccessor, mapper)
        {
        }

        public async Task<IEnumerable<ComplaintReadDto>> IndexAsync()
        {
            return await _client.ComplaintHttpClient.GetAllAsync();
        }
        public async Task<ComplaintReadDto> DetailsAsync(int id)
        {
            return await _client.ComplaintHttpClient.GetByIdAsync(id);
        }

        public ComplaintCreateViewModel CreateGetAsync(int productId)
        {
            return new ComplaintCreateViewModel()
            {
                ComplaintCreate = new ComplaintCreateDto(){ProductId = productId},
                ComplaintTypes = new SelectList(Enum.GetValues(typeof(ComplaintType)).Cast<ComplaintType>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList(), "Value", "Text")
            };
        }
        public async Task CreatePostAsync(ComplaintCreateDto complaintCreateDto)
        {
            complaintCreateDto.CreationDate = DateTime.Now.Date;
            await _client.ComplaintHttpClient.CreateAsync(complaintCreateDto);
        }
        public async Task DeleteAsync(int id)
        {
            await _client.ComplaintHttpClient.DeleteAsync(id);
        }

        public async Task EditPostAsync(int id, ComplaintCreateDto complaintCreateDto)
        {
            await _client.ComplaintHttpClient.UpdateAsync(id, complaintCreateDto);
        }

        public async Task<ComplaintCreateDto> EditGetAsync(int id)
        {
            var complaint = await _client.ComplaintHttpClient.GetByIdAsync(id);
            return _mapper.Map<ComplaintCreateDto>(complaint);
        }
    }
}
