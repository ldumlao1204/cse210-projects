//For Creativity: Added level progression, visual progress bar, level up message, enhanced player stats display, and point tracking.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}