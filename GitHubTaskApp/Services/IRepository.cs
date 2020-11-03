using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubTaskApp.Services
{
    public interface IRepository<T, K> 
        where T : class
    {
        Task<IEnumerable<T>> SearchAsync(K key);
        Task AddRangeAsync(IEnumerable<T> items);
        Task SaveAsync();
    }
}
