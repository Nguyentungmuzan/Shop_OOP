using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    internal class UI
    {
        public static void LoginMenu()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("|         Login Menu          |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("| 1. Login as shop            |");
            Console.WriteLine("| 2. Login as user            |");
            Console.WriteLine("| 3. Exit                     |");
            Console.WriteLine("*******************************");
            Console.Write("Enter your choice: ");
        }

        public static void MenuForShop()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("|       Shop Menu             |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("| 1. Add Seafood              |");
            Console.WriteLine("| 2. Show all Seafoods        |");
            Console.WriteLine("| 3. Update Seafoods          |");
            Console.WriteLine("| 4. Delete Seafood           |");
            Console.WriteLine("| 5. Search id of Seafood     |");
            Console.WriteLine("| 6. Search name of Seafood   |");
            Console.WriteLine("| 7. View all orders          |");
            Console.WriteLine("| 8. Logout                   |");
            Console.WriteLine("*******************************");
            Console.Write("Enter your choice: ");
        }

        public static void MenuForUser()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("|        User Menu            |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("| 1. Add a new user account   |");
            Console.WriteLine("| 2. Show all products        |");
            Console.WriteLine("| 3. Purchase a product       |");
            Console.WriteLine("| 4. Logout                   |");
            Console.WriteLine("*******************************");
            Console.Write("Enter your choice: ");
        }
        // user info
        public static string EnterUserName()
        {
            Console.WriteLine("Enter Username: ");
            return Console.ReadLine();
        }

        public static string EnterUserEmail()
        {
            Console.WriteLine("Enter user email: ");
            return Console.ReadLine();
        }

        public static string EnterUserPhoneNumber()
        {
            Console.WriteLine("Enter user Phonenumber: ");
            return Console.ReadLine();
        }
        public static string EnterUserAddress()
        {
            Console.WriteLine("Enter user Address: ");
            return Console.ReadLine();
        }
        public static int EnterUserAge()
        {
            Console.WriteLine("Enter user age: ");
            return int.Parse(Console.ReadLine());
        }
        public static int EnterUserId()
        {
            Console.WriteLine("Enter user ID: ");
            return int.Parse(Console.ReadLine());
        }
        public static string EnterUserPassword()
        {
            Console.WriteLine("Enter user password: ");
            return Console.ReadLine();
        }

        // Seafood
        public static int EnterSeafoodId()
        {
            Console.WriteLine("Enter Seafood ID: ");
            return int.Parse(Console.ReadLine());
        }
        public static int EnterSeafoodIdToDelete()
        {
            Console.WriteLine("Enter Seafood ID: ");
            return int.Parse(Console.ReadLine());
        }
        public static double EnterSeafoodPrice()
        {
            Console.WriteLine("Enter price: ");
            return double.Parse(Console.ReadLine());
        }
        public static string EnterSeafoodName()
        {
            Console.WriteLine("Enter name of Seafood: ");
            return Console.ReadLine();
        }
        public static string EnterSeafoodCategory()
        {
            Console.WriteLine("Enter category of Seafood: ");
            return Console.ReadLine();
        }
        public static int EnterExistSeafoodId()
        {
            Console.WriteLine("Enter the ID of Seafood: ");
            return int.Parse(Console.ReadLine());
        }
        // show Notice
        public static string DialogIdExisted()
        {
            return "Can not create! Id already exist!, try another!";
        }

        //Mofidy message successfully!
        public static void ModifySuccessfully()
        {
            Console.WriteLine("Modify data successfully!");
        }

        // bought product successfully
        public static void PurchaseSuccessfully()
        {
            Console.WriteLine("Buy product successfully!");
        }

        //modify message fail!
        public static string ModifyFailed()
        {
            return "Modify data failed!";
        }

        //order seafood
        public static int EnterOrderId()
        {
            Console.WriteLine("Enter purchase Id: ");
            return int.Parse(Console.ReadLine());
        }

        public static int EnterQuantity()
        {
            Console.WriteLine("Enter quantity: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
