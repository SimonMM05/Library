// Author.cs
using System.Collections.Generic;

public class Author
{
    public string Name { get; }
    public List<Book> Books { get; }

    public Author(string name, List<Book> books)
    {
        Name = name;
        Books = books;
    }
}