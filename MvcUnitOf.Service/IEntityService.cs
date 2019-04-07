using MvcUnitOf.Repository.Repositories;
using MvcUnitOf.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Service
{
  public  interface IEntityService<T> where T:class
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        List<T> listem();
    }

    public class EntityService<T> : IEntityService<T> where T : class
    {
        IUnitOfWork _unit;
        IRepository<T> _repository;
        private IUnitOfWork unit;
        private ICategoryService categoryy;

        public EntityService(IUnitOfWork unitOfWork ,IRepository<T> repository)
        {
            _unit = unitOfWork;
            _repository = repository;
        }

        public EntityService(IUnitOfWork unit, ICategoryService categoryy)
        {
            this.unit = unit;
            this.categoryy = categoryy;
        }

        public void Create(T entity)
        {
            _repository.Add(entity);
            _unit.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unit.Commit();
        }

        public IEnumerable<T> GetAll()
        {
          return  _repository.GetAll();
        }

        public List<T> listem()
        {
            return _repository.Liste();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unit.Commit();
        }
    }
}
