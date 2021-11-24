﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Category;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class CategoryHttpClient : HttpClientBase, ICategoryHttpClient
    {

        private readonly ILogger<CategoryHttpClient> _logger;
        public CategoryHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILogger<CategoryHttpClient> logger) : base(config, client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("CategoriesApi");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<List<CategoryReadDto>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<CategoryReadDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("CategoriesApi" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<CategoryReadDto>(await response.Content.ReadAsStreamAsync());
        }
        public async Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto)
        {
            if (id != categoryCreateDto.Id)
            {
                throw new CategoryNotFoundException("Category with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("CategoriesApi" + id, data);
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
            var response = await _client.PostAsync("CategoriesApiApi", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<CategoryReadDto>(await response.Content.ReadAsStreamAsync());
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _client.GetAsync("CategoriesApi" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
            var categoryDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(await response.Content.ReadAsStreamAsync());
            if (categoryDto == null)
            {
                throw new CategoryNotFoundException("Complaint with such id does not exsists");
            }
        }
    }
}