using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Creates a restaurant
    /// </summary>
    public class Restaurant
    {
        //Constructors
        public Restaurant(){}
        public Restaurant(string name)
        {
            this.Name = name;
        }
        public Restaurant(int id, string type, string name, string address, string city, string state, int zipcode) : this(name)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;
        }
        
        public int Id {get; set;}
        public string Type {get; set;}
        public string Name {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public int ZipCode {get; set;}
        public List<Review> Reviews {get; set;}

    }
}