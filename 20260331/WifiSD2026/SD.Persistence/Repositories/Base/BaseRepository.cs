using SD.Core.Entities;
using SD.Core.Repositories;
using SD.Persistence.Repositories.DBContext;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SD.Persistence.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        private MovieDbContext movieDbContext;

        #region ctor | dtor
        public BaseRepository()
        {
            this.movieDbContext = new MovieDbContext();
        }

        public BaseRepository(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }
        #endregion


        #region [C]REATE
        public void Add<T>(T entity, bool saveImmediately = default) //bool default auf false
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            //als hinzugefügtes entity vorgemerkt, aber nocht nicht in db gespeichert
            this.movieDbContext.Add(entity);

            //hier wird alles was im DbContext vorgemerkt ist, in die Datenbank gespeichert (alles was hinzugefügt, geändert oder gelöscht wurde)
            if (saveImmediately)
            {
                this.movieDbContext.SaveChanges();
            }

        }

        public async Task AddAsync<T>(T entity, bool saveImmediately = default, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Add(entity);

            if (saveImmediately)
            {
                await this.movieDbContext.SaveChangesAsync(cancellationToken); //bei async methode immer ein await 
            }
        }
        #endregion

        #region [R]EAD
        public IQueryable<T> QueryFrom<T>(Expression<Func<T, bool>> whereFilter = null) //bool>> heißt Ergebnis wird nur zurückgegeben, wenn bool true ist
            where T : class, IEntity
        {
            //hier wird nur Abfrage Retour gegeben 
            var query = this.movieDbContext.Set<T>();

            if (whereFilter != null)
            {
                return query.Where(whereFilter);
            }

            return query;
        }
        #endregion

        #region [U]PDATE
        public T Update<T>(T entity, object key, bool saveImmediately = default)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return null;
            }

            var toUpdate = this.movieDbContext.Find<T>(key); //Find Methode funktioniert nur mit Schlüsselfelder

            if (toUpdate != null)
            {
                this.movieDbContext.Entry(toUpdate).CurrentValues.SetValues(entity);
            }

            if (saveImmediately)
            {
                this.movieDbContext.SaveChanges();
            }

            return toUpdate;
        }

        public async Task<T> UpdateAsync<T>(T entity, object key, bool saveImmediately = default, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return null;
            }

            var toUpdate = await this.movieDbContext.FindAsync<T>(key, cancellationToken);

            if (toUpdate != null)
            {
                this.movieDbContext.Entry(toUpdate).CurrentValues.SetValues(entity);
            }

            if (saveImmediately)
            {
                await this.movieDbContext.SaveChangesAsync(cancellationToken);
            }
            return toUpdate;
        }
        #endregion

        #region [D]ELETE
        public void Remove<T>(T entity, bool saveImmediately)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Remove<T>(entity);

            if (saveImmediately)
            {
                this.movieDbContext.SaveChanges();
            }
        }

        public async Task RemoveAsync<T>(T entity, bool saveImmediately = default, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            if (entity == null)
            {
                return;
            }

            this.movieDbContext.Remove<T>(entity);

            if (saveImmediately)
            {
                await this.movieDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public void RemoveByKey<T>(object key, bool saveImmediately = default)
            where T : class, IEntity
        {
            if (key == null)
            {
                return;
            }

            var toRemove = this.movieDbContext.Find<T>(key);
            if (toRemove != null)
            {
                this.movieDbContext.Remove(toRemove);
            }

            if (saveImmediately)
            {
                this.movieDbContext.SaveChanges();
            }
        }

        public async Task RemoveByKeyAsync<T>(object key, bool saveImmediately = default, CancellationToken cancellationToken = default)
            where T : class, IEntity
        {
            if (key == null)
            {
                return;
            }

            var toRemove = await this.movieDbContext.FindAsync<T>(key, cancellationToken);
            if (toRemove != null)
            {
                this.movieDbContext.Remove<T>(toRemove);
            }

            if (saveImmediately)
            {
                await this.movieDbContext.SaveChangesAsync(cancellationToken);
            }
        }
        #endregion

        public void SaveChanges()
        {
            this.movieDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await this.movieDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

