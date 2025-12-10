using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running("08 Dec 2025", 30, 5.5);
        activities.Add(running);

        Cycling cycling = new Cycling("09 Dec 2025", 45, 24);
        activities.Add(cycling);

        Swimming swimming = new Swimming("10 Dec 2025", 40, 30);
        activities.Add(swimming);

        Console.WriteLine();
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine();

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}