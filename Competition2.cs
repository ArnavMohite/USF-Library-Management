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
}