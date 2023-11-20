// Book.cs
using System.Collections.Generic;

public class Book
{
    public string Title { get; }
    public List<Page> Pages { get; }
    public string? Author { get; internal set; }

    public Book(string title, List<Page> pages)
    {
        Title = title;
        Pages = pages;
    }
}