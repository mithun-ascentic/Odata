using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1.Controllers
{
    [Route("odata")]
    [ApiController]
    public class SaleController : ODataController
    {
        private readonly SampleDbContext sampleDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public SaleController(SampleDbContext dbContext)
        {
            sampleDb = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }


        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [EnableQuery(MaxSkip = 10, MaxTop = 5, PageSize = 4)]
        public async Task<IActionResult> Get()
        {
            var quryable = sampleDb.Sale.AsQueryable();
            return Ok(quryable);

        }


        ///// <summary>
        ///// Gets the specified key.
        ///// </summary>
        ///// <param name="key">The key.</param>
        ///// <returns></returns>
        //[EnableQuery]
        //public async Task<IActionResult> Get(int key)
        //{
        //    var productQ = sampleDb.Sale.Where(a => a.Id == key);

        //    return Ok(SingleResult.Create(productQ));
        //}
    }
}
