using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadDatawithCondition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadDatawithCondition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DataContext db = new DataContext();
        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> find(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                return Ok(product);
            }
            catch 
            {
                return BadRequest();
                
            }
        }
        [Produces("application/json")]
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            try
            {
                var products = db.Product.Where(p=>p.Name.Contains(keyword)).ToList();
                return Ok(products);
            }
            catch 
            {

                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("between/{min}/{max}")]
        public async Task<IActionResult> Between(int min,int max)
        {
            try
            {
                var products = db.Product.Where(p => p.Id >= min && p.Id <= max).ToList();
                return Ok(products);
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
