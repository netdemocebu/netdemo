using NetDemo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDemo.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MyDbContext _context;

        public Repository(MyDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public int Count(Func<T, Boolean> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public virtual void Create(T entity)
        {
            _context.Add(entity);

            Save();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);

            await SaveAsync();
        }

        public virtual void CreateRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);

            Save();
        }

        public virtual async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);

            await SaveAsync();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            Save();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await SaveAsync();
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);

            Save();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);

            await SaveAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);

            Save();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);

            await SaveAsync();
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);

            Save();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);

            await SaveAsync();
        }

        public bool Any(Func<T, bool> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public bool Any()
        {
            return _context.Set<T>().Any();
        }

        protected void Save() => _context.SaveChanges();

        protected async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
