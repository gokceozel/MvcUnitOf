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
  public  interface IProductService :IEntityService<Product>
    {


    }

    public class ProductService : EntityService<Product>,IProductService
    {
        IUnitOfWork _unit;
        IProductRepository _productRepository;

        public ProductService(IUnitOfWork unit,IProductRepository productRepository) :base(unit , productRepository)
        {
            _unit = unit;
            _productRepository = productRepository;
        }
    }
}
