// For creativity, I added a "Search by date" feature that allows users to find journal entries from a specific date.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator generator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Search by date");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToString("yyyy-MM-dd"),
                        _promptText = prompt,
                        _entryText = response
                    };

                    myJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry added!");
                    break;

                case "2":
                    Console.WriteLine("All Journal Entries:");
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "5":
                    Console.Write("Enter date to search (yyyy-MM-dd): ");
                    string searchDate = Console.ReadLine();
                    myJournal.SearchByDate(searchDate);
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}