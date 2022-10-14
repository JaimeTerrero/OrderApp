using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ProductRepository : IHelpersRepository<Product>
    {
        private readonly ApplicationContext _dbContext;
        public ProductRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _dbContext.Set<Product>().Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public async Task<List<Product>> GetAllWithIncludeAsync(List<string> property)
        {
            var query = _dbContext.Set<Product>().AsQueryable();

            foreach(var properties in property)
            {
                query = query.Include(properties);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public string GetSubjectName(int id)
        {
            return _dbContext.Set<Product>().FindAsync(id).Result.ProductName;
        }
    }
}
