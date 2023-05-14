using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public class Seafood
    {
        private int seafoodId;
        private string name;
        private double price;
        private string category;

        //constructor function
        public Seafood(int seafoodId, string name, double price, string category)
        {
            SeafoodId = seafoodId;
            Name = name;
            Price = price;
            Category = category;
        }

        public Seafood()
        {

        }
        //property
        public int SeafoodId
        {
            get{ return seafoodId; }
            set{ seafoodId = value;}
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Category
        {
            get { return category; }
            set
            { 
                category = value;
            }
        }
        public override string ToString()
        {
            return "Seafood ID: " + SeafoodId + " |Seafood name: " + name
                + " |Price: " + price + " |Category: " + category;
        }
    }
}
