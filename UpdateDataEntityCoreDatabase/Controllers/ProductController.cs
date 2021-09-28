using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdateDataEntityCoreDatabase.Models;

namespace UpdateDataEntityCoreDatabase.Controllers
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
        [HttpPut("update")]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(product);
            }
            catch 
            {

                return BadRequest();
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.Remove(db.Product.Find(id));
                // db.SaveChanges();   value deleete in database
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
