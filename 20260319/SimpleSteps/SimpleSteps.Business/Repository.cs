using Microsoft.EntityFrameworkCore;
using SimpleSteps.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SimpleSteps.Business
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        //Read-Methoden
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); //hier bekommen wir Liste zurück
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }
        //Find sucht immer über den Primärschlüssel, deswegen ist es wichtig, dass die Entität einen Primärschlüssel hat
        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }


        //Modify-Methoden
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }


        //speichert alle änderungen im context
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
