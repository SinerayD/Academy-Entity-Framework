using Academy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Context
{
    public class AcademyDbContext:DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<Group>? Groups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server =LAPTOP-JIFALFHT\\MSSQLSERVER01; Database=Academy;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
