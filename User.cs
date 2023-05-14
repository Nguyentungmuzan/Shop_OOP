using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public class User : Customer, ILogin
    {
        public int userId { get; set; }
        private List<Order> orders = new List<Order>();

        // get and seet method is property
        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        // user constructore function
        public User(int userId)
        {
            UserId = userId;
        }
        public User()
        {

        }
        public User(string name, int age, string address, 
            string phone, int userId)
            : base (name, age, address, phone)
        {
            UserId = userId;
        }

        //create user account
        public override void InputInformation()
        {
            try
            {
                this.Name = UI.EnterUserEmail();
                this.Age = UI.EnterUserAge();
                this.Phone = UI.EnterUserPhoneNumber();
                this.Address = UI.EnterUserAddress();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public bool Login(string inputUsername, string inputPassword)
        {  // default account
            string correctUsername = "user";
            string correctPassword = "user";

            if (inputUsername != correctUsername ||
                inputPassword != correctPassword)
            {
                return false;
            }
            return true;
        }

        //remove the order
        public bool RemoveOrder(Order order)
        {
            var orderInList = Orders.FirstOrDefault(p =>
                p.Id == order.Id);
            if (orderInList == null)
            {
                Console.WriteLine("Purchase not found!");
                return false;
            }

            Orders.Remove(order);
            return true;
        }

        //search id of purchase
        public Order searchOrderById(int id)
        {
            var orderInList = Orders.FirstOrDefault(p => p.Id == id);
            return orderInList;
        }

        public override string ToString()
        {
            return "User ID: " + UserId + " Name: " + 
            Name + " Address: " + Address + "Phone number: " + Phone;
        }

        internal void AddOrder(Order seafoodOrder)
        {
            orders.Add(seafoodOrder);
        }
    }
}
