using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.DataContext
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options): base(options)
        {
        }

         public virtual DbSet<Cliente> Cliente { get; set; }
    }
}