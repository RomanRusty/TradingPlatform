using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Contracts.Category;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Exceptions.Category;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;

namespace TradingPlatform.DatabaseService.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            var categories = await _repository.Categories.GetAllAsync();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
            return categoriesDto;
        }
        public async Task<CategoryReadDto> GetByIdAsync(int id)
        {
            var category = await _repository.Categories.FindByIdAsync(id);

            if (category == null)
            {
                throw new CategoryNotFoundException("Category not found");
            }
            var categoriesDto = _mapper.Map<CategoryReadDto>(category);
            return categoriesDto;
        }
        public async Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto)
        {
            if (id != categoryCreateDto.Id)
            {
                throw new CategoryNotFoundException("Category with such id does not exsist");
            }
            try
            {
                var category = _mapper.Map<Category>(categoryCreateDto);
                await _repository.Categories.UpdateAsync(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.Categories.Exists(id))
                {
                    throw new CategoryNotFoundException("Category already exists");
                }
            }
        }
        public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);

            await _repository.Categories.AddAsync(category);

            var categoryReadDto = _mapper.Map<CategoryReadDto>(category);
            return categoryReadDto;
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _repository.Categories.FindByIdAsync(id);
            if (category == null)
            {
                throw new CategoryNotFoundException("Category with such id does not exsists");
            }
            _repository.Categories.Remove(category);
        }
    }
}
