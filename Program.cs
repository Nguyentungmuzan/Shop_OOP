using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ASM_Final
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Shop shop = new Shop(); // create a new instance of the Shop class
            Shop shop = new Shop();
            User user = new User(); // create a new instance of the User class
            //Login Menu
            bool loggedIn;
            do
            {
                loggedIn = false;
                UI.LoginMenu();
                int chosenNum = int.Parse(Console.ReadLine());
                switch (chosenNum)
                {
                    case 1:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login as shop");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();

                        if (shop.Login(username, password))
                        {
                            loggedIn = true;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login successful!");
                            Console.ForegroundColor = ConsoleColor.White;
                            UI.MenuForShop();

                            while (loggedIn)
                            {
                                int optionShop = int.Parse(Console.ReadLine());
                                int seafoodId;
                                switch (optionShop)
                                {
                                    case 1:
                                        Console.WriteLine("Select seafood category: ");
                                        Console.WriteLine("1. Crab");
                                        Console.WriteLine("2. Shrimp");
                                        // Add more categories as needed
                                        int category = int.Parse(Console.ReadLine());

                                        SeafoodFactory seafoodFactory;
                                        switch (category)
                                        {
                                            case 1:
                                                seafoodFactory = new CrabFactory();
                                                break;
                                            case 2:
                                                seafoodFactory = new ShrimpFactory();
                                                break;
                                            // Add more cases for other categories
                                            default:
                                                Console.WriteLine("Invalid category!");
                                                return;
                                        }

                                        shop.AddSeafood(seafoodFactory);
                                        UI.MenuForShop();
                                        break;

                                    case 2:
                                        foreach (var seafood in shop.Seafoods)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine(seafood.ToString());
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        UI.MenuForShop();
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter Seafood ID: ");
                                        int idSeafoodToUpdate = int.Parse(Console.ReadLine());
                                        while (!shop.checkSeafoodId(idSeafoodToUpdate))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            UI.ModifyFailed();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Enter Seafood ID: ");
                                            idSeafoodToUpdate = int.Parse(Console.ReadLine());
                                        }
                                        shop.UpdateSeafoodById(idSeafoodToUpdate);
                                        UI.MenuForShop();

                                        break;
                                    case 4:
                                        int idToDelete = UI.EnterSeafoodIdToDelete();
                                        while (!shop.checkSeafoodId(idToDelete))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            UI.ModifyFailed();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            idToDelete = UI.EnterSeafoodId();
                                        }

                                        //delete seafood
                                        shop.DeleteSeafood(idToDelete);
                                        break;
                                    case 5:
                                        int idToUpdate = UI.EnterExistSeafoodId();
                                        shop.searchSeafoodById(idToUpdate);
                                        UI.MenuForShop();
                                        break;
                                    case 6:
                                        string nameToSearch = UI.EnterSeafoodName();
                                        shop.searchSeafoodByName(nameToSearch);
                                        UI.MenuForShop();
                                        break;
                                    case 7:
                                        shop.printOrderDetails();
                                        UI.MenuForShop();
                                        break;
                                    case 8:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Logout successful!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("You have successfully logged out of the shop account.");
                                        Console.WriteLine();
                                        loggedIn = false;
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid option! Try again.");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Login failed!");
                            Console.ForegroundColor = ConsoleColor.White;
                            
                        }
                        break;

                    case 2:
                        loggedIn = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Login as user");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Enter username: ");
                        string userUsername = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string userPassword = Console.ReadLine();

                        // call to the login function to check account
                        if (user.Login(userUsername, userPassword))
                        {
                            loggedIn = true;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login successful!");
                            Console.ForegroundColor = ConsoleColor.White;
                            UI.MenuForUser();
                            while (loggedIn)
                            {
                                    int inputNumber = int.Parse(Console.ReadLine());
                                    switch (inputNumber)
                                    {
                                    case 1:
                                        shop.AddUser();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Add User successfully!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                    case 2:
                                        shop.ShowSeafoods();
                                        break;
                                    case 3:
                                        try
                                        {
                                            int orderId = UI.EnterOrderId();
                                            User newUser = new User();
                                            newUser.UserId = UI.EnterUserId();

                                            if (!shop.SearchUserById(newUser.UserId))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("User id is not exits! Please register as a new user.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                shop.AddUser();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Add User successfully!");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }

                                            // then create the order
                                            User objectUser = shop.searchUserWithObjectType(newUser.UserId);
                                            DateTime orderDate = DateTime.Now;

                                            Order seafoodOrder = new Order(orderId, objectUser, orderDate);

                                            user.AddOrder(seafoodOrder);
                                            //Console.WriteLine("Quantity of the Seafood:");
                                            int seafoodQuantity = int.Parse(Console.ReadLine());
                                            bool purchaseComplete = false;
                                            for (int i = 0; i < seafoodQuantity; i++)
                                            {
                                                Seafood seafood = new Seafood();
                                                seafood.SeafoodId = UI.EnterSeafoodId();
                                                if (shop.checkSeafoodId(seafood.SeafoodId))
                                                {
                                                    Seafood seafoodInList = shop.searchSeafoodWithObjectType(seafood.SeafoodId);
                                                    //display seafood information before buying for the user
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine(seafoodInList.ToString());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    //add to new order detail
                                                    int quantity = UI.EnterQuantity();
                                                    OrderDetail orderDetail = new OrderDetail(seafoodInList, seafoodOrder, quantity);
                                                    shop.AddOrderDetail(orderDetail);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    UI.PurchaseSuccessfully();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    purchaseComplete = true;
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                    Console.WriteLine("ID of purchase does not exist! Please check again.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }

                                                if (purchaseComplete) break;
                                            }
                                        }
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("please enter right format number: " + e.Message);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Error: " + e.Message);
                                        }
                                        break;



                                    case 4:
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Logout successful!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("You have successfully logged out of the user account.");
                                            Console.WriteLine();
                                            loggedIn = false; // set the flag to false
                                            break;
                                    default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid option! Try again.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                    }
                                    UI.MenuForUser();
                                } //while (inputNumber != 9 && isLoggedIn); // loop until the user logs out or isLoggedIn is false
                            }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid User!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }


            } while (!loggedIn);
        }
    }
}