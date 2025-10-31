using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 0)
                break;
            else
                numbers.Add(userInput);
        }
        int sum = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {(float)sum / numbers.Count}");

        int largestNumber = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
        }

        Console.WriteLine($"The largest number is: {largestNumber}");

        int smallestPositive = int.MaxValue;

        foreach (int num in numbers)
        {
            if (num > 0)
            {
                if (num < smallestPositive)
                {
                    smallestPositive = num;
                }
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}