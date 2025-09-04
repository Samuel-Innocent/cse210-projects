using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();
        string name = PromptUserName();
        int number = PromtUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name, squared);
    }
        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromtUserNumber ()
        {
            Console.Write("Enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquareNumber(int number)
        {
            int squared = number * number;
            return squared;
        }

        static int DisplayResult(string name, int squared)
        {
            Console.WriteLine($"{name}, the square of your number is {squared}.");
            return squared;
        }



    
}