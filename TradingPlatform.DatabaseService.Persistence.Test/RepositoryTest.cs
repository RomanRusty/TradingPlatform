using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Domain.Repository_interfaces;
using TradingPlatform.DatabaseService.Persistence.Database;
using TradingPlatform.DatabaseService.Persistence.Repository;
using Xunit;


namespace TradingPlatform.DatabaseService.Persistence.Test
{
    public class RepositoryTest
    {
        private readonly IGenericRepository<Category> _repository;
        [Fact]
        public async Task Test1()
        {
            var category = new Category() { Name = "Category1", Description = "Descr1" };
            await _repository.AddAsync(category);
            var actualCategory =( await _repository.FindAllAsync(t=>t.Name== "Category1")).FirstOrDefault();
            Assert.NotNull(actualCategory);
            Assert.Equal(category.Name, actualCategory.Name);
            Assert.Equal(category.Description, actualCategory.Description);
        }
        public RepositoryTest()
        {
            var options = new DbContextOptionsBuilder<RepositoryDbContext>().UseInMemoryDatabase("CategoriesDb").Options;
            RepositoryDbContext context = new(options);
            _repository = new EFGenericRepository<Category>(context);
        }
    }
}
