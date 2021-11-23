using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Home;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Services
{
    public class HomeService : ServiceBase, IHomeService
    {
        public HomeService(IHttpClientManager client) : base(client)
        {
        }
        public async Task<IndexViewModel> IndexAsync()
        {
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Products = ToJaggedArray(await _client.ProductHttpClient.GetAllAsync(), 3)
            };
            return indexViewModel;
        }

        //public async Task<CategoryReadDto> GetByIdAsync(int id)
        //{
        //    var categoryJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
        //    var categoryDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(categoryJson);

        //    if (categoryDto == null)
        //    {
        //        throw new CategoryNotFoundException("Category not found");
        //    }
        //    return categoryDto;
        //}
        //public async Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto)
        //{
        //    if (id != categoryCreateDto.Id)
        //    {
        //        throw new CategoryNotFoundException("Category with such id does not exsist");
        //    }

        //    var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
        //    var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //    await _client.PutAsync("api/CategoriesApi/" + id, data);

        //}
        //public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        //{
        //    var jsonContent = JsonSerializer.Serialize(categoryCreateDto);
        //    var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //    var categoryJson = await _client.PostAsync("api/CategoriesApi", data);

        //    var categoriesDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(await categoryJson.Content.ReadAsStreamAsync());
        //    return categoriesDto;
        //}
        //public async Task DeleteAsync(int id)
        //{
        //    var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
        //    var categoryDto = await JsonSerializer.DeserializeAsync<CategoryReadDto>(categoriesJson);
        //    if (categoryDto == null)
        //    {
        //        throw new CategoryNotFoundException("Category with such id does not exsists");
        //    }
        //}

            private List<List<ProductReadDto>> ToJaggedArray(IEnumerable<ProductReadDto> array, int cols)
            {
                int index = 0;
                List<List<ProductReadDto>> jaggedArray = new();
                for (int i = 0; i < Math.Ceiling((double)array.Count() / cols); i++)
                {
                    List<ProductReadDto> rows = new();
                    for (int j = 0; j < cols; j++)
                    {
                        if (index >= array.Count()) break;
                        rows.Add(array.ElementAt(index++));
                    }
                    jaggedArray.Add(rows);
                }
                return jaggedArray;
            }
    }
}
