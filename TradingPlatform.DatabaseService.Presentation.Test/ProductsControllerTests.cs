using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityContracts.Product;
using Xunit;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace TradingPlatform.DatabaseService.Presentation.Test
{

    public class ProductsControllerTests
    {
        private HttpClient _client;

        public ProductsControllerTests()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string path = config.GetSection("DatabaseApiUrl").Value;
            _client = new HttpClient();
            _client.BaseAddress=new Uri(path) ;

        }
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfProducts()
        {
            
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<ProductReadDto>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(1, model.Count());
        }
    }
}
