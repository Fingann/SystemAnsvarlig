using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        void Delete(Expression<Func<T, bool>> expression);

        void Delete(T item);

        T Single(Expression<Func<T, bool>> expression);

        IQueryable<T> All();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T item);

        void Add(IEnumerable<T> items);

        void UpdateOrAdd(T item);

        void DropDatabase();
    }
}