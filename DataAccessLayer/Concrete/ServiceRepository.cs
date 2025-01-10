using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ServiceRepository<T> : IServiceRepository<T> where T: class
    {
        public GunlukIsBulContext _context { get; set; }
        public DbSet<T> _contextEntity => _context.Set<T>();

        public ServiceRepository(GunlukIsBulContext context)
        {
            _context = context;
        }

        public T? Get(int id)
        {
            return _contextEntity.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _contextEntity.ToList();
        }

        public IEnumerable<T> GetByFilter(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            IQueryable<T> query = _contextEntity;
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public async Task<bool> Add(T entity)
        {
            var result = await _contextEntity.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public bool Update(T entity)
        {
            var result = _contextEntity.Update(entity);
            return result.State == EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _contextEntity.Find(id);
            if (entity != null)
            {
                _contextEntity.Remove(entity);
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}