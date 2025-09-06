using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 to exit the program. ");
        Console.Write("Enter number: ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        do
        {
            if (number != -1)
            {
                numbers.Add(number);
                Console.Write("Enter Number: ");
                userInput = Console.ReadLine();
                number = int.Parse(userInput);
            }
        } while (number != 0);

        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}. ");

        double average = sum / (double)numbers.Count;
        Console.WriteLine($"The average is: {average}. ");

        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }
        Console.WriteLine($"The largest number in the list is: {max}. ");
    }
}