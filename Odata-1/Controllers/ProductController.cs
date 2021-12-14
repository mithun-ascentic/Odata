using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odata_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SampleDbContext sampleDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public ProductController(SampleDbContext dbContext)
        {
            sampleDb = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [EnableQuery]
        //public async Task<IActionResult> Get()
        //{
        //    //return Ok(await sampleDb.Product.ToListAsync());
        //    return Ok(await sampleDb.Product.ToListAsync());
        //}

        public IActionResult Get()
        {
           // return Ok(await sampleDb.Product.ToListAsync());
            return Ok(sampleDb.Product);
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        [HttpGet("GetProduct")]
        [EnableQuery]
        public async Task<IActionResult> GetProduct([FromODataUri]int key)
        {
           var productQ =  sampleDb.Product.Where(a => a.Id == key);

            return Ok(SingleResult.Create(productQ));
        }
    }
}
