using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _unusedQuestions;

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _unusedQuestions = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:\n");
        DisplayPrompt();
        Console.WriteLine("\n\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        // Initialize unused questions pool
        _unusedQuestions = new List<string>(_questions);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShowSpinner(10);
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
        // If all questions have been used, refill the pool
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        Random random = new Random();
        int index = random.Next(_unusedQuestions.Count);
        string selectedQuestion = _unusedQuestions[index];

        // Remove the selected question so it won't repeat
        _unusedQuestions.RemoveAt(index);

        return selectedQuestion;
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---");
    }

    public void DisplayQuestion()
    {
        string question = GetRandomQuestion();
        Console.Write($"> {question} ");
    }
}