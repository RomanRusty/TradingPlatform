using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityExceptions.Product;

namespace TradingPlatform.DatabaseService.Services
{
    internal class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
                throw new ProductNotFoundException("Product with such id does not exsist");
            }
            try
            {
                var product = _mapper.Map<Product>(productCreateDto);
                await _repository.Products.UpdateAsync(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.Products.Exists(id))
                {
                    throw new ProductAlreadyExistsException("Product already exists");
                }
            }
        }
        public async Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);

            await _repository.Products.AddAsync(product);

            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return productReadDto;
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _repository.Products.FindByIdAsync(id);
            if (product == null)
            {
                throw new ProductNotFoundException("Product with such id does not exsists");
            }
            _repository.Products.Remove(product);
        }
    }
}
