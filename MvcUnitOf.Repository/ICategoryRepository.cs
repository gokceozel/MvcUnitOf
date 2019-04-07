using MvcUnitOf.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Repository.Repositories.DataRepo
{
  public   interface ICategoryRepository :IRepository<Category>
    {
    }

    public class CategoryRepository :EfRepository<Category> , ICategoryRepository
    {

        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
