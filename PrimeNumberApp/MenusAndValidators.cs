using System;
using System.Collections.Generic;

namespace MattsTools
{
    class Validator
    {
        public int GetInt()
        {
            int res;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Please enter an integer value.");
                }
            }
        }

        public float GetFloat()
        {
            float res;
            while (true)
            {
                string input = Console.ReadLine();
                if (float.TryParse(input, out res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Please enter a numeric value.");
                }
            }
        }

        public decimal GetDecimal()
        {
            decimal res;
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Please enter a decimal value.");
                }
            }
        }

        public string GetString()
        {

            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Please enter a value.");
                }
            }
        }
    }

    abstract class Menu
    {
        //Needed private properties
        private string header { get; set; }




        //Constructors
        public Menu() { }
        public Menu(string header)
        {
            Header = header;
        }

        //Getters and Setters
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }





    }

    class WordMenu : Menu
    {
        public Dictionary<string, string> Options { get; set; }
        public WordMenu(string header, Dictionary<string, string> options) :
            base(header)
        {
            Options = options;
        }

        public string Display()
        {

            Console.WriteLine(Header);
            List<string> keys = new List<string>();
            foreach (var option in Options)
            {
                Console.WriteLine(option.Key + ": \t" + option.Value);
                keys.Add(option.Key.ToLower());
            }
            Console.WriteLine("\r\n");
            while (true)
            {
                Validator validator = new Validator();
                string res = validator.GetString().ToLower();
                if (keys.Contains(res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Please enter one of the above menu options.");
                }
            }// End of the menu loop

        }


    }

    class NumberMenu : Menu
    {
        public List<string> Options { get; set; }
        public NumberMenu(string header, List<string> options) :
            base(header)
        {
            Options = options;
        }

        public int Display()
        {

            Console.WriteLine(Header);
            int i = 1;
            foreach (var option in Options)
            {
                Console.WriteLine(i + ": " + option);
                i++;
            }
            Console.WriteLine("\r\n");
            while (true)
            {
                Validator validator = new Validator();
                int res = validator.GetInt();
                //makes sure the number picked is a number on the list
                if (res <= i - 1 && res > 0)
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Please enter a whole number between 1 and {0}.", i - 1);
                }
            }// End of the menu loop

        }

        public string DisplayReturnsString()
        {


            Console.WriteLine(Header);
            int i = 1;
            foreach (var option in Options)
            {
                Console.WriteLine(i + ": " + option);
                i++;
            }
            Console.WriteLine("\r\n");
            while (true)
            {
                Validator validator = new Validator();
                int res = validator.GetInt();
                //makes sure the number picked is a number on the list
                if (res <= i - 1 && res > 0)
                {
                    return Options[res - 1];
                }
                else
                {
                    Console.WriteLine("Please enter a whole number between 1 and {0}.", i - 1);
                }
            }// End of the menu loop

        }


    }


    class FancyMenu : Menu
    {
        public Dictionary<string, string> Options { get; set; }
        public FancyMenu(string header, Dictionary<string, string> options) :
            base(header)
        {
            Options = options;
        }

        public string Display()
        {


            Console.WriteLine(Header);
            List<string> keys = new List<string>();
            int menuNumber = 0;
            foreach (var option in Options)
            {
                menuNumber++;
                Console.WriteLine(menuNumber + " - " + option.Key + ": " + option.Value);
                keys.Add(option.Key.ToLower());
            }
            Console.WriteLine("\r\n");
            while (true)
            {
                Validator validator = new Validator();

                string res = validator.GetString().ToLower();
                int resNum;

                if (int.TryParse(res, out resNum))
                {
                    //logic for menu options with numbers
                    if (resNum > 0 && resNum <= keys.Count)
                    {
                        return keys[resNum - 1];
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number or type a valid menu option.");
                    }
                }
                else if (keys.Contains(res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number or type a valid menu option.");
                }

            }// End of the menu loop

        }


    }

}
