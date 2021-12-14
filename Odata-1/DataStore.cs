using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1
{
    public class DataStore<T> where T : class
    {
        protected SampleDbContext _context;
        protected DbSet<T> _dbSet;

        protected DataStore(SampleDbContext context){
            _context = context;
            _dbSet = context.Set<T>();
    }

        public DbSet<T> DbSet()
        {
            return _dbSet;
        }
            
    }
}
