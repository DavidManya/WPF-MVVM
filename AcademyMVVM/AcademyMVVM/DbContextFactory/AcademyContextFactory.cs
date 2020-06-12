using AcademyMVVM.Lib.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AcademyMVVM.DbContextFactory
{
    public class AcademyContextFactory : IDesignTimeDbContextFactory<ProjectDBContext>
    {
        public ProjectDBContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("AcademyDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProjectDBContext>();
            optionsBuilder.UseSqlite(dbConnection, x => x.MigrationsAssembly("AcademyMVVM"));

            return new ProjectDBContext(optionsBuilder.Options);
        }
    }
}
