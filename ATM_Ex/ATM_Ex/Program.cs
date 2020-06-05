using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Ex
{
    class Program
    {
        static void Main(string[] args)
        {

            User[] users = new User[3];

            users[0] = new User("oneName", "oneSurname", "onePan", "onePin", "oneCvc", "oneExpDate", 100);
            users[1] = new User("twoName", "twoSurname", "twoPan", "twoPin", "twoCvc", "twoExpDate", 200);
            users[2] = new User("threeName", "threeSurname", "threePan", "threePin", "threeCvc", "threeExpDate", 300);


            User.PinAccepter(users);
        }
    }

    class Card
    {
        protected string PAN;
        protected string PIN;
        protected string CVC;
        protected string Expiredate;
        protected double Balance;

        public Card(string pAN, string pIN, string cVC, string expiredate, double balance)
        {
            this.PAN = pAN;
            this.PIN = pIN;
            this.CVC = cVC;
            this.Expiredate = expiredate;
            this.Balance = balance;
        }
    }

    class User : Card
    {
        private string Name;
        private string Surname;
        Card CreditCard;

        // CONSTRUCTOR
        public User(string name, string surname, string pAN, string pIN, string cVC, string expiredate, double balance) : base(pAN, pIN, cVC, expiredate, balance)
        {
            this.Name = name;
            this.Surname = surname;
        }

        //  Static method gets the PIN as an input
        public static void PinAccepter(User[] users)
        {
            Console.WriteLine("Enter PIN:");
            string userPin = Console.ReadLine();

            for (int userId = 0; userId < users.Length; userId++)
            {
                if (users[userId].PinChecker(userPin, users, userId))
                {
                    break;
                }
            }
        }

        //  Method which checks whether pin matcher with the any of the users 
        private bool PinChecker(string userPin, User[] users, int userId)
        {
            if (PIN.Equals(userPin))
            {
                Console.WriteLine($"\n Welcome {Name} {Surname} !!!");
                OperationDecider(users, userId);
                return true;
            }
            else
            {
                Console.WriteLine("\nIncorrect Pin");
                PinAccepter(users);
                return false;
            }
        }

        //  Method which defines to show the balance or get the cash
        private void OperationDecider(User[] users, int userId)
        {
            Console.WriteLine("\nEnter Choice of Operation ( '1' to see the balance || '2' to get money ) :");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine($"Balance is -> {Balance}");
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nEnter amount that you want to get");
                Console.WriteLine("\n 1. 10 AZN\n 2. 20 AN\n 3. 50 AZN\n 4. 100 AZN\n 5. CustomAmount");
                int cash = Int32.Parse(Console.ReadLine());
                GetCash(cash, users, userId);
            }
            else
            {
                Console.WriteLine("Invalid operation type !!!");
            }
        }

        // Method which does operation on balance
        private void GetCash(int cash, User[] users, int userId)
        {
            if (cash < 0)
            {
                Console.WriteLine("Invalid cash, Please try again");
            }
            else if (cash > users[userId].Balance)
            {
                Console.WriteLine("No Enough money on your Balance");
            }
            else
            {
                users[userId].Balance -= cash;
                //Console.WriteLine("Loading ...");
                //Console.WriteLine($"Process finished.");
                Console.WriteLine($"On Balance Left: {users[userId].Balance} AZN\n\n");
            }
            OperationDecider(users, userId);
        }
    }
}
