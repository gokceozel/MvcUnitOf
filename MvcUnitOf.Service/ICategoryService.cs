using MvcUnitOf.Data;
using MvcUnitOf.Repository.Repositories.DataRepo;
using MvcUnitOf.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Service
{
  public  interface ICategoryService : IEntityService<Category>
    {

    }

    public class CategoryService : EntityService<Category>,ICategoryService
    {
        IUnitOfWork _unit;
        ICategoryRepository _category;

        public CategoryService(IUnitOfWork unit , ICategoryRepository category):base(unit,category)
        {
            _unit = unit;
            _category = category;

        }
    }


}
