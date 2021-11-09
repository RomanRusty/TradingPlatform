using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.Contracts.ProductOrder;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Domain.Exceptions.ProductOrder;
using TradingPlatform.Domain.Repository_interfaces;
using TradingPlatform.Services.Abstractions;

namespace TradingPlatform.Services
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
            var productOrdersDto = _mapper.Map<IEnumerable<ProductOrderReadDto>>(productOrders);
            return productOrdersDto;
        }
        public async Task<ProductOrderReadDto> GetByIdAsync(int id)
        {
            var productOrders = await _repository.ProductOrders.FindByIdAsync(id);

            if (productOrders == null)
            {
                throw new ProductOrderNotFoundException("ProductOrder not found");
            }
            var productOrdersDto = _mapper.Map<ProductOrderReadDto>(productOrders);
            return productOrdersDto;
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
            catch (DbUpdateConcurrencyException)
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

            await _repository.ProductOrders.AddAsync(productOrder);

            var productOrderReadDto = _mapper.Map<ProductOrderReadDto>(productOrder);
            return productOrderReadDto;
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
