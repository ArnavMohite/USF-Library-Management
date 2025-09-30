using System;
using System.Collections.Generic;
using System.Linq;

// --- Base Class ---
public class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string ID { get; set; }

    public Person(string name, string email, string id)
    {
        Name = name;
        Email = email;
        ID = id;
    }
}

// --- Inherited Class: Student ---
public class Student : Person
{
    public string Major { get; set; }
    public int GraduationYear { get; set; }

    public Student(string name, string email, string id, string major, int graduationYear)
        : base(name, email, id) // Calls the constructor of the base class (Person)
    {
        Major = major;
        GraduationYear = graduationYear;
    }
}

// --- Inherited Class: Staff ---
public class Staff : Person
{
    public string Position { get; set; }
    public string Department { get; set; }

    public Staff(string name, string email, string id, string position, string department)
        : base(name, email, id) // Calls the Person constructor
    {
        Position = position;
        Department = department;
    }
}

// --- Book Class ---
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int AvailableCopies { get; set; }

    public Book(string title, string author, string isbn, int availableCopies)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        AvailableCopies = availableCopies;
    }

    // Method to handle borrowing
    public void BorrowBook()
    {
        if (AvailableCopies > 0)
        {
            AvailableCopies--;
        }
    }
}

// --- Library Class ---
public class Library
{
    private List<Book> books = new List<Book>();
    private List<Person> patrons = new List<Person>();

    // Method to add a book to the library's collection
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Method to add a patron (Student or Staff)
    public void AddPatron(Person person)
    {
        patrons.Add(person);
    }

    // Method to display all books
    public void DisplayBooks()
    {
        Console.WriteLine("Books in Library:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Available Copies: {book.AvailableCopies}");
        }
        Console.WriteLine(); // For spacing
    }

    // Method to display all patrons
    public void DisplayPatrons()
    {
        Console.WriteLine("Patrons in Library:");
        foreach (var patron in patrons)
        {
            Console.WriteLine($"Name: {patron.Name}, ID: {patron.ID}");
        }
        Console.WriteLine(); // For spacing
    }
}

// --- Main Program Execution ---
class Program
{
    static void Main(string[] args)
    {
        // 1. Create the Library object
        Library usfLibrary = new Library();

        // 2. Create and add books to the library
        Book book1 = new Book("The Art of Data Strategy", "Liam Reynolds", "ISBN111", 4);
        Book book2 = new Book("Business Insights with AI", "Olivia Carter", "ISBN222", 3);
        Book book3 = new Book("Analytics in Action", "Nathan Brooks", "ISBN333", 6);
        usfLibrary.AddBook(book1);
        usfLibrary.AddBook(book2);
        usfLibrary.AddBook(book3);

        // 3. Create and add patrons (students and staff) to the library
        Student student1 = new Student("Akhil", "akhil@usf.edu", "S001", "Business Analytics", 2026);
        Student student2 = new Student("Sandeep", "sandeep@usf.edu", "S002", "Information Systems", 2025);
        Staff staff1 = new Staff("Grandon Gill", "grandon@usf.edu", "ST001", "Librarian", "Library Services");
        usfLibrary.AddPatron(student1);
        usfLibrary.AddPatron(student2);
        usfLibrary.AddPatron(staff1);

        // 4. Display the initial state of the library
        usfLibrary.DisplayBooks();
        usfLibrary.DisplayPatrons();
        
        // 5. Implement the borrowing scenario
        Console.WriteLine("Borrowing Books...");
        // Sandeep borrows "Business Insights with AI"
        book2.BorrowBook();
        Console.WriteLine("Sandeep borrowed 'Business Insights with AI'");

        // Akhil borrows "Analytics in Action"
        book3.BorrowBook();
        Console.WriteLine("Akhil borrowed 'Analytics in Action'");
        
        Console.WriteLine("\nBooks after borrowing:");
        
        // 6. Display the final state of the library
        usfLibrary.DisplayBooks();
    }
}