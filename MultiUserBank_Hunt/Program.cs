using System.Security.Cryptography.X509Certificates;

//Blake Hunt
//NOTES: I don't know why I used a letter system for menus before, I have changed that to a number system.
//NOT IMPLIMENTED: Bank.bankMun could not be accessed. Total available money coud not be displayed.
namespace MultiUserBank_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menus
            bool quit = false;
            bool startLogin = false;
            bool loggedIn = false;

            //Make bank object
            Bank Account = new Bank();

            // BROKE: systm double displayed
            //display initial balance of bank
            Console.WriteLine(Account.BankBal);
            Console.ReadLine();

            //do/while user hasn't quit
            do
            {
                //start menu
                Console.Clear();
                Console.Write("1. Login");
                Console.WriteLine("    2. Quit");
                string startInput = Console.ReadLine();

                //start or quit
                if (OnlyNum(startInput) == true)
                {
                    if (startInput != "1" && startInput != "2")
                    {
                        Console.WriteLine("The only options are 1 and 2.");
                    }
                    if (startInput == "1")
                    {
                        startLogin = true;
                    }
                    if (startInput == "2")
                    {
                        quit = true;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please input numbers only");
                    Console.Read();
                }

                //login menu
                while (startLogin)
                {
                    //ask for login credentials
                    Console.Clear();
                    Console.WriteLine("LOGIN");
                    Console.WriteLine("Enter your Username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your Password:");
                    string password = Console.ReadLine();
                    Console.Clear();

                    //see if those credentials match any account
                    Console.WriteLine(Account.Login(username, password));
                    Console.ReadLine();
                    Console.Clear();

                    int acctNum = Account.AcctNum();

                    if (acctNum > -1)
                    {
                        loggedIn = true;
                    }

                    while (loggedIn)
                    {
                        //get bal from bank
                        double bal = Account.Balance();

                        //print menu
                        Console.Clear();//REMOVE BAL IN LINE BELLOW
                        Console.WriteLine(Account.DisplayName() + "\n\nWhat would you like to do?\n1. Balance\n2. Deposit\n3. Withdraw\n4. Logout");
                        string menuInput = Console.ReadLine();

                        //Balance
                        if (menuInput == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("c", Account.Balance());
                            bal = Account.Balance();
                            Console.ReadLine();
                        }
                        //Deposit
                        if (menuInput == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("How much would you like to deposit?");
                            double add = double.Parse(Console.ReadLine());
                            Console.WriteLine("c", Account.Deposit(add));
                            bal = Account.Balance();
                            Console.Clear();
                            Console.WriteLine("Your balance is: " + bal);
                            Console.ReadLine();
                        }
                        //Withdraw
                        if (menuInput == "3")
                        {
                            Console.Clear();
                            Console.WriteLine("How much would you like to withdraw?");
                            double sub = double.Parse(Console.ReadLine());
                            if (sub > bal)
                            {
                                Console.Clear();
                                Console.WriteLine(sub + "$ is not available in checking\n Current Balance: " +      "c", bal);
                                Console.ReadLine();
                            }
                            else
                            {
                                if (sub > 500)
                                {
                                    int newWithdraw = 0;
                                    Console.WriteLine("Maximum withdraw $500.00");
                                    Console.WriteLine("\n1. Withdraw $500.00\n2. Withdraw other amount");
                                    newWithdraw = int.Parse(Console.ReadLine());
                                    if (newWithdraw == 1)
                                    {
                                        Console.WriteLine("c", Account.Withdraw(500));
                                        bal = Account.Balance();
                                        Console.WriteLine("c", bal);
                                        Console.ReadLine();
                                    }
                                }
                                if (sub < 500)
                                {
                                    Console.WriteLine("c", Account.Withdraw(sub));
                                    bal = Account.Balance();
                                    Console.WriteLine("c", bal);
                                    Console.ReadLine();
                                }
                            }
                        }
                        //Logout
                        if (menuInput == "4")
                        {
                            Console.Clear();
                            loggedIn = false;
                            startLogin = false;
                            Console.WriteLine("c", Account.BankBal);
                            Console.ReadLine();
                        }
                        if (menuInput == "5")
                        {
                            quit = true;
                        }
                    }

                }

            } while (quit == false);

            //check if a string only contains numbers
            bool OnlyNum(string str)
            {
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
                return true;
            }
        }
    }
}
