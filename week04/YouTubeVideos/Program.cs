using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("Create a Responsive NAVBAR with sidebar animation (CSS Only)", "Coding2go", 896);
        video1.AddComment(new Comment("Cribpost", "You have no idea how useful this will be for me."));
        video1.AddComment(new Comment("Stratfanstl", "Amazing useful demonstratin. Thanks!"));
        video1.AddComment(new Comment("Stanlei", "Bro, God bless you!"));
        video1.AddComment(new Comment("Lazarus", "As a newbie i want to say thank you for this video. Very helpful!"));
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("Learning to code has changed", "TraversyMedia", 1019);
        video2.AddComment(new Comment("Andrewmukare", "You're an amazing teacher Brod!"));
        video2.AddComment(new Comment("Salah-YT", "Thank you so much brod for your amazing video."));
        video2.AddComment(new Comment("Lisp", "After all these years, you're stil a great teacher!"));
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Stop Trying to Memorize code - Do this instead", "WebDevSimplified", 352);
        video3.AddComment(new Comment("Humber", "One of the biggest advises I got in my early days as a developer."));
        video3.AddComment(new Comment("Arahul-Thakare", "Bottom line is, don't memorize the code. Memorize where to find it! Haha!"));
        video3.AddComment(new Comment("CAS81802", "Never memorize what you can look up in books! - Einstein"));
        video3.AddComment(new Comment("Iliashte", "I can add my own words here."));
        videos.Add(video3);

        // Create fourth video
        Video video4 = new Video("The easiest way to build website", "Sajid", 655);
        video4.AddComment(new Comment("MSH14", "I always wonder why people waste their time and energy in just designing small website."));
        video4.AddComment(new Comment("Pighead", "Bro, this is gold!"));
        video4.AddComment(new Comment("Dexter", "Site basics makes a repeatable design."));
        videos.Add(video4);

        // Display information for each video
        Console.WriteLine("=== YouTube Video Tracker ===\n");

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("\nComments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine("\n" + new string('-', 60) + "\n");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}