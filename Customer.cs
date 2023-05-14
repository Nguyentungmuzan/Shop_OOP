using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    public abstract class Customer
    {
        //field cac truong
        private string name;
        private int age;
        private string address;
        private string phone;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 3)
                    throw new
                        ArgumentException("Email length must be greater than 3 characters");
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new
                        ArgumentException("Age must be greater than 0!");
                age = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (value.Length < 0)
                    throw new ArgumentException("Address must greater than 2!");
                address = value;
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.Length < 10)
                    throw new ArgumentException("Phone number must be at least 10 number!");
                phone = value;
            }
        }

        // Constructors function
        public Customer(string name, int age, string address, string phone)
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
            this.Phone = phone;
        }
        public Customer()
        {

        }

        //input information
        public abstract void InputInformation();
    }
}
