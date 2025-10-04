using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
    :base("Breathing Activity", "This activity uses regulated breathing to help you relax.", duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready... ");
        ShowSpinner(8);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        int breathLength = 6;

        bool inhale = true;
        while (DateTime.Now < endTime)
        {
            if (inhale)
            {
                Console.WriteLine();
                Console.WriteLine("Breathe in through nose...");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Breathe out through mouth...");
            }

            for (int i = breathLength; i > 0 && DateTime.Now < endTime; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }

            inhale = !inhale;
        }
        DisplayEndingMessage();
    }
}