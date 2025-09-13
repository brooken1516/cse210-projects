using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;
    private Random _randomGenerator;

    public PromptGenerator()
    {
        _prompts = new List<string>();
        _prompts.Add("Who impacted my life the most today? ");
        _prompts.Add("What was the best part of my day? ");
        _prompts.Add("How did I see the Tender Mercies of the Lord today? ");
        _prompts.Add("What did I experience that was uncomfortable today, and what did I learn from it? ");
        _prompts.Add("What emotion do I need help processing today? ");

        _randomGenerator = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = _randomGenerator.Next(0, _prompts.Count); 
        return _prompts[index];
    }
}