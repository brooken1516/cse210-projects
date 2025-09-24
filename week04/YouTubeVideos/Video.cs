using System;

public class Video
{
    private string _title;
    private string _author;
    private int _length; //(in seconds)
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }


    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Video Title: {_title}, Creator: {_author}, Length: {_length} seconds, Number of Comments {GetCommentCount()}. ");
        foreach (Comment comment in _comments)
        {
            comment.Display();
        }
    }
}
