using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.ClientService.Persistence.Configurations;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public abstract class HttpClientBase
    {
        private readonly HttpClient _client;
        protected string _apiName;
        private readonly JsonSerializerOptions _options;
        private readonly ITokenManager _tokenManager;
        private readonly IHttpContextAccessor _contextAccessor;
       public HttpClientBase(IOptions<AppConfiguration> config, HttpClient client,ITokenManager tokenManager, IHttpContextAccessor contextAccessor)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri(config?.Value?.DatabaseApiUrl ?? throw new ArgumentNullException(nameof(config)));
            _tokenManager= tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }
        protected async Task<T> DeserializeAsync<T>(HttpResponseMessage message)
        {
            return await JsonSerializer.DeserializeAsync<T>(await message.Content.ReadAsStreamAsync(), _options);
        }
        protected async Task<HttpResponseMessage> GetRequestAsync(string requestString)
        {
            await UpdateHeaderParams();
            return await _client.GetAsync(requestString);
        }
        protected async Task<HttpResponseMessage> PostRequestAsync(string requestString,HttpContent content)
        {
            await UpdateHeaderParams();
            return await _client.PostAsync(requestString, content);
        }
        protected async Task<HttpResponseMessage> PutRequestAsync(string requestString, HttpContent content)
        {
            await UpdateHeaderParams();
            return await _client.PutAsync(requestString, content);
        }
        protected async Task<HttpResponseMessage> DeleteRequestAsync(string requestString)
        {
            await UpdateHeaderParams();
            return await _client.DeleteAsync(requestString);
        }
        private async Task UpdateHeaderParams()
        {
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var token= await _tokenManager.GenerateToken(_contextAccessor.HttpContext.User.Identity.Name);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = null;
            }
        }
    }
}