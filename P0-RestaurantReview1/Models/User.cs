using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        //Constructors
        public User() {}
        public User(string name)
        {
            this.Name = name;

        }
        public User(string name, string password, string email)
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;

        } 
        public User(int id, string name, string password, string email) : this(name)
        {
            this.Id = id;
            this.Password = password;
            this.Email = email;
        }
        public int Id {get; set;}
        public string Name {get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
        public List<Review> Reviews {get; set;}
        
    }
}
