using SD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SD.Core.Repositories
{
    public interface IBaseRepository
    {
        //Add Methoden
        void Add<T>(T entity, bool saveImmediately = false)
            where T : class, IEntity; //Typsicher, dass nur Entity Klassen in Repository kommen

        Task AddAsync<T>(T entity, bool saveImmediately = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;

        //Update Methoden
        T Update<T>(T entity, object key, bool saveImmediately = false)
            where T : class, IEntity;

        //Read Methoden
        Task<T> UpdateAsync<T>(T entity, object key, bool saveImmediately = false, CancellationToken cancellationToken = default)
            where T : class, IEntity;

        IQueryable<T> QueryFrom<T>(Expression<Func<T, bool>> whereFilter = null)
            where T : class, IEntity;

        //Remove Methoden
        void Remove<T>(T entity, bool saveImmediately = false) //synchron
            where T : class, IEntity;

        Task RemoveAsync<T>(T entity, bool saveImmediately = false, CancellationToken cancellationToken = default) //asynchron
            where T : class, IEntity;

        void RemoveByKey<T>(object key, bool saveImmediately = false) //synchron
            where T : class, IEntity;

        Task RemoveByKeyAsync<T>(object key, bool saveImmediately = false, CancellationToken cancellationToken = default) //asynchron
            where T : class, IEntity;

    }
}
