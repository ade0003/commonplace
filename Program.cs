using System.Runtime.CompilerServices;

Console.WriteLine("====================================================\n");
Console.WriteLine("===============Welcome to Commonplace===============");
Console.WriteLine("=========A space for your books and films.==========\n");
Console.WriteLine("====================================================\n\n");

List<Book> books = new List<Book>();
List<Film> films = new List<Film>();

int choice = 0;
while (choice != 5)
{
    Console.WriteLine("Please select an option from the menu below:\n");
    Console.WriteLine("1.Add a book");
    Console.WriteLine("2.Add a film");
    Console.WriteLine("3.View all books");
    Console.WriteLine("4.View all films");
    Console.WriteLine("5.Exit\n");

    bool success = int.TryParse(Console.ReadLine(), out choice);
    if (!success)
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:

            Console.WriteLine("Enter the title of the book:");
            string? bookTitle = Console.ReadLine();
            Console.WriteLine("Enter the Author's name: ");
            string? author = Console.ReadLine();
            Console.WriteLine("Did you finish reading (y/n) ");
            string? completed = Console.ReadLine();
            bool? complete = null;

            if (completed == "y")
            {
                complete = true;
            }
            else if (completed == "n")
            {
                complete = false;
            }
            Book book = new Book(bookTitle, author, complete);
            books.Add(book);
            Console.WriteLine(
                $"Book added: {book.Title} by {book.Author}. Completed: {book.getComplete()}"
            );
            break;

        case 2:
            Console.WriteLine("Enter the title of the film:");
            string? filmTitle = Console.ReadLine();
            Console.WriteLine("Enter the Director's name: ");
            string? director = Console.ReadLine();
            Console.WriteLine("Enter the release year: ");
            int releaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Did you finish watching (y/n) ");
            completed = Console.ReadLine();
            complete = null;

            if (completed == "y")
            {
                complete = true;
            }
            else if (completed == "n")
            {
                complete = false;
            }
            Film film = new Film(filmTitle, director, releaseYear, complete);
            films.Add(film);
            Console.WriteLine(
                $"Film added: {film.Title} directed by {film.Director}. Completed: {film.getComplete()}"
            );
            break;

        case 3:
            Console.WriteLine("============================================\n");
            Console.WriteLine("===============Your Books====================\n");
            foreach (var b in books)
            {
                Console.WriteLine(
                    $"Title: {b.Title}, Author: {b.Author}, Completed: {b.getComplete()}"
                );
            }
            break;

        case 4:
            Console.WriteLine("============================================\n");
            Console.WriteLine("===============Your Films====================\n");
            foreach (var f in films)
            {
                Console.WriteLine(
                    $"Title: {f.Title}, Director: {f.Director}, Release Year: {f.ReleaseYear}, Completed: {f.getComplete()}"
                );
            }
            break;

        default:
            break;
    }
}


public abstract class Media
{
    public string Title { get; set; }
    public bool? IsCompleted { get; set; }

    public string getComplete()
    {
        if (IsCompleted == true)
        {
            return "Yes";
        }
        else if(IsCompleted == false)
        {
            return "No";
        }
        else
        {
            return "Status Unknown";
        }
    }
}

public class Book : Media
{
    public string Author { get; set; }

    public Book(string title, string author, bool? isCompleted)
    {
        Title = title;
        Author = author;
        IsCompleted = isCompleted;
    }
}

public class Film : Media
{
    public string Director { get; set; }
    public int ReleaseYear { get; set; }

    public Film(string title, string director, int releaseYear, bool? isCompleted)
    {
        Title = title;
        Director = director;
        ReleaseYear = releaseYear;
        IsCompleted = isCompleted;
    }
}
