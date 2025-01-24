using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        string DisplayWelcome()
        {
            return "Welcome to the Program";
        }

        string PromptUserName()
        {
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();

            return name;
        }

        int PromptUserNumber()
        {
            Console.Write("What is your favorite number?: ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        string DisplayResult(string name, int number)
        {
            return $"{name}, the square of your number is {number}";
        }


        Console.WriteLine($"{DisplayWelcome()}");
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        Console.WriteLine(DisplayResult(name, square)); 
    }
}