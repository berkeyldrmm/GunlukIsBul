using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IServiceRepository<T>
    {
        public T Get(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetByFilter(IEnumerable<Expression<Func<T, bool>>> filters);
        public Task<bool> Add(T entity);
        public bool Update(T entity);
        public void Delete(int id);
        public Task<int> SaveChanges();
    }
}
