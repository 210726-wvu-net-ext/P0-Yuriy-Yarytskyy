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
        public void GetAllUsersShouldGetAllUsers()
        {
            using(var context = new Entity.p0dbContext(options))
            {
                IUserRepo _repo = new UserRepo(context);

                var users = _repo.GetAllUsers();

                Assert.Equal(2, users.Count);
            }
        }

        [Fact]
        public void GetAllRestaurantsShouldGetAllRestaurants()
        {
            using(var context = new Entity.p0dbContext(options))
            {
                IUserRepo _repo = new UserRepo(context);

                var restaurants = _repo.GetAllRestaurants();

                Assert.Equal(2, restaurants.Count);
            }
        }

        [Fact]
        public void AddUsersShouldAddUser()
        {
            using (var testcontext = new Entity.p0dbContext(options))
            {
                IUserRepo _repo = new UserRepo(testcontext);

                _repo.AddUser(
                    new Models.User {
                        Id = 3,
                        Name = "Yuriy",
                        Password = "password",
                        Email = "my@gmail.com"
                    }
                );
            }

        }
        [Fact]
        public void AllReviewsShouldAllReview()
        {
            using(var context = new Entity.p0dbContext(options))
            {
                IUserRepo _repo = new UserRepo(context);

                var restaurants = _repo.GetAllUsers();

                Assert.Equal(2, restaurants.Count);
            }
        }
        private void Seed()
        {
            using(var context = new Entity.p0dbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.AddRange(
                    new Entity.User{
                        Id = 1,
                        Name = "John",
                        Password = "passcode",
                        Email = "john@revature.net"
                     
                    },
                    new Entity.User{
                        Id = 2,
                        Name = "Yuriy",
                        Password = "nocode",
                        Email = "yuriy@revature.net"
                     
                    }
                    );
                    context.Restaurants.AddRange(
                    new Entity.Restaurant{
                        Id = 1,
                        Type = "PIzza",
                        Name = "HopePizza",
                        Address = "Hope St",
                        City = "Stamford",
                        State = "CT",
                        ZipCode = 06906
                        
                    },
                    new Entity.Restaurant{
                        Id = 12,
                        Type = "Italian",
                        Name = "Zaza",
                        Address = "Main St",
                        City = "Norwalk",
                        State = "CT",
                        ZipCode = 06854
                        
                    }
                    
                );
                context.SaveChanges();
            }
        }

    }
    public class CheckAdmin
    {   
        [Fact]
        public void AdminTest()
        {
            bool login = false;
            string adminUN = "ADMIN";
            string adminUP = "CODE";

            string expectedUN = "ADMIN";
            string expectedUP = "CODE";
            if(adminUN==expectedUN && adminUP==expectedUP)
            {
                bool outcome = true;
                Assert.True(outcome);
            }
          
        }
    }

    public class IsAdmin
    {   
        [Fact]
        public void CheckIfUserAdmin()
        {
            bool login = false;
            string adminUN = "ADMIN";
            string adminUP = "CODE";
            string[] userNames = {"John","Paul","Yuriy","ADMIN"};

            for (int i = 0; i < userNames.Length; i++)
            {
               if(userNames[i] == adminUN){
                   login = true;
               }
            }
        }
    }

    public class IsAdminPasswor
    {   
        [Fact]
        public void CheckPassword()
        {
            bool login = true;
            string adminUN = "ADMIN";
            string adminUP = "CODE";
            string[] userPasswords = {"PASSword","NULLL","Passcode","Code"};

            for (int i = 0; i < userPasswords.Length; i++)
            {
               if(userPasswords[i] == adminUP){
                   login = false;
               }
            }
        }
    }

}