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
        string[] authorFolders = Directory.GetDirectories(directoryPath);

        foreach (string authorFolder in authorFolders)
        {
            string authorName = Path.GetFileName(authorFolder);
            List<Book> books = ReadBooksFromAuthorFile(authorFolder);
            authors.Add(new Author(authorName, books));
        }

        return authors;
    }

    static List<Book> ReadBooksFromAuthorFile(string authorFolder)
    {
        List<Book> books = new List<Book>();
        string[] bookFiles = Directory.GetFiles(authorFolder, "*.txt");

        foreach (string bookFile in bookFiles)
        {
            string title = Path.GetFileNameWithoutExtension(bookFile);
            List<Page> pages = ReadPagesFromFile(bookFile);
            books.Add(new Book(title, pages, new Author("Unknown Author", new List<Book>())));
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