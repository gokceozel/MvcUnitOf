using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Data
{
  public   class Product:Base
    {

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
