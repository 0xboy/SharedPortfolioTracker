using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TracKing.Infrastructure.Context;

namespace TracKing.Infrastructure.Repository
{
    public class BaseRepository<T> : IWriteRepository<T>, IReadRepository<T> where T : class
    {
        private readonly BaseContext _baseContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
            _dbSet = _baseContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> prediacte)
        {
            return _dbSet.Where(prediacte).AsNoTracking();
        }

        public T GetById(Guid Id)
        {
            return _dbSet.Find(Id);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _baseContext.Entry(entity);

            if (dbEntityEntry.State is not EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }

        }

        public void Delete(Guid Id)
        {
            var entity = _dbSet.Find(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void DetectUpdate(T entity)
        {
            _dbSet.Attach(entity);
        }

        public void Save()
        {
            _baseContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _baseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
