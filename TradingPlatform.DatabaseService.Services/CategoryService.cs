using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityExceptions.Category;

namespace TradingPlatform.DatabaseService.Services
{
    public class CategoryService : ICategoryService
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
            return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
        }
        public async Task<CategoryReadDto> GetByIdAsync(int id)
        {
            var category = await _repository.Categories.FindByIdAsync(id);

            if (category == null)
            {
                throw new CategoryNotFoundException("Category not found");
            }
            return _mapper.Map<CategoryReadDto>(category);
        }
        public async Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto)
        {
            if (id != categoryCreateDto.Id)
            {
                throw new CategoryNotFoundException("Category with such id does not exists");
            }
            try
            {
                var category = _mapper.Map<Category>(categoryCreateDto);
                await _repository.Categories.UpdateAsync(category);
            }
            catch (Exception)
            {
                if (await _repository.Categories.ExistsAsync(id))
                {
                    throw new CategoryNotFoundException("Category already exists");
                }
            }
        }
        public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);

            await _repository.Categories.AddAsync(category);

            return _mapper.Map<CategoryReadDto>(category);
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _repository.Categories.FindByIdAsync(id);
            if (category == null)
            {
                throw new CategoryNotFoundException("Category with such id does not exists");
            }
            await _repository.Categories.RemoveAsync(category);
        }
        public async Task<IEnumerable<CategoryReadDto>> FindBySearchAsync(CategorySearchDto categorySearchDto)
        {
            var categories = await _repository.Categories.FindAllAsync(item =>
            (string.IsNullOrEmpty(categorySearchDto.Name) || item.Name.Contains(categorySearchDto.Name)) &&
            (string.IsNullOrEmpty(categorySearchDto.Description) || item.Name.Contains(categorySearchDto.Description)));

            return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
        }
    }
}
