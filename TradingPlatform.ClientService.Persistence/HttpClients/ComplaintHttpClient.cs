using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Complaint;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class ComplaintHttpClient:HttpClientBase,IComplaintHttpClient
    {
        private readonly ILogger<ComplaintHttpClient> _logger;
        public ComplaintHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILoggerFactory loggerFactory, ITokenManager tokenManager, IHttpContextAccessor contextAccessor) :
            base(config, client, tokenManager, contextAccessor)
        {
            _logger = loggerFactory is not null ? loggerFactory.CreateLogger<ComplaintHttpClient>() : throw new ArgumentNullException(nameof(loggerFactory));
            _apiName = "ComplaintsApi";
        }

        public async Task<IEnumerable<ComplaintReadDto>> GetAllAsync()
        {
            var response = await GetRequestAsync(_apiName);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<ComplaintReadDto>>(response);
        }

        public async Task<ComplaintReadDto> GetByIdAsync(int id)
        {
            var response = await GetRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var complaintDto = await DeserializeAsync<ComplaintReadDto>(response);

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
            var response = await PutRequestAsync(_apiName + "/" + id, data);
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
            var response = await PostRequestAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<ComplaintReadDto>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var response = await DeleteRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<IEnumerable<ComplaintReadDto>> FindBySearchAsync(ComplaintSearchDto complaintSearchDto)
        {
            var jsonContent = JsonSerializer.Serialize(complaintSearchDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PostRequestAsync(_apiName + "/by-filter", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<ComplaintReadDto>>(response);
        }
    }
}
