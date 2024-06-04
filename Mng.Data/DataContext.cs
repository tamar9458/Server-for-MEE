using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mng.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mng.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        //  public DbSet<UserEmployee> Users { get; set; }

        public DataContext(IConfiguration configuration) { 
        _configuration = configuration;
        }
        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=mng_employee_db;");
               // optionsBuilder.UseSqlServer(@"Server=34.122.63.173;Database=mng_employee_db;Uid=SqlServer;Pwd=123456;TrustServerCertificate=Yes;");
                optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);

           // }
        }

    }
}
