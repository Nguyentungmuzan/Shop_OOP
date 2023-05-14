using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public class Order
    {
        // files of Order class
        private int id;
        private User user;
        private DateTime orderDate;
        private List<OrderDetail> orderDetails = new List<OrderDetail>();

        // get and set methods
        public int Id
        {
            get
            {
                return id;
            }
            set { id = value;}
        }

        public List<OrderDetail> OrderDetailsList
        {
            get
            {
                return orderDetails;
            }
            set
            {
                orderDetails = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                orderDate = value;
            }
        }

        public User User
        {
            get
            {
                return user;
            }
            set
            { 
                user = value;
            }
        }

        //constructors
        public Order(int id, User user, DateTime purchaseDate)
        {
            Id = id;
            User = user;
            OrderDate = purchaseDate;
        }

        public Order()
        {

        }

        //Add Order
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailsList.Add(orderDetail);
        }

        //show all order details
        public void printOrderDetails()
        {
            Console.WriteLine("Order detail list: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach ( var orderDetail in OrderDetailsList )
            {
                Console.WriteLine($"Quantity {orderDetail.Order.User.userId}");
                Console.WriteLine($"Username: {orderDetail.Order.User.Name}");
                Console.WriteLine($"Seafood Id: {orderDetail.Seafood.SeafoodId}");
                Console.WriteLine($"Quantity {orderDetail.Quantity}");
            }

            Console.WriteLine("-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }
        //to string
        public override string ToString()
        {
            return "Order ID: " + Id + "client: " + 
                user.Name + "OrderDate: " + orderDate;
        }
    }
}
