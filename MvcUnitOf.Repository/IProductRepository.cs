using MvcUnitOf.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Repository.Repositories.DataRepo
{
   public  interface IProductRepository : IRepository<Product>
    {
      int  Get_Product_Count(int id);
    }

    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) :base(dbContext)
        {

        }

        public int Get_Product_Count(int id)
        {
            return GetAll().Count();
        }
    }
}
