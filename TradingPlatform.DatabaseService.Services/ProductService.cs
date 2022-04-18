using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityExceptions.Product;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace TradingPlatform.DatabaseService.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;
        public ProductService(IRepositoryManager repository, IMapper mapper, IHostingEnvironment environment)
        {
            _repository = repository;
            _mapper = mapper;
            _environment= environment;
        }
        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var products = await _repository.Products.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductReadDto>>(products);
            return productsDto;
        }
        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var product = await _repository.Products.FindByIdAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException("Product not found");
            }
            var productsDto = _mapper.Map<ProductReadDto>(product);
            return productsDto;
        }
        public async Task UpdateAsync(int id, ProductCreateDto productCreateDto)
        {
            if (id != productCreateDto.Id)
            {
                throw new ProductNotFoundException("Product with such id does not exists");
            }
            try
            {
                var product = _mapper.Map<Product>(productCreateDto);
                await _repository.Products.UpdateAsync(product);
            }
            catch (Exception)
            {
                if (await _repository.Products.ExistsAsync(id))
                {
                    throw new ProductAlreadyExistsException("Product already exists");
                }
            }
        }
        public async Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            product.Category =await _repository.Categories.FindByIdAsync(product.Category.Id);
            await _repository.Products.AddAsync(product);

            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return productReadDto;
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _repository.Products.FindByIdAsync(id);
            if (product == null)
            {
                throw new ProductNotFoundException("Product with such id does not exists");
            }
            await _repository.Products.RemoveAsync(product);
        }
        public async Task<IEnumerable<ProductReadDto>> FindBySearchAsync(ProductSearchDto productSearchDto)
        {
            var products = await _repository.Products.FindAllAsync(item =>
             (string.IsNullOrEmpty(productSearchDto.Name) || item.Name.Contains(productSearchDto.Name)) &&
             (string.IsNullOrEmpty(productSearchDto.CategoryName) || item.Category.Name.Contains(productSearchDto.CategoryName)) &&
             (productSearchDto.MinPrice == null)||item.Price >= productSearchDto.MinPrice &&
             (productSearchDto.MaxPrice == null) || item.Price <= productSearchDto.MaxPrice);

            var productsReadDto = _mapper.Map<IEnumerable<ProductReadDto>>(products);
            return productsReadDto;
        }
    }
}
