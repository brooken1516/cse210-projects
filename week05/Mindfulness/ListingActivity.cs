using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(int duration, List<string> prompts)
    :base("Listing Activity", "List as many good things as you can in your life for each prompt question. ", duration)
    {
        _count = 0;
        _prompts = prompts;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("You have a few seconds to think... ");
        ShowCountDown(5);

        GetRandomPrompt();
        Console.WriteLine("Prepare your thoughts...");
        ShowSpinner(5);

        GetListFromUser();

        Console.WriteLine($"You entered {_count} items. ");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[index]);
    }

    public void GetListFromUser()
    {
        List<string> userItems = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.WriteLine("Begin listing items now: ");
        while (DateTime.Now < endTime)
        {
            Console.Write(">> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                userItems.Add(item);
            }
        }
        _count = userItems.Count;
    }
}