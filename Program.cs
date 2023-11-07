using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public void Run()
    {
        string dataDirectory = "Book_data";
        List<Book> books = ReadBooksFromDirectory(dataDirectory);

        Library myLibrary = new Library("My Library", books);
        myLibrary.Start();
    }

    public List<Book> ReadBooksFromDirectory(string directoryPath)
    {
        List<Book> books = new List<Book>();

        string[] bookFiles = Directory.GetFiles(directoryPath, "*.txt");
        foreach (string bookFile in bookFiles)
        {
            string title = Path.GetFileNameWithoutExtension(bookFile);
            string content = File.ReadAllText(bookFile);
            books.Add(new Book(title, content));
        }

        return books;
    }

    public static void Main()
    {
        Program program = new Program();
        program.Run();
    }
}
