using System;
using System.Collections.Generic;

namespace Models
{
    public class Review
    {
        //Constructors
        public Review(){}

        public Review(decimal rating, string comment, int restaurantId, int userId )
        {

            this.Rating = rating;
            this.Comment = comment;
            this.UserId = userId;
            this.RestaurantId = restaurantId;
        }
        public Review(int id, decimal rating, string comment, int userId, int restaurantId)
        {

            this.Id = id;
            this.Rating = rating;
            this.Comment = comment;
            this.UserId = userId;
            this.RestaurantId = restaurantId;
        }
        public int Id {get; set;}
        public decimal Rating {get; set;}
        public string Comment {get; set;}
        public int UserId {get; set;}
        public int RestaurantId {get; set;}

        
    }
}