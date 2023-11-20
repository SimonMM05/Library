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
            Console.WriteLine($"Directory not found: {directoryPath}");
            return new List<Author>();
        }

        List<Author> authors = new List<Author>();
        string[] authorFiles = Directory.GetFiles(directoryPath, "*.txt");

        foreach (string authorFile in authorFiles)
        {
            string authorName = Path.GetFileNameWithoutExtension(authorFile);
            List<Book> books = ReadBooksFromAuthorFile(authorFile);
            authors.Add(new Author(authorName, books));
        }

        return authors;
    }

    static List<Book> ReadBooksFromAuthorFile(string authorFile)
    {
        List<Book> books = new List<Book>();
        string[] bookLines = File.ReadAllLines(authorFile);

        foreach (string line in bookLines)
        {
            string title = line.Replace("'", "_");
            List<Page> pages = ReadPagesFromFile($"Book_data/{title}.txt");
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