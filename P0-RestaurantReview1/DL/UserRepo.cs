using Models;
using DL.Entities;
using System.Collections.Generic;
using System.Linq;


namespace DL
{
    public class UserRepo : IUserRepo
    {
        private p0dbContext _context;
        public UserRepo(p0dbContext context)
        {
            _context = context;
        }
        public List<Models.Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.Select(
                restaurant => new Models.Restaurant(restaurant.Id, restaurant.Type, restaurant.Name, restaurant.Address, restaurant.City, restaurant.State, restaurant.ZipCode)
            ).ToList();
        }

        public List<Models.Review> AllReviews => _context.Reviews.Select(
                review => new Models.Review(review.Id, review.Rating, review.Comment, review.UserId, review.RestaurantId)
            ).ToList();

        public List<Models.User> GetAllUsers() => _context.Users.Select(
                user => new Models.User(user.Id, user.Name, user.Password, user.Email)
            ).ToList();

        public Models.Review AddReview(Models.Review review)
        {
            _context.Reviews.Add(
                new Entities.Review{
                    Rating = review.Rating,
                    Comment = review.Comment,
                    UserId = review.UserId,
                    RestaurantId = review.RestaurantId
                }
            );
            _context.SaveChanges();

            return review;
        }

        public Models.User AddUser(Models.User user)
        {
            _context.Users.Add(
                new Entities.User{
                    Name = user.Name,
                    Password = user.Password,
                    Email = user.Email
                }
            );
            _context.SaveChanges();

            return user;
        }

        public Models.Restaurant SearchRestaurantName(string name)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
                .FirstOrDefault(restaurant => restaurant.Name == name);
         
            if(foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Type, foundRestaurant.Name, foundRestaurant.Address, foundRestaurant.City, foundRestaurant.State, foundRestaurant.ZipCode);
            }
            return new Models.Restaurant();
        }

         public Models.Restaurant SearchRestaurantType(string type)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
                .FirstOrDefault(restaurant => restaurant.Type == type);
         
            if(foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Type, foundRestaurant.Name, foundRestaurant.Address, foundRestaurant.City, foundRestaurant.State, foundRestaurant.ZipCode);
            }
            return new Models.Restaurant();
        }

         public Models.Review SearchRestaurantRating(decimal rating)
        {
            Entities.Review foundReview = _context.Reviews
                .FirstOrDefault(review => review.Rating == rating);
         
            if(foundReview != null)
            {
                return new Models.Review(foundReview.Id, foundReview.Rating, foundReview.Comment, foundReview.UserId, foundReview.RestaurantId);
            }
            return new Models.Review();
        }

         public Models.Restaurant SearchRestaurantCity(string city)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
                .FirstOrDefault(restaurant => restaurant.City == city);
         
            if(foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Type, foundRestaurant.Name, foundRestaurant.Address, foundRestaurant.City, foundRestaurant.State, foundRestaurant.ZipCode);
            }
            return new Models.Restaurant();
        }

         public Models.Restaurant SearchRestaurantZipCode(int zipCode)
        {
            Entities.Restaurant foundRestaurant = _context.Restaurants
                .FirstOrDefault(restaurant => restaurant.ZipCode == zipCode);
         
            if(foundRestaurant != null)
            {
                return new Models.Restaurant(foundRestaurant.Id, foundRestaurant.Type, foundRestaurant.Name, foundRestaurant.Address, foundRestaurant.City, foundRestaurant.State, foundRestaurant.ZipCode);
            }
            return new Models.Restaurant();
        }

    }
}