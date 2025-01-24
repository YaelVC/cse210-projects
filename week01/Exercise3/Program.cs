using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);
        string play = "yes";

        while (play.ToLower() == "yes")
        {
            int guessNumber = -1;
            int count = 0;

            while (guessNumber != magicNumber)
            {
                Console.WriteLine("What is your guess?");
                guessNumber = int.Parse(Console.ReadLine());
                count += 1;

                if (guessNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Congratulations, You guessed it!!!!");
                    Console.WriteLine($"You try  it {count} times");
                }

            }
            Console.WriteLine("Do you play again \"yes\"/\"no\"");
            play = Console.ReadLine();
        }

        Console.WriteLine("Bye!!");
    }
}