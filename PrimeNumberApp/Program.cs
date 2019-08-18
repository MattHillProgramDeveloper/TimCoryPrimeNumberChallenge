using System;
using System.Collections.Generic;
using MattsTools;

namespace MatthewHill_CE08
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 2
                )
            {



                string fileMenuHeader = "Would you like to check if a number is prime?";
                List<string> fileOptions = new List<string>();
                fileOptions.Add("Yes");
                fileOptions.Add("No");
                //This is a custom class for setting up menus in the console. It takes a <String> header and a <List> of options. See the MenusAndValidators.cs file for further explanation.
                NumberMenu mainMenu = new NumberMenu(fileMenuHeader, fileOptions);
                choice = mainMenu.Display();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        //Calls the CheckIfPrime Function if the user wants to do that.
                        Console.WriteLine(CheckIfPrime());
                        break;
                        //Will Cause the program to close.
                    case 2:

                        break;

                    default:
                        break;
                }
                
            }
            

        }
        
        //The meat of the prime checker.
        private static string CheckIfPrime()
        {
            //Custom class used for input validation see the MenusAndValidators.cs file for further explanation.
            Validator validator = new Validator();

            //Instantiate the number we are going to check.
            int isItPrime = 0;
            //A loop to make sure the number we are checking for is over zero.
            while(isItPrime < 1)
            {
                Console.Clear();
                Console.WriteLine("Enter a positive whole number now.");
                isItPrime = validator.GetInt();
                Console.WriteLine("Processing...");
            }

            //testNumber will effectively be the i-- that we use as our divisor.
            int testNumber = isItPrime;
            //This List will store any testNumber that divides equally into the isItPrime number.
            List<int> divisors = new List<int>();

            //This loop checks for a modulus == 0 result and then stores that number into the divisors list
            while (testNumber > 1)
            {
                //Used these lines during testing. Left them in so you can see the thought process.
                //Console.WriteLine(testNumber);
                int remain = isItPrime % testNumber;
                //Used these lines during testing. Left them in so you can see the thought process.
                //Console.WriteLine(remain);
                //Console.WriteLine();
                if (remain == 0)
                {
                    divisors.Add(testNumber);
                }
                testNumber--;
            }
            //Used these lines during testing. Left them in so you can see the thought process.
            //Console.WriteLine("Divisors:");
            //divisors.ForEach(i => Console.Write(i+" "));
            //Console.WriteLine();


            Console.Clear();
            //If the divisors list is greater than 1 then there is more than one divisor greater than 1 and the number is not prime.
            if (divisors.Count > 1)
            {
                return FindPrimeFactors(isItPrime);
                
            }
            //Otherwise, it is prime.
            else
            {
                return isItPrime + " is prime.";
            }
        }
        //This is the function that finds prime factors for non prime numbers.
        private static string FindPrimeFactors(int notPrime)
        {
            //Need a list to store prime factors
            List<int> divisbleBy = new List<int>();
            //instantiate numbers we are gonna use for our math functions
            int maxNumber = notPrime;
            int testnumber = 1;
            //Loop to keep running the math.
            while(testnumber < maxNumber)
            {
                //Starting with adding to the test number. We can start at 2 since we already know the number is not prime.
                testnumber++;
                //Used these lines during testing. Left them in so you can see the thought process.
                //Console.WriteLine(testnumber);
                //Checking to see if the testnumber divides equally into the maxNumber
                if (maxNumber%testnumber == 0)
                {
                    //Making sure we don't add any extra prime factors
                    if (divisbleBy.Contains(testnumber))
                    { }
                    else
                    {
                        divisbleBy.Add(testnumber);
                    }
                    //Reducing the maxNumber and resetting the testnumber before we start over
                    maxNumber = maxNumber / testnumber;
                    testnumber = 1;
                }
                
            }
            Console.Write(notPrime + "'s prime factors are:");
            divisbleBy.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
         
            return notPrime + " is not prime.";
        }
        }// end of class program


}// end of namespace
