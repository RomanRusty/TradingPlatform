using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TradingPlatform.ClientService.Contracts.Products;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityContracts.Enums;
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityContracts.ProductImage;
using TradingPlatform.EntityExceptions.Product;

namespace TradingPlatform.ClientService.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper) : base(client, contextAccessor, mapper)
        {
        }

        public async Task<IEnumerable<ProductReadDto>> IndexAsync()
        {
            return await _client.ProductHttpClient.GetAllAsync();
        }
        public async Task<ProductCreateViewModel> CreateGetAsync()
        {
            var productCreateViewModel = new ProductCreateViewModel()
            {
                Categories = new SelectList(await _client.CategoryHttpClient.GetAllAsync(), "Id", "Name")
            };
            return productCreateViewModel;
        }
        public async Task CreatePostAsync(ProductCreateViewModel productCreateViewModel)
        {
            var productCreateDto = productCreateViewModel.ProductCreate;

            productCreateDto.ImageThumbnail = FormFileToImage(productCreateViewModel.ImageThumbnail);
            productCreateDto.Images = FromFilesToImages(productCreateViewModel.Images);

            await _client.ProductHttpClient.CreateAsync(productCreateDto);
        }
        public async Task<ProductDetailsViewModel> DetailsAsync(int id)
        {
            var orders = await _client.OrderHttpClient.FindBySearchAsync(
                    new OrderSearchDto() { Status = OrderStatus.Selecting });
            if (orders is null) 
            {
                orders = new List<OrderReadDto>();
            }
            var product = await _client.ProductHttpClient.GetByIdAsync(id);
            if(product is null)
            {
                throw new ProductNotFoundException("Product with such id does not exists");
            }
            return  new ProductDetailsViewModel() {
                Product = product,
                AvailableOrdersSelectList = new SelectList(orders, "Id", "Name"),
            };
        }

        public Task<ProductReadDto> EditGetAsync(int id)
        {
            var product = _client.ProductHttpClient.GetByIdAsync(id);
            if (product == null)
            {
                throw new ProductNotFoundException("Product not found");
            }
            return product;
        }
        public async Task EditPostAsync(int id, ProductCreateDto productCreateDto)
        {
            await _client.ProductHttpClient.UpdateAsync(id, productCreateDto);
        }
        public async Task DeleteAsync(int id)
        {
            await _client.ProductHttpClient.DeleteAsync(id);
        }
        private List<ProductImageCreateDto> FromFilesToImages(IEnumerable<IFormFile> files)
        {
            List<ProductImageCreateDto> images = new();
            foreach (var file in files)
            {
                images.Add(FormFileToImage(file));
            }
            return images;
        }
        private ProductImageCreateDto FormFileToImage(IFormFile file)
        {
            if (file.Length > 0)
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                var image = new ProductImageCreateDto()
                {
                    Name = file.Name,
                    Extension = file.ContentType,
                    Data = ms.ToArray(),
                };
                return image;
            }
            else
            {
                return null;
            }
              
        }
    }
}
