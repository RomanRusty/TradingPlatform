using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Category;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class CategoryHttpClient : HttpClientBase, ICategoryHttpClient
    {

        private readonly ILogger<CategoryHttpClient> _logger;
        public CategoryHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILoggerFactory loggerFactory, ITokenManager tokenManager, IHttpContextAccessor contextAccessor) :
            base(config, client, tokenManager,contextAccessor)
        {
            _logger = loggerFactory is not null ? loggerFactory.CreateLogger< CategoryHttpClient>(): throw new ArgumentNullException(nameof(loggerFactory));
            _apiName = "CategoriesApi";
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            var response = await GetRequestAsync(_apiName);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<CategoryReadDto>>(response);
        }

        public async Task<CategoryReadDto> GetByIdAsync(int id)
        {
            var response = await GetRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<CategoryReadDto>(response);
        }
        public async Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto)
        {
            if (id != categoryCreateDto.Id)
            {
                throw new CategoryNotFoundException("Category with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PutRequestAsync(_apiName + "/" + id, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PostRequestAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<CategoryReadDto>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var response = await DeleteRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
            var categoryDto = await DeserializeAsync<CategoryReadDto>(response);
            if (categoryDto == null)
            {
                throw new CategoryNotFoundException("Complaint with such id does not exsists");
            }
        }
        public async Task<IEnumerable<CategoryReadDto>> FindBySearchAsync(CategorySearchDto categorySearchDto)
        {
            var jsonContent = JsonSerializer.Serialize(categorySearchDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await PostRequestAsync(_apiName + "/by-filter", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<CategoryReadDto>>(response);
        }
        private void CheckStatusCode(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.Created:
                    break;
                case HttpStatusCode.Accepted:
                    break;
                case HttpStatusCode.NonAuthoritativeInformation:
                    break;
                case HttpStatusCode.NoContent:
                    break;
                case HttpStatusCode.ResetContent:
                    break;
                case HttpStatusCode.PartialContent:
                    break;
                case HttpStatusCode.Redirect:
                    break;
                case HttpStatusCode.RedirectMethod:
                    break;
                case HttpStatusCode.TemporaryRedirect:
                    break;
                case HttpStatusCode.PermanentRedirect:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.PaymentRequired:
                    break;
                case HttpStatusCode.Forbidden:
                    break;
                case HttpStatusCode.NotFound:
                    break;
                default:
                    throw new Exception("Something went wrong");
            }
        }
    }
}
