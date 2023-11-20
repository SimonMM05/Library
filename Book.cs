using System.Collections.Generic;

public class Book
{
    public string Title { get; }
    public Author Author { get; }
    public List<Page> Pages { get; }

    public Book(string title, Author author, List<Page> pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }
}
