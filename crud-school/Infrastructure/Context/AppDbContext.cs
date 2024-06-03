using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Grade> Grade { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); base.OnModelCreating(modelBuilder);
        }

    }
}
