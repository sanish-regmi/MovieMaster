using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ServiceLayer
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {


        public AppDbContext CreateDbContext(string[] args)
        {

            AppConfiguration appConfiguration = new AppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(appConfiguration.sqlConnection);
            return new AppDbContext(optionsBuilder.Options);


        }
        //public AppDbContext CreateDbContext(string[] args)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json").Build();
        //    var builder = new DbContextOptionsBuilder<AppDbContext>();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    builder.UseSqlServer(connectionString);
        //    return new AppDbContext(builder.Options);
        //}


    }
}
