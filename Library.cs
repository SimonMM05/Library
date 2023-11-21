using System;
using System.Collections.Generic;
using System.IO;

public class Library
{
    private string name;
    private List<Author> authors;

    public List<Author> Authors => authors;

    public Library(string name, List<Author> authors)
    {
        this.name = name;
        this.authors = authors ?? new List<Author>();
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {name ?? "Unknown Library"}!");
        DisplayMainMenu();
    }

    private void DisplayMainMenu()
    {
        while (true)
        {
            Console.Clear(); // Clear the console before displaying the main menu

            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Browse Authors");
            Console.WriteLine("2. Exit Library");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BrowseAuthors();
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

    private void BrowseAuthors()
    {
        Console.Clear();
        Console.WriteLine("Available Authors:");

        for (int i = 0; i < authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {(authors[i]?.Name ?? "Unknown Author")}");
        }

        Console.WriteLine("Enter the author number to browse (or 'back' to return to the main menu):");
        string choice = Console.ReadLine();

        if (choice == "back")
        {
            return;
        }

        if (int.TryParse(choice, out int authorNumber) && authorNumber >= 1 && authorNumber <= authors.Count)
        {
            BrowseBooks(authors[authorNumber - 1]);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a valid author number.");
        }
    }

    private void BrowseBooks(Author author)
    {
        Console.Clear();

        if (author != null)
        {
            Console.WriteLine($"Browsing books by {(author.Name ?? "Unknown Author")}:");
            for (int i = 0; i < author.Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {author.Books[i].Title}");
            }

            Console.WriteLine("Enter the book number to read (or 'back' to return to the main menu):");
            string choice = Console.ReadLine();

            if (choice == "back")
            {
                return;
            }

            if (int.TryParse(choice, out int bookNumber) && bookNumber >= 1 && bookNumber <= author.Books.Count)
            {
                ReadBookPages(author.Books[bookNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid book number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid author selection. Returning to the main menu...");
        }
    }

    private void ReadBookPages(Book book)
    {
        Console.Clear();

        if (book != null)
        {
            Console.WriteLine($"Reading '{book.Title}' by {book.Author?.Name ?? "Unknown Author"}:");

            int wordsPerPage = 100;
            int currentPage = 0;
            int totalWords = 0;

            while (currentPage < book.Pages.Count)
            {
                var page = book.Pages[currentPage];

                totalWords += page.GetWordCount();

                Console.WriteLine($"{page.Content}\n");

                if (totalWords > wordsPerPage)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Press 'N' for the next page, 'P' for the previous page, 'B' to go back to the main menu, or any other key to continue:");

                    string userChoice = Console.ReadLine();

                    switch (userChoice?.ToUpper())
                    {
                        case "N":
                            totalWords = 0;
                            currentPage++;
                            break;
                        case "P":
                            if (currentPage > 0)
                            {
                                currentPage--;
                                totalWords = 0;
                            }
                            break;
                        case "B":
                            return;
                        default:
                            break;
                    }

                    Console.Clear();
                    Console.WriteLine($"Reading '{book.Title}' by {book.Author?.Name ?? "Unknown Author"}:");
                }
                else
                {
                    currentPage++;
                }
            }

            Console.WriteLine("\nEnd of Book. Press any key to return to the main menu...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid book selection. Returning to the main menu...");
        }
    }
}