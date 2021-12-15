using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.ProductOrder;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityExceptions.ProductOrder;
using System;

namespace TradingPlatform.DatabaseService.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductOrderService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductOrderReadDto>> GetAllAsync()
        {
            var productOrders = await _repository.ProductOrders.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductOrderReadDto>>(productOrders);
        }
        public async Task<ProductOrderReadDto> GetByIdAsync(int id)
        {
            var productOrders = await _repository.ProductOrders.FindByIdAsync(id);

            if (productOrders == null)
            {
                throw new ProductOrderNotFoundException("ProductOrder not found");
            }
            return _mapper.Map<ProductOrderReadDto>(productOrders);
        }
        public async Task UpdateAsync(int id, ProductOrderCreateDto productOrderCreateDto)
        {
            if (id != productOrderCreateDto.Id)
            {
                throw new ProductOrderNotFoundException("ProductOrder with such id does not exsist");
            }
            try
            {
                var productOrder = _mapper.Map<ProductOrder>(productOrderCreateDto);
                await _repository.ProductOrders.UpdateAsync(productOrder);
            }
            catch (Exception)
            {
                if (_repository.ProductOrders.Exists(id))
                {
                    throw new ProductOrderAlreadyExistsException("ProductOrder already exists");
                }
            }
        }
        public async Task<ProductOrderReadDto> CreateAsync(ProductOrderCreateDto ProductOrderCreateDto)
        {
            var productOrder = _mapper.Map<ProductOrder>(ProductOrderCreateDto);
            productOrder.Product ??= await _repository.Products.FindByIdAsync(ProductOrderCreateDto.ProductIdSelect);
            productOrder.Order ??= await _repository.Orders.FindByIdAsync(ProductOrderCreateDto.OrderIdSelect);
            await _repository.ProductOrders.AddAsync(productOrder);

            return _mapper.Map<ProductOrderReadDto>(productOrder);
        }
        public async Task DeleteAsync(int id)
        {
            var productOrder = await _repository.ProductOrders.FindByIdAsync(id);
            if (productOrder == null)
            {
                throw new ProductOrderNotFoundException("ProductOrder with such id does not exsists");
            }
            _repository.ProductOrders.Remove(productOrder);
        }
    }
}
