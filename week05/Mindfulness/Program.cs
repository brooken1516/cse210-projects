// To exceed requirements I created a new activity called Joy Activity that is similar to the listing activity
// but is focused on helping users get an extra boost from joy and not just general positives. 

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Joy Activity");
            Console.WriteLine("5. Quit");

            Console.Write("Enter the number of your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity(0);
                breathing.SetDurationFromUser();
                breathing.Run();
            }
            else if (choice == "2")
            {
                List<string> prompts = new List<string>
                {
                    "Who are people that you appreciate?",
                    "What are personal strengths of yours?",
                    "Who are people that you have helped this week?",
                    "When have you felt the Holy Ghost this month?",
                    "Who are some of your personal heroes?",
                };
                ListingActivity listing = new ListingActivity(0, prompts);
                listing.SetDurationFromUser();
                listing.Run();
            }
            else if (choice == "3")
            {
                List<string> prompts = new List<string>
                {
                "Think of a time when you stood up for someone else: ",
                "Think of a time when you did something really difficult: ",
                "Think of a time when you helped someone in need: ",
                "Think of a time when you did something truly selfless: ",
                };
                List<string> questions = new List<string>
                {
                    "Why was this experience meaningful to you? ",
                    "Have you ever done anything like this before? ",
                    "How did you get started? ",
                    "How did you feel when it was complete? ",
                    "What made this time different than other times when you were not as successful? ",
                    "What is your favorite thing about this experience? ",
                    "What could you learn from this experience that applies to other situations? ",
                    "What did you learn about yourself through this experience? ",
                    "How can you keep this experience in mind in the future? ",
                };
                ReflectingActivity reflecting = new ReflectingActivity(0, prompts, questions);
                reflecting.SetDurationFromUser();
                reflecting.Run();
            }

            else if (choice == "4")
            {
                List<string> prompts = new List<string>
                {
                    "Who had brought you joy today?",
                    "What is your most joyful memory?",
                    "What is your most joyful experience?",
                    "What foods bring you joy?",
                    "What acts of service have brought you joy?",
                };
                JoyActivity joy = new JoyActivity(0, prompts);
                joy.SetDurationFromUser();
                joy.Run();
            }

            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }
        }
    }
}