using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreCodeFirst.Models
{
    // 	it is interact with database
    public class EmployeeContext : DbContext
    {
        // use to provide Database Ex sql server
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }
        // table is create with DbSet
        public DbSet<Employee> Employees { get; set; }
    }
}
