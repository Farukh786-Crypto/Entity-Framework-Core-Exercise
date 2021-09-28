using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadDatafromDatabase.Models
{
    // 	it is interact with database
    public class DataContext : DbContext
    {
        // use to provide Database Ex sql server
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        // table is create with DbSet
        public DbSet<Product> product { get; set; }
    }
}
