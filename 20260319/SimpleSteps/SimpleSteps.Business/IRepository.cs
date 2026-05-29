using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SimpleSteps.Business
{
    public interface IRepository<T> where T : class
    {
        //Read-Methoden
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<List<T>>GetAllByFilter(Expression<Func<T, bool>> filter);

        //Modify-Methoden
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
