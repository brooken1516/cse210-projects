using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Intro to Music", "Brooke", 300);

        Comment comment1 = new Comment("Sam", "Great video!");
        video1.AddComment(comment1);

        Comment comment2 = new Comment("Willie", "I'm so excited to start!");
        video1.AddComment(comment2);

        Comment comment3 = new Comment("Josh", "Do you really think this is worth my time? ");
        video1.AddComment(comment3);

        Comment comment4 = new Comment("Sam", "I think that it is totally worth anyoneone's time! ");
        video1.AddComment(comment4);


        Video video2 = new Video("Lesson 1, the staff", "Brooke", 600);

        Comment comment5 = new Comment("Sarah", "This breaks it down so nicely. ");
        video2.AddComment(comment5);

        Comment comment6 = new Comment("Beth", "This was easy to understand, but almost boring. ");
        video2.AddComment(comment6);

        Comment comment7 = new Comment("David", "It's my birthday today! I'm totally asking for this program! ");
        video2.AddComment(comment7);


        Video video3 = new Video("Lesson 2, Treble vrs Bass Clef", "Brooke", 180);

        Comment comment8 = new Comment("Sam", "Ok, I'm really conviced now this is for me! Thank you! ");
        video3.AddComment(comment8);

        Comment comment9 = new Comment("Jessica", "I've been struggling with an easy way to teach my kids. So this is great! ");
        video3.AddComment(comment9);

        Comment comment10 = new Comment("Samantha", "This is a great investment. What's the youngest someone can start? ");
        video3.AddComment(comment10);

        List<Video> videoList = new List<Video>();
        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        foreach (Video video in videoList)
        {
            video.DisplayInfo();
        }
    }
}