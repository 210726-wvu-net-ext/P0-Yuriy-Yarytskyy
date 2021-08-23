using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DL.Entities;
using BL;
using DL;
using System.IO;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("p0db");

            DbContextOptions<p0dbContext> options = new DbContextOptionsBuilder<p0dbContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new p0dbContext(options);

            
            IMenu menu = new MainMenu(new UserBL(new UserRepo(context)));
            menu.Start();
        }
    }
}
