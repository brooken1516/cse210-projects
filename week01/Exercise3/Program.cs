using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int numberTwo = 0;

        do
        {
            Console.Write("What is your guess? ");
            string userInput = Console.ReadLine();
            numberTwo = int.Parse(userInput);

            if (numberTwo == number)
            {
                Console.WriteLine("Your guess is correct! ");
            }
            else if (numberTwo > number)
            {
                Console.WriteLine("Your guess is too high. ");
            }
            else
            {
                Console.WriteLine("Your guess is too low. ");
            }
        } while (numberTwo != number);
    }
}