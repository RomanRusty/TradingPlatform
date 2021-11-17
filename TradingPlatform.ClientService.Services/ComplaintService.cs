using AutoMapper;
using ExampleWebApplication.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.EntityExceptions.Complaint;

namespace TradingPlatform.ClientService.Services
{
    public class ComplaintService : ServiceBase, IComplaintService
    {
        public ComplaintService(IOptions<AppConfiguration> config, HttpClient client) : base(config, client)
        {
        }

        public async Task<IEnumerable<ComplaintReadDto>> GetAllAsync()
        {
            var complaintsJson = await _client.GetStreamAsync("api/CategoriesApi");
            var complaintsDto = await JsonSerializer.DeserializeAsync<IEnumerable<ComplaintReadDto>>(complaintsJson);
            return complaintsDto;
        }
        public async Task<ComplaintReadDto> GetByIdAsync(int id)
        {
            var complaintJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var complaintDto = await JsonSerializer.DeserializeAsync<ComplaintReadDto>(complaintJson);

            if (complaintDto == null)
            {
                throw new ComplaintNotFoundException("Complaint not found");
            }
            return complaintDto;
        }
        public async Task UpdateAsync(int id, ComplaintCreateDto complaintCreateDto)
        {
            if (id != complaintCreateDto.Id)
            {
                throw new ComplaintNotFoundException("Complaint with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(complaintCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _client.PutAsync("api/CategoriesApi/" + id, data);

        }
        public async Task<ComplaintReadDto> CreateAsync(ComplaintCreateDto complaintCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(complaintCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var complaintJson = await _client.PostAsync("api/CategoriesApi", data);

            var categoriesDto = await JsonSerializer.DeserializeAsync<ComplaintReadDto>(await complaintJson.Content.ReadAsStreamAsync());
            return categoriesDto;
        }
        public async Task DeleteAsync(int id)
        {
            var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var complaintDto = await JsonSerializer.DeserializeAsync<ComplaintReadDto>(categoriesJson);
            if (complaintDto == null)
            {
                throw new ComplaintNotFoundException("Complaint with such id does not exsists");
            }
        }
    }
}
