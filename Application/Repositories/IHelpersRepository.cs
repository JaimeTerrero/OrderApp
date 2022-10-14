using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IHelpersRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllWithIncludeAsync(List<string> property);
    }
}
