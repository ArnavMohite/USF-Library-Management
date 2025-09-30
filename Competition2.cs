namespace ISM6225_Competition2
{
    public class Person
    {
        // Properties common to all persons
        public string Name;
        public string ID;
        public string Email;

        // Constructor
        public Person(string name, string id, string email)
        {
            Name = name;
            ID = id;
            Email = email;
        }
    }


    public class Student : Person
    {
        // Additional properties specific to students
        public string Major;
        public int GraduationYear;

        // Constructor
        public Student(string name, string id, string email, string major, int year)
            : base(name, id, email)
        {
            Major = major;
            GraduationYear = year;
        }
    }

    public class Staff : Person
    {
        // Additional properties specific to staff
        public string Position;
        public string Department;

        // Constructor
        public Staff(string name, string id, string email, string position, string department)
            : base(name, id, email)
        {
            Position = position;
            Department = department;
        }
    }
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
    public class Library
    {
        public List<Book> Books { get; } = new List<Book>();
        public List<Person> Patrons { get; } = new List<Person>();

        public void AddBook(Book book) => Books.Add(book);

        public void AddPatron(Person patron) => Patrons.Add(patron);

        public void DisplayBooks()
        {
            Console.WriteLine("Books in Library:");
            foreach (var book in Books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine();
        }

        public void DisplayPatrons()
        {
            Console.WriteLine("Patrons in Library:");
            foreach (var p in Patrons)
            {
                Console.WriteLine($"Name: {p.Name}, ID: {p.ID}");
            }
            Console.WriteLine();
        }

        // Borrow by patron ID and book title (case-insensitive). Returns true if borrow successful.
        public bool BorrowBookByTitle(string patronId, string title)
        {
            var patron = Patrons.FirstOrDefault(p => p.ID.Equals(patronId, StringComparison.OrdinalIgnoreCase));
            if (patron == null)
            {
                Console.WriteLine($"Patron with ID {patronId} not found.");
                return false;
            }

            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book == null)
            {
                Console.WriteLine($"Book '{title}' not found in library.");
                return false;
            }

            if (book.BorrowBook())
            {
                Console.WriteLine($"{patron.Name} borrowed '{book.Title}'");
                return true;
            }
            else
            {
                Console.WriteLine($"No available copies of '{book.Title}' to borrow.");
                return false;
            }
        }
    }
}
