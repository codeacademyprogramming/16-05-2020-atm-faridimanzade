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


            Action action = new Action();
            action.PinAccepter(users);
        }
    }


    class Card
    {
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public string Expiredate { get; set; }
        public double Balance { get; set; }
        public Card(string pAN, string pIN, string cVC, string expiredate, double balance)
        {
            this.PAN = pAN;
            this.PIN = pIN;
            this.CVC = cVC;
            this.Expiredate = expiredate;
            this.Balance = balance;
        }
    }


    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Card Creditcard;

        public User(string name, string surname, string pAN, string pIN, string cVC, string expiredate, double balance)
        {
            this.Name = name;
            this.Surname = surname;
            this.Creditcard = new Card(pAN, pIN, cVC, expiredate, balance);
        }
    }


    class Action
    {
        //  Method which gets pin and checks whether there is user matching with given pin
        public void PinAccepter(User[] users)
        {
            Console.WriteLine("Enter PIN:");
            string userPin = Console.ReadLine();

            for (int userId = 0; userId < users.Length; userId++)
            {
                if (users[userId].Creditcard.PIN == userPin)
                {
                    Console.WriteLine($"Welcome {users[userId].Name}  {users[userId].Surname}");
                    OperationDecider(users[userId]);
                    break;
                }
                //else
                //{
                //    PinAccepter(users);
                //}
            }
        }


        //  Method which defines to show the balance or get the cash
        private void OperationDecider(User user)
        {
            Console.WriteLine("\nEnter Choice of Operation ( '1' to see the balance || '2' to get money ) :");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine($"Balance is -> {user.Creditcard.Balance}");
            }
            else if (choice == 2)
            {
                Console.WriteLine("\nEnter amount that you want to get");
                Console.WriteLine("\n 1. 10 AZN\n 2. 20 AN\n 3. 50 AZN\n 4. 100 AZN\n 5. CustomAmount");
                int cash = Int32.Parse(Console.ReadLine());
                GetCash(cash, user);
            }
            else
            {
                Console.WriteLine("Invalid operation type !!!");
            }
        }


        // Method which does operation on balance
        private void GetCash(int cash, User user)
        {
            if (cash < 0)
            {
                Console.WriteLine("Invalid cash, Please try again");
            }
            else if (cash > user.Creditcard.Balance)
            {
                Console.WriteLine("No Enough money on your Balance");
            }
            else
            {
                user.Creditcard.Balance -= cash;
                Console.WriteLine("Loading ...");
                Console.WriteLine($"Process finished.");
                Console.WriteLine($"On Balance Left: {user.Creditcard.Balance} AZN\n\n");
            }
            OperationDecider(user);
        }
    }

}
