using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _unusedPrompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _count = 0;
        _unusedPrompts = new List<string>(_prompts);
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        GetRandomPrompt();
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        // If all prompts have been used, refill the pool
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        Random random = new Random();
        int index = random.Next(_unusedPrompts.Count);
        string selectedPrompt = _unusedPrompts[index];

        // Remove the selected prompt so it won't repeat
        _unusedPrompts.RemoveAt(index);

        Console.WriteLine($"--- {selectedPrompt} ---");
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        return items;
    }
}