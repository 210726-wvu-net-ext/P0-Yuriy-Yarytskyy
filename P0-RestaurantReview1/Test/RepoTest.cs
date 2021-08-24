using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;
using Models;
using DL;

namespace Test
{
    public class RepoTest
    {
        private readonly DbContextOptions<Entity.p0dbContext> options;

        public RepoTest()
        {
            options = new DbContextOptionsBuilder<Entity.p0dbContext>().UseSqlite("Filename=Test.db").Options;
            Seed();
        }

        [Fact]
        public void Test1()
        {

        }
        private void Seed()
        {
            using(var context = new Entity.p0dbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Restaurants.AddRange(
                    new Entity.Restaurant{
                        Id = 1,
                        Type = "PIzza",
                        Name = "HopePizza",
                        Address = "Hope St",
                        City = "Stamford",
                        State = "CT",
                        ZipCode = 06906
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
