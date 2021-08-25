using Models;
using System;
using BL;
using System.Collections.Generic;
using Serilog;


namespace UI
{
    /// <summary>
    /// Main Menu functionality
    /// </summary>
    public class MainMenu : IMenu
    {
        
        private IUserBL _userbl;
        public MainMenu(IUserBL bl)
        {
            _userbl = bl;
            Log.Logger=new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Console()
                            .WriteTo.File("../logs/restrevlogs.txt", rollingInterval:RollingInterval.Day)
                            .CreateLogger();
            Log.Information("UI Start");

        }

        /// <summary>
        /// First menu which lats you use verious methods to retrive and manipulate data.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
  
        public void Start()
        {
        
            bool repeat = true;
            do
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("*  WELCOME TO RESTAURANT REVIEW APP!  *");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("*      PLEASE MAKE YOUR SELECTION     *");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[0] EXIT");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[1] ADD A USER");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[2] WRITE A REVIEW");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[3] SEE RESTAURANT'S RATING");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[4] VIEW ALL REVIEWS");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[5] SEARCH FOR A RESTAURANT");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[6] VIEW ALL RESTAURANTS");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("------------**************-------------");
                Console.WriteLine("-------ARE YOU AN ADMIN USERS----------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("------------****[YES]*****-------------");
                Console.WriteLine("---------------------------------------");

               

                switch(Console.ReadLine())
                {
                    case "0":
                        Log.Debug("Program was manually exited!!!");
                        Console.WriteLine("You have chosen to exit!");
                        repeat = false;
                    break;

                    case "1":
                        AddUser();
                    break;

                    case "2":
                        AddReview();
                    break;

                    case "3":
                        GetAvgRating();
                    break;

                    case "4":
                        ViewAllReviews();
                    break;

                    case "5":
                        SearchForARestaurant();
                    break;

                    case "6":
                        ViewAllRestaurants();
                    break;
                    case "YES":
                        LogIn();
                    break;
                    case "NO":
                        ViewAllRestaurants();
                    break;

                    default:
                        Console.WriteLine("WRONG SELECTION!!!");
                        Log.Debug("Invalid selection in main menu!!!");
                    break;
                }
            }while(repeat);

        }

        /// <summary>
        /// Function to add user which will be stored in database
        /// </summary>
        /// <param>string</param>
        /// <param></param>
        /// <returns></returns>
        private void AddUser()
        {
            Log.Debug("AddUser was used!!!");
            string inputName;
            string inputPassword;
            string inputEmail;
            User userToAdd;


            Console.WriteLine("PLEASE ENTER NEW USER DRTAILS!");

            do
            {
                Console.WriteLine("Name: ");
                inputName = Console.ReadLine();
                Console.WriteLine("Password: ");
                inputPassword = Console.ReadLine();
                Console.WriteLine("Email: ");
                inputEmail = Console.ReadLine();

            }while(String.IsNullOrWhiteSpace(inputName) && String.IsNullOrWhiteSpace(inputPassword) && String.IsNullOrWhiteSpace(inputEmail));

            userToAdd = new User(inputName, inputPassword, inputEmail);
            try
            {
                userToAdd = _userbl.AddUser(userToAdd);
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine($"{userToAdd.Name} was successfully added as a user.");
                Console.WriteLine("_____________________________________________________");
                Log.Debug("User was successfully added." + userToAdd.Name);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "User was not added" + userToAdd.Name);
                Console.WriteLine(ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        /// <summary>
        /// A functiion to add review to a review table
        /// </summary>
        private void AddReview()
        {
            Log.Debug("AddReview was used!!!");
            decimal rating = 0;
            string comment;
            int userId;
            int restaurantId;
            

            List<User> users = _userbl.ViewAllUsers();
            Console.WriteLine("__________________________________");
            string promptUser = "|  WHO WANTS TO LEAVE A REVIEW?  |";
            User selectedUser = SelectUser(users, promptUser);

            List<Restaurant> restaurants = _userbl.ViewAllRestaurants();
            Console.WriteLine("__________________________________");
            string promptRestaurant = "|  SELECT A RESTAURANT TO REVIEW  |";
            Restaurant selectedRestaurant = SelectRestaurant(restaurants, promptRestaurant);
            
            if(selectedUser is not null)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine(selectedUser.Name + " wants to write a review");
                Console.WriteLine("----------------------------------");

                     if(selectedRestaurant is not null)
                    {
                        do
                        {
                            Console.WriteLine("You have selected " + selectedRestaurant.Name + " to review");
                            Console.WriteLine("Rate this restaurant 1 to 5: ");
                            rating = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("You have given a score of {0}", rating);
                            Console.WriteLine("Please leave a comment: ");
                            comment = Console.ReadLine();

                        }while(String.IsNullOrWhiteSpace(comment));
                        
                        Console.WriteLine(selectedRestaurant.Id);
                        Console.WriteLine(selectedUser.Id);

                        Review reviewToAdd = new Review( rating, comment, selectedRestaurant.Id, selectedUser.Id);

                        try
                        {
                            reviewToAdd = _userbl.AddReview(reviewToAdd);
                            Console.WriteLine("------------------------------------------------------------------------------------------------------");
                            Console.WriteLine(selectedUser.Name + " has added new review to " + selectedRestaurant.Name + " restaurant successfully.");
                            Log.Debug("Review has been added!" + reviewToAdd.Id);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Review was not added");
                            Console.WriteLine(ex);
                        }
                        finally
                        {
                            Log.CloseAndFlush();
                        }
                        
                    }

            }

        }
        /// <summary>
        /// A function to view all reviews by pulling data from db
        /// </summary>
        private void ViewAllReviews()
        {
            Log.Debug("ViewAllReviews was used!!!");
            List<Review> reviews = _userbl.ViewAllReviews();
            foreach(Review review in reviews)
            {
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"    {review.Id}   *   {review.Rating}   *   {review.Comment}   *   ");
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
            }
        }
       

        /// <summary>
        /// A function to to search for a restaurant by using different methods
        /// </summary>
        private void SearchForARestaurant()
        {
            Log.Debug("SearchForARestaurant was used!!!");
            bool repeat = true;
            do
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("*          RESTAURANT SEARCH          *");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("*  PLEASE CHOOSE ONE OF THE FOLLOWING  *");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[1] SEARCH BY NAME");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[2] SEARCH BY TYPE");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[3] SEARCH BY RATING");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[4] SEARCH BY CITY");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("[5] SEARCH BY ZIPCODE");
                Console.WriteLine("---------------------------------------");;
                Console.WriteLine("[6] View ALL Restaurants");
                Console.WriteLine("---------------------------------------");

                switch(Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("EXIT OPTION HAS BEEN SELECTED!");
                        repeat = false;
                    break;

                    case "1":
                        SearchRestaurantName();
                    break;

                    case "2":
                        SearchRestaurantType();
                    break;

                    case "3":
                        SearchRestaurantRating();
                    break;

                    case "4":
                        SearchRestaurantCity();
                    break;

                    case "5":
                        SearchRestaurantZipCode();
                    break;

                    case "6":
                        ViewAllRestaurants();
                    break;

                    default:
                        Console.WriteLine("WRONG SELECTION FROM SEARCH MENU!!!");
                        Console.WriteLine("!!! INCORRECT SELLECTION !!!");
                    break;
                }
            }while(repeat);
        }

        /// <summary>
        /// Search for a restaurant by name
        /// </summary>
        private void SearchRestaurantName()
        {
            Log.Debug("SearchRestaurantName was used!!!");
            string input;
            Console.WriteLine("ENTER RESTAURANT'S NAME");
            input = Console.ReadLine();

            Restaurant foundRestaurant = _userbl.SearchRestaurantName(input);
            if(foundRestaurant.Name is null)
            {
                Console.WriteLine($"{input} no such restaurant exists, please try a different entry");
            }
            else
            {
                Console.WriteLine($"FOUND: {foundRestaurant.Name} {foundRestaurant.Address} {foundRestaurant.City} {foundRestaurant.State} {foundRestaurant.ZipCode}");
            }
        }

        /// <summary>
        /// Search for a restaurant by different types of cuisine
        /// </summary>
        private void SearchRestaurantType()
        {
            Log.Debug("SearchRestaurantType was used!!!");
            string input;
            Console.WriteLine("ENTER TYPE OF FOOD");
            input = Console.ReadLine();

            List<Restaurant> foundRestaurants = _userbl.ViewAllRestaurants();
            foreach(Restaurant foundRestaurant in foundRestaurants)
            {
                try
                {
                    if(foundRestaurant.Type == input)
                    {
                        if(foundRestaurant.Type is null)
                        {   
                            Log.Debug("Searching for none existant restauran!!!" + foundRestaurant.Type);
                            Console.WriteLine($"{input} no such restaurant exists, please try a different entry");
                        }
                        else
                        {
                            Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"    Restaurant ID: {foundRestaurant.Id}      Food-Type: {foundRestaurant.Type}      Name: {foundRestaurant.Name}      Address: {foundRestaurant.Address}, {foundRestaurant.City}, {foundRestaurant.State}, {foundRestaurant.ZipCode}");
                            Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                            Log.Debug("Found matching by type restaurants." + foundRestaurant.Name);     
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Did not find restaurant type.");
                    Console.WriteLine(ex);

                }
                finally
                {
                    Log.CloseAndFlush();
                }
                
            }
           
        }

        /// <summary>
        /// Search for a restaurats by rating
        /// </summary>
        private void SearchRestaurantRating()
        {
            Log.Debug("SearchRestaurantRating was used!!!");
            decimal input;
            Console.WriteLine("ENTER RATING NUMBER YOU WANT TO SEE");
            input = Convert.ToDecimal(Console.ReadLine());

            Review foundReview = _userbl.SearchRestaurantRating(input);
            if(foundReview.Rating == 0)
            {
                Console.WriteLine($"{input} no such restaurant exists, please try a different entry");
            }
            else
            {
                Console.WriteLine("FOUND: {0}", foundReview.Rating );
            }
        }

        /// <summary>
        /// Search for a restaurant by city
        /// </summary>
        private void SearchRestaurantCity()
        {
            Log.Debug("SearchRestaurantCity was used!!!");
            string input;
            Console.WriteLine("PLEASE ENTER A CITY FOR YOUR SEARCH");
            input = Console.ReadLine();

            Restaurant foundRestaurant = _userbl.SearchRestaurantCity(input);
            
            if(foundRestaurant.City == input)
            {
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"    Restaurant ID: {foundRestaurant.Id}      Food-Type: {foundRestaurant.Type}      Name: {foundRestaurant.Name}      Address: {foundRestaurant.Address}, {foundRestaurant.City}, {foundRestaurant.State}, {foundRestaurant.ZipCode}");
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
            }
                
            
            if(foundRestaurant.City != input)
            {
                Console.WriteLine($"{input} no such city in our records. Please re-enter.");          
            }
        }

        /// <summary>
        /// Search for a restaurant by ZipCode
        /// </summary>
        private void SearchRestaurantZipCode()
        {
            
            Log.Debug("SearchRestaurantZipCode was used!!!");
            int input;
            Console.WriteLine("PLEASE ENTER A ZIPCODE TO SEARCH");
            
            input = Convert.ToInt32(Console.ReadLine());  
              
            Restaurant foundRestaurant = _userbl.SearchRestaurantZipCode(input);
        
            
            if(foundRestaurant.ZipCode != input)
            {
                Console.WriteLine($"{input} no such restaurant exists, please try a different entry");
            }
            else
            {
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"    Restaurant ID: {foundRestaurant.Id}      Food-Type: {foundRestaurant.Type}      Name: {foundRestaurant.Name}      Address: {foundRestaurant.Address}, {foundRestaurant.City}, {foundRestaurant.State}, {foundRestaurant.ZipCode}");
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");            
            }
                
            
            
        }
        /// <summary>
        /// Function to view all restaurants 
        /// </summary>
        private void ViewAllRestaurants()
        {   Log.Debug("ViewAllRestaurants was used!!!");
            List<Restaurant> restaurants = _userbl.ViewAllRestaurants();
            foreach(Restaurant restaurant in restaurants)
            {
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"    Restaurant ID: {restaurant.Id}      Food-Type: {restaurant.Type}      Name: {restaurant.Name}      Address: {restaurant.Address}, {restaurant.City}, {restaurant.State}, {restaurant.ZipCode}");
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
            }
        }
        /// <summary>
        ///Selects a restaurant from db
        /// </summary>
        /// <param name="restaurants">List of restaurants</param>
        /// <param name="prompt"></param>
        /// <returns>Restaurant</returns>
        public Restaurant SelectRestaurant(List<Restaurant> restaurants, string prompt)
        {
            Log.Debug("SelectRestaurant was used!!!");
            Console.WriteLine(prompt);

            int selection;
            bool valid = false;

            do
            {
                for(int i = 0; i < restaurants.Count; i++)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"[{i}] {restaurants[i].Name}");
                }

                valid = int.TryParse(Console.ReadLine(), out selection);

                if(valid && (selection >= 0 && selection < restaurants.Count))
                {
                    return restaurants[selection];
                }

                Console.WriteLine("___________________________");
                Console.WriteLine("  Enter valid selection  ");
                Console.WriteLine("___________________________");
            }while(true);
        }
        /// <summary>
        /// Selects a user from db
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="prompt"></param>
        /// <returns>User</returns>
        public User SelectUser(List<User> users, string prompt)
        {   
            Log.Debug("SelectUser was used!!!");
            Console.WriteLine(prompt);

            int selection;
            bool valid = false;

            do
            {
                for(int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"[{i}] {users[i].Name}");
                }

                valid = int.TryParse(Console.ReadLine(), out selection);

                if(valid && (selection >= 0 && selection < users.Count))
                {
                    return users[selection];
                }

                Console.WriteLine("___________________________");
                Console.WriteLine("  Enter valid selection  ");
                Console.WriteLine("___________________________");
            }while(true);
        }
        /// <summary>
        /// Lists all users
        /// </summary>
         private void ViewAllUsers()
        {
            Log.Debug("ViewAllUsers was used!!!");
            List<User> users = _userbl.ViewAllUsers();
            foreach(User user in users)
            {
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"    Restaurant ID: {user.Id}      User's name: {user.Name}      User's Email: {user.Email}");
                Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
            }
        }
        /// <summary>
        /// Get restaurant's rating
        /// </summary>
        /// <param name="restaurants">List of restaurants</param>
        /// <returns>Selected Restaurant</returns>
        private Restaurant GetRating(List<Restaurant> restaurants)
        {   
            Log.Debug("GetRating was used!!!");
            int select;

            bool valid = false;


           Console.WriteLine("Which restaurant you want to get the ratings from?");

            do{
                for( int i=0; i<restaurants.Count; i++)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"[{i}] {restaurants[i].Name}");

                }

                valid = int.TryParse(Console.ReadLine(), out select);
               if(valid && (select >= 0 && select < restaurants.Count))
                {

                        return restaurants[select];
                }
                Console.WriteLine("PLEASE USE VALID ENTRY");
            }while(true);

        }
        /// <summary>
        /// Getting AVG rating
        /// </summary>
        public  void GetAvgRating()
        {
            Log.Debug("GetAvgRating was used!!!");

            decimal rating =0;
            decimal div=0;
            decimal average=0;

            List<Restaurant> restaurants = _userbl.ViewAllRestaurants();
            Restaurant operandx = GetRating(restaurants);

            List<Review> reviews = _userbl.ViewAllReviews();


            for( int i = 0; i<reviews.Count; i++)
            {

                if(operandx.Id == reviews[i].RestaurantId)
                {
                    div++;
                    rating = rating + Convert.ToDecimal( reviews[i].Rating);

                }


            }
            average =  rating/div;

            Console.WriteLine("The average of " + operandx.Name + " is: " + average);

        }
         public void LogIn()
        {
            string userName;
            string password;
            
            Console.WriteLine("*********LOGIN*********");
            Console.WriteLine("PLEASE ENTER USER_NAME:");
            userName=Console.ReadLine();
            Console.WriteLine("PLEASE ENTER YOUR PASSWORD:");
            password = Console.ReadLine();

            List<User> users = _userbl.ViewAllUsers();
            // for (int i = 0; i<users.Count; i++)
            foreach(User user in users)
            {       
                

                if(user.Name == userName && user.Password == password)
                {
                    
                    bool repeat = true;
                    do
                    {
                        Console.WriteLine("          WELCOM TO ADMIN MENU         ");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("*        WELCOME TO HIDDEN MENU!      *");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("*      PLEASE MAKE YOUR SELECTION     *");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("[0] LOGOUT");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("[S] TO SEARCH FOR A USER");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("[D] TO DELETE A USER");
                        Console.WriteLine("---------------------------------------");

                        switch(Console.ReadLine())
                        {
                        case "0":
                            Log.Debug("Program was manually exited!!!");
                            Console.WriteLine("You have chosen to exit!");
                            repeat = false;
                        break;

                        case "S":
                            SearchForUser();
                        break;

                        case "D":
                            Console.WriteLine("***************************************");
                            Console.WriteLine("***************************************");
                            Console.WriteLine("**                                   **");
                            Console.WriteLine("**         PLEASE SUBSCRIBE          **");
                            Console.WriteLine("**         TO USE THE BEST           **");
                            Console.WriteLine("**         APP ON THE MARKET         **");
                            Console.WriteLine("**       AND UNLOCK ALL FEATURES     **");
                            Console.WriteLine("**                                   **");
                            Console.WriteLine("***************************************");
                            Console.WriteLine("***************************************");
                        break;

                        default:
                            Console.WriteLine("WRONG SELECTION!!!");
                            Log.Debug("Invalid selection in main menu!!!");
                        break;
                        }
                    }while(repeat);    
                }
              
            }
        }

        public void SearchForUser()
        {
            Log.Debug("SearchForUser was used!!!");
            string input;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("SEARCHING FOR A USER");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("PLEASE ENTER A NAME FOR YOUR SEARCH:");
            input = Console.ReadLine();

            List<User> foundUsers = _userbl.ViewAllUsers();
            foreach(User foundUser in foundUsers)
            {
                if(foundUser.Name == input)
                {
                    if(foundUser.Name == null)
                    {
                        Console.WriteLine($"{input} no such user exists, please try a different entry");
                    }
                    else
                    {
                        Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"    Found user: {foundUser.Id}  {foundUser.Name}");
                        Console.WriteLine("  -----------------------------------------------------------------------------------------------------------------------------");            
                    }
                }
            }   
         }

        //  private Models.User DeleteUser()
        // {
        //     List<User> users = _userbl.ViewAllUsers();
        //     User selectedUser = SelectUser(users, "WHICH USER DO YOU WANT TO DELETE?");
        //     _userbl.DeleteUser(selectedUser);
        //     users = _userbl.ViewAllUsers();
        //     foreach(User user in users)
        //     {
        //         Console.WriteLine(user.Name);
        //     }
        // }
    }

    
}