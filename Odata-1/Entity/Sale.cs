using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1.Entity
{
    public class Sale
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
