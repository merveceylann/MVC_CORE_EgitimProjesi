using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp102.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        //sadece metodun ismini yazdik. yarim metod

        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> Where(Expression<Func<T,bool>> predicate);

        //db.Product.FirstOrDefault(s=>s.Id==id);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        //async islemi updatei desteklemiyo 
        T Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}