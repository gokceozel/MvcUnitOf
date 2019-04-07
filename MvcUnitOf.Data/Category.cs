using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnitOf.Data
{
   public class Category :Base
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }


        public virtual  ICollection<Product> Products { get; set; }

    }
}
