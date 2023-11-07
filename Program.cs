using System;
using System.Collections.Generic;
using System.IO;

string dataDirectory = "Book_data";

List<Book> books = ReadBooksFromDirectory(dataDirectory);

Library myLibrary = new Library("Bobby Olsen Library", books);
myLibrary.Start();

List<Book> ReadBooksFromDirectory(string directoryPath)
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }

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