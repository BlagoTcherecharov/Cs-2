using System;
using System.Collections.Generic;
using System.Linq;

namespace Facade
{
    class Lecturer
    {
        protected string firstName, lastName, affilation, department;
        private static List<Lecturer> lecturers = new List<Lecturer>();

        public string FirstName => firstName;
        public string LastName => lastName;

        public void CreateLecturer()
        {
            Lecturer newLecturer = new Lecturer();
            newLecturer.AddLecturer();
            lecturers.Add(newLecturer);
        }

        public void AddLecturer()
        {
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            Console.Write("Enter affilation: ");
            affilation = Console.ReadLine();
            Console.Write("Enter department: ");
            department = Console.ReadLine();
        }

        public void PrintLecturers()
        {
            foreach (var l in lecturers)
            {
                Console.WriteLine($"Lecturer: {l.FirstName} {l.LastName}");
                Console.WriteLine($"Affiliation: {l.affilation}, Department: {l.department}");
            }
        }

        public static List<Lecturer> GetLecturers() => lecturers;
    }

    class Paper
    {
        private string title, ISSN, details, type;
        private List<Lecturer> authors = new List<Lecturer>();
        private static List<Paper> papers = new List<Paper>();

        public string Title => title;
        public List<Lecturer> Authors => authors;

        public void AddPaper(List<Lecturer> lecturers)
        {
            Console.Write("Enter number of authors: ");
            int numAuthors = int.Parse(Console.ReadLine());

            for (int i = 0; i < numAuthors; i++)
            {
                Console.Write("Enter first name of author: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter last name of author: ");
                string lastName = Console.ReadLine();

                var lecturer = lecturers.FirstOrDefault(l => l.FirstName == firstName && l.LastName == lastName);
                if (lecturer != null)
                {
                    authors.Add(lecturer);
                }
                else
                {
                    Console.WriteLine("Lecturer not found! Add lecturer first.");
                }
            }

            Console.Write("Enter title of paper: ");
            title = Console.ReadLine();
            Console.Write("Enter ISSN: ");
            ISSN = Console.ReadLine();
            Console.Write("Enter details of paper: ");
            details = Console.ReadLine();
            Console.Write("Enter type of paper: ");
            type = Console.ReadLine();

            papers.Add(this);
        }

        public static List<Paper> GetPapers() => papers;

        public void PrintPaper()
        {
            Console.WriteLine($"Title: {title}, ISSN: {ISSN}, Type: {type}");
            Console.WriteLine("Authors:");
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }
    }

    class Book
    {
        private string title, ISBN, details;
        private Lecturer author;
        private static List<Book> books = new List<Book>();

        public string Title => title;
        public Lecturer Author => author;

        public void AddBook(List<Lecturer> lecturers)
        {
            Console.Write("Enter first name of author: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name of author: ");
            string lastName = Console.ReadLine();

            author = lecturers.FirstOrDefault(l => l.FirstName == firstName && l.LastName == lastName);
            if (author == null)
            {
                Console.WriteLine("Lecturer not found! Add lecturer first.");
                return;
            }

            Console.Write("Enter title of book: ");
            title = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            ISBN = Console.ReadLine();
            Console.Write("Enter details about the book: ");
            details = Console.ReadLine();

            books.Add(this);
        }

        public static List<Book> GetBooks() => books;

        public void PrintBook()
        {
            Console.WriteLine($"Title: {title}, ISBN: {ISBN}, Details: {details}");
            Console.WriteLine($"Author: {author.FirstName} {author.LastName}");
        }
    }

    class Facade
    {
        private Lecturer lecturer = new Lecturer();
        private Paper paper = new Paper();
        private Book book = new Book();

        public void Operations()
        {
            bool condition = true;

            while (condition)
            {
                Console.WriteLine("Changes are possible for: ");
                Console.WriteLine("1. Lecturer");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Book");
                Console.WriteLine("4. Lecturers and their books");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ManageLecturers();
                        break;
                    case 2:
                        ManagePapers();
                        break;
                    case 3:
                        ManageBooks();
                        break;
                    case 4:
                        ViewPublications();
                        break;
                    case 5:
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ManageLecturers()
        {
            Console.WriteLine("1. Add Lecturer");
            Console.WriteLine("2. View Lecturers");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                lecturer.CreateLecturer();
            }
            else if (choice == 2)
            {
                lecturer.PrintLecturers();
            }
        }

        private void ManagePapers()
        {
            Console.WriteLine("1. Add Paper");
            Console.WriteLine("2. View Papers");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                paper.AddPaper(Lecturer.GetLecturers());
            }
            else if (choice == 2)
            {
                foreach (var p in Paper.GetPapers())
                {
                    p.PrintPaper();
                }
            }
        }

        private void ManageBooks()
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                book.AddBook(Lecturer.GetLecturers());
            }
            else if (choice == 2)
            {
                foreach (var b in Book.GetBooks())
                {
                    b.PrintBook();
                }
            }
        }

        private void ViewPublications()
        {
            var lecturers = Lecturer.GetLecturers();
            var books = Book.GetBooks();
            var papers = Paper.GetPapers();

            foreach (var lec in lecturers)
            {
                Console.WriteLine($"{lec.FirstName} {lec.LastName}'s Publications:");

                foreach (var b in books.Where(b => b.Author == lec))
                {
                    Console.WriteLine($"Book: {b.Title}");
                }

                foreach (var p in papers.Where(p => p.Authors.Contains(lec)))
                {
                    Console.WriteLine($"Paper: {p.Title}");
                }

                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.Operations();
        }
    }
}
