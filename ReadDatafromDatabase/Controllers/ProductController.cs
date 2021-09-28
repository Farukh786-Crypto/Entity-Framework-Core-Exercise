using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadDatafromDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadDatafromDatabase.Controllers
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
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = db.product.ToList();
                return Ok(products);
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
