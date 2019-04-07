using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Repository.Repositories
{

    public interface IRepository<T> where T : class
    {

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        T GetByID(int id);

        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        List<T> Liste();


    }


    public class EfRepository<T> : IRepository<T> where T : class
    {

        public DbContext _dbContext;

        public DbSet<T> _dbset;

        public EfRepository(DbContext dbContext )
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity.GetType().GetProperty("IsDeleted")!=null)
            {
                T _entity = entity;
                _entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                this.Update(_entity);
            }
            else
            {
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
                if (dbEntityEntry.State !=EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbset.Attach(entity);
                    _dbset.Remove(entity);
                }
            }
        }

        public void Delete(int id)
        {

            var entity = GetByID(id);
            if (entity == null) return;
            else
            {
                if (entity.GetType().GetProperty("IsDelete")!=null)
                {
                    T _entity = entity;

                   _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                    this.Update(_entity);

                }
                else
                {
                    Delete(entity);
                }
            }
            
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public T GetByID(int id)
        {
          return    _dbset.Find(id);
        }

        public List<T> Liste()
        {
            return _dbset.ToList();
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
