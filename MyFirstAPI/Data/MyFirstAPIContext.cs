﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Data
{
    public class MyFirstAPIContext : DbContext
    {
        public MyFirstAPIContext (DbContextOptions<MyFirstAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MyFirstAPI.Models.Employee> Employee { get; set; }
    }
}
