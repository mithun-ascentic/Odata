using Odata_1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1
{
    public class ProductStore : DataStore<Product>
    {
        public ProductStore(SampleDbContext context):base(context)
        {

        }
    }
}
