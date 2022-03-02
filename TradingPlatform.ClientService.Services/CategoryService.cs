﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(IHttpClientManager client, IHttpContextAccessor contextAccessor) : base(client, contextAccessor)
        {
        }

        public async Task<CategoryReadDto> DetailsAsync(int id)
        {
            return await _client.CategoryHttpClient.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CategoryReadDto>> IndexAsync()
        {
            return await _client.CategoryHttpClient.GetAllAsync();
        }
    }
}