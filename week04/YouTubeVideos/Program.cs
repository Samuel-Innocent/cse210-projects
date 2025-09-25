using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Basics", "Frank Agba", 600);
        Video video2 = new Video("Object-Oriented Programming", "Joshua Daniel", 1200);
        Video video3 = new Video("Encapsulation Explained", "Samuel Innocent", 900);

        // Add comments to video 1
        video1.AddComment(new Comment("Stanley", "This really helped me!"));
        video1.AddComment(new Comment("Bob", "Clear explanation, thanks."));
        video1.AddComment(new Comment("Paul", "Can you do one on interfaces?"));

        // Add comments to video 2
        video2.AddComment(new Comment("Bedner", "Loved the OOP examples."));
        video2.AddComment(new Comment("Brigham", "This made inheritance simple."));
        video2.AddComment(new Comment("Oaks", "Polymorphism is clearer now."));

        // Add comments to video 3
        video3.AddComment(new Comment("Lorenzo", "Great explanation."));
        video3.AddComment(new Comment("Hannah", "Factory pattern finally makes sense."));
        video3.AddComment(new Comment("Isaac", "Please cover Observer next time."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all videos with comments
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
