using System;
using System.Collections.Generic;

Console.WriteLine("Hello World! This is the Exercise4 Project.");

Console.WriteLine("Enter a list of numbers, type 0 when finish");

List<int> numbers = new List<int>();
int number = -1;
float add = 0;

while (number != 0)
{
    Console.Write("Enter number: ");
    number = int.Parse(Console.ReadLine());

    if (number != 0)
    {
        numbers.Add(number);
    }
}

foreach (int item in numbers)
{
    add += item;
}

float average = add / numbers.Count;
int maximo = numbers.Max();

// Stretch Challenges
List<int> positiveNumbers = new List<int>();

// Find the smallest positive number in the list
foreach (int element in numbers)
{
    if (element >= 0)
    {
        positiveNumbers.Add(element);
    }
}

int smallestPositiveNumber = numbers.Min();

// Sort list
numbers.Sort();


Console.WriteLine($"The sum is: {add}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {maximo}");

Console.WriteLine("The sorted list is: ");

foreach (int item in numbers)
{
    Console.WriteLine($"{item}");
}