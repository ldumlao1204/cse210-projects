using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";
        while (response == "yes")
        {
            Random randomGenerator = new();
            int magicNumber = randomGenerator.Next(1, 100);
            int userGuess = 0;
            int guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;
                if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (userGuess != magicNumber);
            Console.WriteLine($"You made {guessCount} guesses.");
            Console.Write("Do you want to play again (yes/no)? ");
            response = Console.ReadLine();
        }
    }
}