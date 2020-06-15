using Microsoft.EntityFrameworkCore;
using AcademyMVVM.Lib.Models;
using Common.Lib.Core;
using System.Collections.Generic;

namespace AcademyMVVM.Lib.DAL
{
    public class ProjectDBContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Exams> Exams { get; set; }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Entity>()
                   .Ignore(x => x.CurrentValidation);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");//        
        //    }
        //}
    }
}
