﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.Contracts.Order;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Domain.Exceptions.Order;
using TradingPlatform.Domain.Repository_interfaces;
using TradingPlatform.Services.Abstractions;

namespace TradingPlatform.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            var orders = await _repository.Orders.GetAllAsync();
            var prdersDto = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return prdersDto;
        }
        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var order = await _repository.Orders.FindByIdAsync(id);

            if (order == null)
            {
                throw new OrderNotFoundException("Order not found");
            }
            var ordersDto = _mapper.Map<OrderReadDto>(order);
            return ordersDto;
        }
        public async Task UpdateAsync(int id, OrderCreateDto orderCreateDto)
        {
            if (id != orderCreateDto.Id)
            {
                throw new OrderNotFoundException("Order with such id does not exsist");
            }
            try
            {
                var order = _mapper.Map<Order>(orderCreateDto);
                await _repository.Orders.UpdateAsync(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.Orders.Exists(id))
                {
                    throw new OrderAlreadyExistsException("Order already exists");
                }
            }
        }
        public async Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);

            await _repository.Orders.AddAsync(order);

            var orderReadDto = _mapper.Map<OrderReadDto>(order);
            return orderReadDto;
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _repository.Orders.FindByIdAsync(id);
            if (order == null)
            {
                throw new OrderNotFoundException("Order with such id does not exsists");
            }
            _repository.Orders.Remove(order);
        }
    }
}