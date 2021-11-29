using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Services
{
    public class HomeService : ServiceBase, IHomeService
    {
        public HomeService(IHttpClientManager clientManager) : base(clientManager)
        {
        }
        public async Task<IndexViewModel> IndexAsync(ClaimsPrincipal user, string sortOrder, string currentFilter, string searchString, string category, int page)
        {
            int rowsOnPage = 5;
            int itemsInRow = 3;
            int itemsOnPage = rowsOnPage * itemsInRow;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IEnumerable<ProductReadDto> products;
            if (category == null)
            {
                products = await _client.ProductHttpClient.GetAllAsync();
            }
            else
            {
                products =await _client.ProductHttpClient.FindBySearchAsync(new ProductSearchDto() { CategoryName=category });
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(item => item.Name.Contains(searchString));
            }
            products = sortOrder switch
            {
                "price_desc" => products.OrderByDescending(s => s.Price),
                "date" => products.OrderBy(s => s.CreationDate),
                "date_desc" => products.OrderByDescending(s => s.CreationDate),
                _ => products.OrderBy(s => s.Price),
            };

            IEnumerable<ProductReadDto> sortedProducts = products.Skip((page - 1) * itemsOnPage).Take(itemsOnPage).ToList();
            
            SelectList orderSelectList = null;
            if (user.Identity.IsAuthenticated)
            {
                IEnumerable<OrderReadDto> orders = await _client.OrderHttpClient.FindBySearchAsync(new OrderSearchDto()
                { 
                    Status=EntityContracts.Enums.OrderStatus.Selecting,
                    CustumerName= user.Identity.Name 
                });
                orderSelectList = new SelectList(orders, "Id", "Name");
            }
            return new IndexViewModel()
            {
                Products = ToJaggedArray(products, itemsInRow),
                ItemPagination=new ItemPaginationViewModel(true, products.Count(), page, itemsOnPage, 5) 
                {
                    CurrentSort=sortOrder,
                    CurrentFilter=searchString,
                },
                AvailableOrdersSelectList=orderSelectList,
            };
        }
        //public async Task<IndexViewModel> SortAsync()
        //{

        //}

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
