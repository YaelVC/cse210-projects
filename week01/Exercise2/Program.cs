using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage:");

        int percentage = int.Parse(Console.ReadLine());
        string letter = "";
        string sign = "";

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
          else if (percentage >= 60)
        {
            letter = "D";
        }   else if (percentage < 60)
        {
            letter = "F";
        }

        // Stretch Challenge
        int lastDigit = percentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        } else 
        {
            sign = "-";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");
    }
}