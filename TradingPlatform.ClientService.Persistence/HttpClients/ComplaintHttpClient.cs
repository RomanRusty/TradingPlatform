using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Complaint;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class ComplaintHttpClient:HttpClientBase,IComplaintHttpClient
    {
        private readonly ILogger<ComplaintHttpClient> _logger;
        public ComplaintHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILogger<ComplaintHttpClient> logger) : base(config, client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ComplaintReadDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("ComplaintsApi");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<List<ComplaintReadDto>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<ComplaintReadDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Complints" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var complaintDto = await JsonSerializer.DeserializeAsync<ComplaintReadDto>(await response.Content.ReadAsStreamAsync());

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
            var response = await _client.PutAsync("Complints" + id, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<ComplaintReadDto> CreateAsync(ComplaintCreateDto complaintCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(complaintCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("CategoriesApi", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<ComplaintReadDto>(await response.Content.ReadAsStreamAsync());
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _client.GetAsync("Categories" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
            var complaintDto = await JsonSerializer.DeserializeAsync<ComplaintReadDto>(await response.Content.ReadAsStreamAsync());
            if (complaintDto == null)
            {
                throw new ComplaintNotFoundException("Complaint with such id does not exsists");
            }
        }
    }
}
