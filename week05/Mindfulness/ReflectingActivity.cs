using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(int duration, List<string> prompts, List<string> questions)
    : base("Reflecting Activity", "This activity will help you reflect on the times you have shown strength and resilience. ", duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        Console.WriteLine();

        Console.WriteLine("Press 'Enter' when you are ready to continue... ");
        Console.ReadLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.WriteLine("Now ponder each of the following questions as they relate to this experince. ");
        ShowCountDown(5);

        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
    }

    public void DisplayQuestions()
    {
        string question = GetRandomQuestion();
        Console.Write(question + " ");
        ShowSpinner(5);
        Console.WriteLine();
    }
}