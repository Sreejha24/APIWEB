using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Data
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options)
            :base(options)
        {
           
        }
        public DbSet<Employee> employees { get; set; }
    }
}
