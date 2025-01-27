using DNC.ProjectAudit.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T newEntity)
        {
            await _dbSet.AddAsync(newEntity);
            return newEntity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll(int pageNr, int pageSize)
        {
            return await _dbSet.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Update(T modifiedEntity)
        {
            _dbSet.Update(modifiedEntity);
            return modifiedEntity;
        }
    }
}
