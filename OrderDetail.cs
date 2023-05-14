using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public class OrderDetail
    {
        private Seafood seafood;
        private Order order;
        private int quanity;

        //property methods
        public Seafood Seafood
        {
            get { return seafood; }
            set { seafood = value; }
        }
        public Order Order
        {
            get { return order; }
            set { order = value; }
        }
        public int Quantity
        {
            get { return quanity; }
            set { quanity = value; }
        }
        //Constructor function
        public OrderDetail(Seafood seafood, Order order, int quantity)
        {
            Seafood = seafood;
            Order = order;
            Quantity = quantity;
        }
        public OrderDetail()
        {

        }

        public override string ToString()
        {
            return $"Product ID {Seafood.SeafoodId}, Product name {Seafood.Name} " +
                   $"Price {Seafood.Price}, Product category {Seafood.Category}";
        }
    }
}
