//For creativity: Included library of scriptures and choose scriptures at random to present to the user.

using System;

class Program
{
    static void Main(string[] args)
    {
        var scriptureLibrary = new List<(Reference, string)>
        {
            (new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            (new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("Moses", 1, 39), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
            (new Reference("Isaiah", 1, 18), "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."),
            (new Reference ("Amos", 3, 7), "Surely the Lord God will do nothing, but he revealeth his secret unto his servants the prophets."),
        };

        var random = new Random();
        var selected = scriptureLibrary[random.Next(scriptureLibrary.Count)];
        var scripture = new Scripture(selected.Item1, selected.Item2);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompleteHidden())
            {
                Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}