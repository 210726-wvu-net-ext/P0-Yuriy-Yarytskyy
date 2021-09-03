using Models;
using System;
using System.Collections.Generic;


namespace DL
{
    public interface IUserRepo
    {
        List<Restaurant> GetAllRestaurants();
        List<Review> AllReviews { get; }

        List<User> GetAllUsers();

        Review AddReview(Review review);
        User AddUser(User user);
         

        Restaurant SearchRestaurantName(string name);
        Restaurant SearchRestaurantType(string type);
        Review SearchRestaurantRating(decimal rating);
        Restaurant SearchRestaurantCity(string city);
        Restaurant SearchRestaurantZipCode(int zipCode);
        User SearchForUser(string name);
    }
}