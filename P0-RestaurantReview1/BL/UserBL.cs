using System;
using Models;
using DL;
using System.Collections.Generic;

namespace BL
{
    /// <summary>
    /// Business layer
    /// </summary>
    public class UserBL : IUserBL
    {
        private IUserRepo _repo;
        public UserBL(IUserRepo repo)
        {
            _repo = repo;
        }
        public List<Restaurant> ViewAllRestaurants()
        {
            return _repo.GetAllRestaurants();
        }

        public List<Review> ViewAllReviews()
        {
            return _repo.AllReviews;
        }

        public List<User> ViewAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public Review AddReview(Review review)
        {
            return _repo.AddReview(review);
        }

        public User AddUser(User user)
        {
            return _repo.AddUser(user);
        }

        public Restaurant SearchRestaurantName(string name)
        {
            return _repo.SearchRestaurantName(name);
        }

        public Restaurant SearchRestaurantType(string type)
        {
            return _repo.SearchRestaurantType(type);
        }
        public Review SearchRestaurantRating(decimal rating)
        {
            return _repo.SearchRestaurantRating(rating);
        }
        public Restaurant SearchRestaurantCity(string city)
        {
            return _repo.SearchRestaurantCity(city);
        }
        public Restaurant SearchRestaurantZipCode(int zipCode)
        {
            return _repo.SearchRestaurantZipCode(zipCode);
        }

        public User SearchForUser(string name)
        {
            return _repo.SearchForUser(name);
        }

    }
}
