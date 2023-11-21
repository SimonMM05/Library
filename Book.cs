using System.Collections.Generic;

public class Book
{
    public string Title { get; }
    public List<Page> Pages { get; }
    public Author Author { get; }

    public Book(string title, List<Page> pages, Author author)
    {
        Title = title;
        Pages = pages;
        Author = author;
    }
}