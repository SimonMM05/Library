using System;
using System.Collections.Generic;

public class Library
{
    private string name;
    private List<Book> books;

    public Library(string name, List<Book> books)
    {
        this.name = name;
        this.books = books;
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {name}!");
        DisplayMainMenu();
    }

    private void DisplayMainMenu()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Browse Books");
            Console.WriteLine("2. Exit Library");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BrowseBooks();
                    break;
                case "2":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    private void BrowseBooks()
    {
        Console.WriteLine("Available Books:");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i].Title}");
        }

        Console.WriteLine("Enter the book number to read (or 'back' to return to the main menu):");
        string choice = Console.ReadLine();

        if (choice == "back")
        {
            return;
        }

        if (int.TryParse(choice, out int bookNumber) && bookNumber >= 1 && bookNumber <= books.Count)
        {
            ReadBook(books[bookNumber - 1]);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid book number.");
        }
    }

    private void ReadBook(Book book)
    {
        Console.Clear(); // Clear the console
        Console.WriteLine($"Reading '{book.Title}':");

        // Control the speed of text output (e.g., 50 milliseconds per character)
        int delayPerCharacter = 8;

        foreach (char character in book.Content)
        {
            Console.Write(character);
            Thread.Sleep(delayPerCharacter);
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }
}
