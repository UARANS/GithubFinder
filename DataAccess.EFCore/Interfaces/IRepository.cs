using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);

        void Remove(T id);
        void RemoveRange(IEnumerable<T> entities);
    }
}
