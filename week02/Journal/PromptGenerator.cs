using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Member variables
    public List<string> _prompts = new List<string>();
    private Random _rnd = new Random();
    private int _lastIndex = -1; // track last returned index to avoid immediate repeats

    // Constructor: populate default prompts 
    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        // My creative creative prompts 
        _prompts.Add("What made me smile today?");
        _prompts.Add("What is one small thing I'm grateful for today?");
        _prompts.Add("Do I regret an of my actions today");
        _prompts.Add("What is one thing I learnt today");
    }

    // Returns a random prompt as a string
    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "";
        }

        // If there's only one prompt, return it
        if (_prompts.Count == 1)
        {
            _lastIndex = 0;
            return _prompts[0];
        }

        int index;
        // Choose a random index that is not the same as the last one (to avoid immediate repetition)
        do
        {
            index = _rnd.Next(0, _prompts.Count);
        } while (index == _lastIndex);

        _lastIndex = index;
        return _prompts[index];
    }
}
