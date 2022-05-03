using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TradingPlatform.ClientService.Contracts.Home;
using TradingPlatform.ClientService.Contracts.Modals;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Services
{
    public class HomeService : ServiceBase, IHomeService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public HomeService(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper, UserManager<ApplicationUser> userManager) : base(client, contextAccessor, mapper)
		{
			_userManager = userManager;
		}

		public async Task BecomeSeller()
		{
			var user=await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
			if(await _userManager.IsInRoleAsync(user, UserRoles.Custumer))
			{
				await _userManager.RemoveFromRoleAsync(user, UserRoles.Custumer);
				await _userManager.AddToRoleAsync(user, UserRoles.Seller);
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
			if (searchString is not null)
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
		
			List<string> SearchStrings=new List<string>()
			{
				"Date",
				"Price"
			};
			SelectList sortOrderSelectList;
			if (sortOrder is null)
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
			};
			return indexViewModel;
		}
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
