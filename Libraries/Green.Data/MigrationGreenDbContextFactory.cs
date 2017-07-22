using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Autofac;
using System.IO;

namespace Green.Data
{
    public class MigrationGreenDbContextFactory : IDesignTimeDbContextFactory<GreenObjectContext>
    {

        public GreenObjectContext CreateDbContext(string[] args)
        {
            return new GreenObjectContext();
        }
    }
}

