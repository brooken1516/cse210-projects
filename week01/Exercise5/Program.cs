using System;

class Program
{
    static void Main(string[] args)
    {
        welcome();
        string userName = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = NumberSquared(number);
        displayResult(userName, squaredNumber);
    }
    static void welcome()
    {
        Console.WriteLine("Welcome to the Program! ");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string userInput = Console.ReadLine();
        return userInput;
    }
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);
        return number;
    }
    static int NumberSquared(int number)
    {
        int numberSquared = number * number;
        return numberSquared;
    }
    static void displayResult(string userName, int numberSquared)
    {
        Console.Write($"{userName}, the square of your favorite number is {numberSquared}. ");
    }
}