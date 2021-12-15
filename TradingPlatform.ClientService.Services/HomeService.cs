using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts;
using TradingPlatform.ClientService.Contracts.Home;
using TradingPlatform.ClientService.Contracts.Modals;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Services
{
	public class HomeService : ServiceBase, IHomeService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public HomeService(IHttpClientManager clientManager, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager) : base(clientManager, contextAccessor)
		{
			_userManager = userManager;
		}

		public async Task BecomeSeller()
		{
			var user=await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
			if(await _userManager.IsInRoleAsync(user, "Custumer"))
			{
				await _userManager.RemoveFromRoleAsync(user, "Custumer");
				await _userManager.AddToRoleAsync(user, "Seller");
			}

		}

		public async Task<IndexViewModel> IndexAsync(string sortOrder,string sortDirection, string currentFilter, string searchString, string category, int page)
		{
			int rowsOnPage = 2;
			int itemsInRow = 3;
			int itemsOnPage = rowsOnPage * itemsInRow;
			var user = _contextAccessor.HttpContext.User;
			sortDirection ??= "Desc";
			sortOrder ??= "Price";
			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			IEnumerable<ProductReadDto> products = await _client.ProductHttpClient.FindBySearchAsync(new ProductSearchDto() { CategoryName = category,Name=searchString });
			int totalProductCount=0;
			if (products is null)
			{
				products = new List<ProductReadDto>();
			}
			else
			{
				string sortQuery = sortOrder + sortDirection;
				products = sortQuery switch
				{
					"PriceDesc" => products.OrderByDescending(s => s.Price),
					"PriceAsc" => products.OrderBy(s => s.Price),
					"DateDesc" => products.OrderByDescending(s => s.CreationDate),
					"DateAsc" => products.OrderBy(s => s.CreationDate),
					_ => products
				};
				totalProductCount= products.Count();
				products = products.Skip((page - 1) * itemsOnPage).Take(itemsOnPage).ToList();
			}
			
			SelectList orderSelectList = null;
			if (user.Identity.IsAuthenticated)
			{
				IEnumerable<OrderReadDto> orders = await _client.OrderHttpClient.FindBySearchAsync(new OrderSearchDto()
				{
					Status = EntityContracts.Enums.OrderStatus.Selecting,
					CustumerName = user.Identity.Name
				});
				if (orders != null)
				{
					orderSelectList = new SelectList(orders, "Id", "Name");
				}
			}
			List<string> SearchStrings=new List<string>()
			{
				"Date",
				"Price"
			};
			SelectList sortOrderSelectList;
			if (sortOrder == null)
			{
				sortOrderSelectList = new SelectList(SearchStrings, SearchStrings[0]);
			}
			else
			{
				sortOrderSelectList = new SelectList(SearchStrings, sortOrder);
			}


			var indexViewModel = new IndexViewModel()
			{
				Products = ToJaggedArray(products, itemsInRow),
				ItemPagination = new ItemPaginationViewModel(true, totalProductCount, page, itemsOnPage, 5)
				{
					SortOrder = sortOrder,
					SortDirection = sortDirection,
					CurrentFilter = searchString,
					SortOrderSelectList = sortOrderSelectList,
					Category = category,
				},
				AvailableOrdersSelectList = orderSelectList,
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
