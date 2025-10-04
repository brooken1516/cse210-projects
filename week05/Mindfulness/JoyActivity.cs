using System;
using System.Collections.Generic;

public class JoyActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public JoyActivity(int duration, List<string> prompts)
    :base("Joy Activity", "Use the prompt to list the things that bring you Joy. ", duration)
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
        Console.WriteLine();
        Console.WriteLine("Prepare your thoughts...");
        ShowSpinner(5);

        GetListFromUser();

        Console.WriteLine($"You entered {_count} items. ");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        string prompt = _prompts[promptIndex];
        Console.WriteLine(prompt);
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