using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Library library = new Library("Bobby Olsen Library", ReadAuthorsFromDirectory("Book_data"));

        library.Start();
    }

    static List<Author> ReadAuthorsFromDirectory(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        List<Author> authors = new List<Author>();
        string[] authorDirectories = Directory.GetDirectories(directoryPath);

        foreach (string authorDirectory in authorDirectories)
        {
            string authorName = Path.GetFileName(authorDirectory);
            List<Book> books = ReadBooksFromDirectory(authorDirectory);
            authors.Add(new Author(authorName, books));
        }

        return authors;
    }

    static List<Book> ReadBooksFromDirectory(string directoryPath)
    {
        List<Book> books = new List<Book>();
        string[] bookFiles = Directory.GetFiles(directoryPath, "*.txt");

        foreach (string bookFile in bookFiles)
        {
            string title = Path.GetFileNameWithoutExtension(bookFile);
            title = title.Replace("'", "_");
            List<Page> pages = ReadPagesFromFile(bookFile);
            books.Add(new Book(title, pages));
        }

        return books;
    }

    static List<Page> ReadPagesFromFile(string filePath)
    {
        List<Page> pages = new List<Page>();
        string content = File.ReadAllText(filePath);
        string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            pages.Add(new Page(lines[i]));
        }

        return pages;
    }
}
