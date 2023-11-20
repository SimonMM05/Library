using System;

public class Library
{
    private string name;
    private List<Author> authors;

    public Library(string name, List<Author> authors)
    {
        this.name = name;
        this.authors = authors;
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
        Console.WriteLine("Available Authors:");
        for (int i = 0; i < authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {authors[i].Name}");
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
        Console.Clear(); // Clear the console
        Console.WriteLine($"Browsing books by {author.Name}:");

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

    private void ReadBookPages(Book book)
    {
        Console.Clear(); // Clear the console
        Console.WriteLine($"Reading '{book.Title}' by {book.Author.Name}:");

        int linesPerPage = Console.WindowHeight - 5; // Adjusted for window title and prompt

        int currentPage = 0;
        int totalPages = (int)Math.Ceiling((double)book.Pages.Count / linesPerPage);

        do
        {
            Console.Clear(); // Clear the console before displaying the next page
            Console.WriteLine($"Reading '{book.Title}' by {book.Author.Name}: Page {currentPage + 1} of {totalPages}\n");

            int startIndex = currentPage * linesPerPage;
            int endIndex = Math.Min(startIndex + linesPerPage, book.Pages.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                Console.WriteLine($"{book.Pages[i].Content}");
                Console.WriteLine();
            }

            Console.WriteLine("Press 'N' for the next page, 'P' for the previous page, or 'B' to go back to the main menu:");

            string choice = Console.ReadLine();

            switch (choice.ToUpper())
            {
                case "N":
                    currentPage++;
                    break;
                case "P":
                    currentPage = Math.Max(0, currentPage - 1);
                    break;
                case "B":
                    return; // Exit the method and go back to the main menu
                default:
                    Console.WriteLine("Invalid choice. Please enter 'N', 'P', or 'B'.");
                    break;
            }

        } while (currentPage < totalPages);

        Console.WriteLine("\nEnd of Book. Press any key to return to the main menu...");
        Console.ReadKey();
    }
}
