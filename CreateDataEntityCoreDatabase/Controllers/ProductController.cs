using CreateDataEntityCoreDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateDataEntityCoreDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DataContext db;
        public ProductController(DataContext _db)
        {
            db = _db;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                db.Product.Add(product);
                db.SaveChanges(); // save to database just like update-datbase command
                return Ok(product);
            }
            catch 
            {

                return BadRequest();
            }
        }
    }
}
