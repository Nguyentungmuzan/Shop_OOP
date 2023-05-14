using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public class Shop
    {

        // Class files
        private int id;
        private List<Seafood> seafoods = new List<Seafood>();
        private List<User> users = new List<User>();
        private List<OrderDetail> orderDetails = new List<OrderDetail>();

        //property shop class
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public List<Seafood> Seafoods
        {
            get { return seafoods; }
            set { seafoods = value; }
        }
        public List<User> Users
        {
            get => users;
            set => users = value;
        }
        public List<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }

        //ham constructors
        public Shop(int id)
        {
            Id = id;
        }

        public Shop()
        {

        }
        // add seafood in List

        /*public void AddSeafood()
        {
            int seafoodId = UI.EnterSeafoodId();
            string seafoodName = UI.EnterSeafoodName();
            double seafoodPrice = UI.EnterSeafoodPrice();
            string seafoodCategory = UI.EnterSeafoodCategory(); // Add this line to get category input from user
            Seafood newSeafood = new Seafood(seafoodId, seafoodName, seafoodPrice, seafoodCategory);
            Seafoods.Add(newSeafood);
        }*/

        public void AddSeafood(SeafoodFactory seafoodFactory)
        {
            Console.WriteLine("Enter Seafood ID: ");
            int seafoodId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seafood Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Seafood Price: ");
            double price = double.Parse(Console.ReadLine());

            Seafood seafood = seafoodFactory.CreateSeafood(name, price, seafoodId);
            Seafoods.Add(seafood);
        }



        //show seafood
        public void ShowSeafoods()
        {
            Console.WriteLine("List of Seafoods: ");
            foreach (var seafood in Seafoods)
            {
                Console.WriteLine($"Id of seafood: {seafood.SeafoodId}");
                Console.WriteLine($"Name of seafood: {seafood.Name}");
                Console.WriteLine($"Price of seafood: {seafood.Price}");
                Console.WriteLine($"Category of seafood: {seafood.Category}");
                Console.WriteLine("-------------------------------------");
            }
        }

        //check seafood ID in List
        public bool checkSeafoodId(int id)
        {
            var seafoodId = Seafoods.FirstOrDefault(p => p.SeafoodId == id);
            if ( seafoodId == null )
            {
                return false;
            }
            return true;
        }

        // search seafood by ID inList
        public void searchSeafoodById(int id)
        {
            var seafoods = from p in
                Seafoods where p.SeafoodId == id select p;

            if (seafoods == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("not found");
                Console.ForegroundColor= ConsoleColor.White;
            }

            foreach (var seafood in seafoods)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Id of Seafood: {seafood.SeafoodId}");
                Console.WriteLine($"Name of Seafood: {seafood.Name}");
                Console.WriteLine($"Price of Seafood: {seafood.Price}");
                Console.WriteLine($"Category of Seafood: {seafood.Category}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        // search Seafood by name
        public void searchSeafoodByName(string name)
        {
            var seafoods = from p in Seafoods
                           where p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                           select p;
            foreach (var seafood in seafoods)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Id of Seafood: {seafood.SeafoodId}");
                Console.WriteLine($"Name of Seafood: {seafood.Name}");
                Console.WriteLine($"Price of Seafood: {seafood.Price}");
                Console.WriteLine($"Category of Seafood: {seafood.Category}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Update seafood by ID
        public void UpdateSeafoodById(int id)
        {
            var isExistID = Seafoods.FirstOrDefault
                (p => p.SeafoodId == id);

            if(isExistID == null)
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                Console.WriteLine("Enter Seafood name: ");
                seafoods.FirstOrDefault(p => p.SeafoodId == id)!.Name = Console.ReadLine();
                Console.WriteLine("Enter Seafood price ");
                seafoods.FirstOrDefault(p => p.SeafoodId == id)!.Price = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Update successfully!");
                Console.ForegroundColor= ConsoleColor.White;
            }
        }

        //delete the seafood
        public void DeleteSeafood(int id)
        {
            var isExistID = seafoods.FirstOrDefault(p => p.SeafoodId == id);
            if(isExistID == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not Found");
                Console.ForegroundColor= ConsoleColor.White;
            }
            else
            {
                seafoods.Remove(seafoods.First(p => p.SeafoodId == id));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Delete Seafood successfully!");
                Console.ForegroundColor= ConsoleColor.White;
            }
        }

        //Login for shop
        public bool Login(string inputUsername, string inputPassword)
        {  // default account
            string correctUsername = "shop";
            string correctPassword = "shop";

            if (inputUsername != correctUsername ||
                inputPassword != correctPassword)
            {
                return false;
            }
            return true;
        }

        //add a new user
        public void AddUser()
        {
            User user = new User();
            user.UserId = UI.EnterUserId();
            user.InputInformation();
            // add new user to list
            Users.Add(user);
            UI.MenuForUser();
        }

        //search user by ID
        public bool SearchUserById(int idUserToSearch)
        {
            var userInList = Users.FirstOrDefault(c => c.UserId
                .Equals(idUserToSearch));
            if (userInList == null)
            {
                return false;
            }

            return true;
        }

        // search user object
        public User searchUserWithObjectType( int idUserToSearch)
        {
            var userInList = Users.FirstOrDefault(u => u.UserId 
                == idUserToSearch);
            if (userInList == null)
            {
                Console.WriteLine("Not found");
            }
            return userInList;
        }

        // search Seafood object
        public Seafood searchSeafoodWithObjectType(int idSeafoodToSearch)
        {
            var seafoodInList = Seafoods.FirstOrDefault(p => p.SeafoodId
                == idSeafoodToSearch);
            if (seafoodInList == null)
            {
                Console.WriteLine("Not Found!");
            }

            return seafoodInList;
        }

        // add orderDetail
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            OrderDetails.Add(orderDetail);
        }

        //show all order detail
        public void printOrderDetails()
        {
            Console.WriteLine("Order detail list: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var orderDetail in OrderDetails)
            {
                Console.WriteLine($"Order Id: {orderDetail.Order.User.userId}");
                Console.WriteLine($"Username: {orderDetail.Order.User.Name}");
                Console.WriteLine($"Seafood Id: {orderDetail.Seafood.SeafoodId}");
                Console.WriteLine($"Quantity {orderDetail.Quantity}");
            }

            Console.WriteLine("--------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //get user have bought Seafoods by ID
        public User GetUserOrderById(int idUserToSearch)
        {
            var userInList = Users.FirstOrDefault(u => u.userId
                == idUserToSearch);
            return userInList;
        }
    }
}
