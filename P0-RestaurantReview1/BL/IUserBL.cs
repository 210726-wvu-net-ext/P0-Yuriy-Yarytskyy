using System.Collections.Generic;

using Models;

namespace BL
{
    public interface IUserBL
    {
        List<Restaurant> ViewAllRestaurants();

        List<Review> ViewAllReviews();
        List<User> ViewAllUsers();

        Review AddReview(Review review);

         User AddUser(User user);
         User SearchForUser(string name);

         Restaurant SearchRestaurantName(string name);
         Restaurant SearchRestaurantType(string type);
         Review SearchRestaurantRating(decimal rating);
         Restaurant SearchRestaurantCity(string city);
         Restaurant SearchRestaurantZipCode(int zipCode);


    }
}