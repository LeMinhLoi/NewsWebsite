using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewsWebsite.Data.EF
{
    class WebDbContextFactory : IDesignTimeDbContextFactory<WebsiteDBContext>
    {
        public WebsiteDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("webdbstring");
            var optionsBuilder = new DbContextOptionsBuilder<WebsiteDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new WebsiteDBContext(optionsBuilder.Options);
        }
    }
}
