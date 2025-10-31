using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
        int remainder = grade % 10;
        string sign = "";
        if (remainder >= 7)
        {
            sign = "+";
        }
        else if (remainder < 3)
        {
            sign = "-";
        }
        string letter = "";

        if (grade >= 90)
        {
            if (sign == "-")
            {
                letter = "A-";
            }
            else
            {
                letter = "A";
            }
        }
        else if (grade >= 80)
        {
            letter = "B" + sign;
        }
        else if (grade >= 70)
        {
            letter = "C" + sign;
        }
        else if (grade >= 60)
        {
            letter = "D" + sign;
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is {letter}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("I see, you didn't make it. Better luck next time!");
        }
    }
}