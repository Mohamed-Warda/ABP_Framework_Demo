﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ABPDemo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ABPDemoDbContextFactory : IDesignTimeDbContextFactory<ABPDemoDbContext>
{
    public ABPDemoDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ABPDemoEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ABPDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new ABPDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ABPDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
