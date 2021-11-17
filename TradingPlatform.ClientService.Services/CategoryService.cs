using AutoMapper;
using ExampleWebApplication.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityExceptions.Category;

namespace TradingPlatform.ClientService.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(IOptions<AppConfiguration> config, HttpClient client) : base(config, client)
        {
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi");
            var categoriesDto = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryReadDto>>(categoriesJson);
            return categoriesDto;
        }
        public async Task<CategoryReadDto> GetByIdAsync(int id)
        {
            var categoryJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var categoryDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(categoryJson);

            if (categoryDto == null)
            {
                throw new CategoryNotFoundException("Category not found");
            }
            return categoryDto;
        }
        public async Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto)
        {
            if (id != categoryCreateDto.Id)
            {
                throw new CategoryNotFoundException("Category with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _client.PutAsync("api/CategoriesApi/" + id, data);

        }
        public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var categoryJson = await _client.PostAsync("api/CategoriesApi", data);

            var categoriesDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(await categoryJson.Content.ReadAsStreamAsync());
            return categoriesDto;
        }
        public async Task DeleteAsync(int id)
        {
            var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var categoryDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(categoriesJson);
            if (categoryDto == null)
            {
                throw new CategoryNotFoundException("Category with such id does not exsists");
            }
        }
    }
}
