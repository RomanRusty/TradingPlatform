using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityExceptions.Complaint;

namespace TradingPlatform.DatabaseService.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ComplaintService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ComplaintReadDto>> GetAllAsync()
        {
            var complaints = await _repository.Complaints.GetAllAsync();
            var complaintsDto = _mapper.Map<IEnumerable<ComplaintReadDto>>(complaints);
            return complaintsDto;
        }
        public async Task<ComplaintReadDto> GetByIdAsync(int id)
        {
            var complaint = await _repository.Complaints.FindByIdAsync(id);

            if (complaint == null)
            {
                throw new ComplaintNotFoundException("Complaint not found");
            }
            var complaintsDto = _mapper.Map<ComplaintReadDto>(complaint);
            return complaintsDto;
        }
        public async Task UpdateAsync(int id, ComplaintCreateDto complaintCreateDto)
        {
            if (id != complaintCreateDto.Id)
            {
                throw new ComplaintNotFoundException("Complaint with such id does not exsist");
            }
            try
            {
                var complaint = _mapper.Map<Complaint>(complaintCreateDto);
                await _repository.Complaints.UpdateAsync(complaint);
            }
            catch (Exception)
            {
                if (_repository.Complaints.Exists(id))
                {
                    throw new ComplaintAlreadyExistsException("Complaint already exists");
                }
            }
        }
        public async Task<ComplaintReadDto> CreateAsync(ComplaintCreateDto complaintCreateDto)
        {
            var complaint = _mapper.Map<Complaint>(complaintCreateDto);

            await _repository.Complaints.AddAsync(complaint);

            var complaintReadDto= _mapper.Map<ComplaintReadDto>(complaint);
            return complaintReadDto;
        }
        public async Task DeleteAsync(int id)
        {
            var complaint = await _repository.Complaints.FindByIdAsync(id);
            if (complaint == null)
            {
                throw new ComplaintNotFoundException("Complaint with such id does not exsists");
            }
            _repository.Complaints.Remove(complaint);
        }
    }
}
