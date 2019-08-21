using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDemo.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        void Create(T entity);

        Task CreateAsync(T entity);

        void CreateRange(IEnumerable<T> entities);

        Task CreateRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void UpdateRange(IEnumerable<T> entities);

        Task UpdateRangeAsync(IEnumerable<T> entities);

        void Delete(T entity);

        Task DeleteAsync(T entity);

        void DeleteRange(IEnumerable<T> entities);

        Task DeleteRangeAsync(IEnumerable<T> entities);

        int Count(Func<T, bool> predicate);

        bool Any(Func<T, bool> predicate);

        bool Any();
    }
}
