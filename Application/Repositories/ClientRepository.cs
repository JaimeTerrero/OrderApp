using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ClientRepository : IHelpersRepository<Client>
    {
        private readonly ApplicationContext _dbContext;
        public ClientRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Client> AddAsync(Client client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(Client client)
        {
            _dbContext.Set<Client>().Remove(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _dbContext.Set<Client>().ToListAsync();
        }

        public async Task<List<Client>> GetAllWithIncludeAsync(List<string> property)
        {
            var query = _dbContext.Set<Client>().AsQueryable();

            foreach(var properties in property)
            {
                query = query.Include(properties);
            }

            return await query.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Client>().FindAsync(id);
        }

        public async Task UpdateAsync(Client client)
        {
            _dbContext.Entry(client).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public string GetClientName(int id)
        {
            return _dbContext.Set<Client>().FindAsync(id).Result.ClientName;
        }

        public string GetClientDirection(int id)
        {
            return _dbContext.Set<Client>().FindAsync(id).Result.ClientDirection;
        }
    }
}
