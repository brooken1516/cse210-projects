using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void SetDurationFromUser()
    {
        Console.Write("How long would you like to participate in this activity? (Enter time in seconds.) ");
        string input = Console.ReadLine();
        int duration;

        while (!int.TryParse(input, out duration) || duration <= 0)
        {
            Console.Write("Invalid input. Enter a positive whole number of seconds. ");
            input = Console.ReadLine();
        }
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public string DisplayStartingMessage()
    {
        Console.WriteLine("Welcome to the " + _name + "!");
        Console.WriteLine(_description);
        Thread.Sleep(4000);
        return "Retrieving your selected activity now. " + _name;
    }

    public string DisplayEndingMessage()
    {
        Console.WriteLine("Thank you for completing the " + _name + "!");
        ShowSpinner(3);
        Console.WriteLine("Duration: "   + _duration + " seconds");
        ShowSpinner(3);
        return "Please visit " + _name + " again soon";
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }                                 
    }

    public void ShowCountDown(int seconds)
    {
        Console.WriteLine("Get Ready...");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}