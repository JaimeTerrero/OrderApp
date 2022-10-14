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
    public class OrderRepository : IHelpersRepository<Order>
    {
        private readonly ApplicationContext _dbContext;
        public OrderRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task DeleteAsync(Order order)
        {
            _dbContext.Set<Order>().Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Set<Order>().ToListAsync();
        }

        public async Task<List<Order>> GetAllWithIncludeAsync(List<string> property)
        {
            var query = _dbContext.Set<Order>().AsQueryable();

            foreach(var properties in property)
            {
                query = query.Include(properties);
            }

            return await query.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Order>().FindAsync(id);
        }

        public async Task UpdateAsync(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
