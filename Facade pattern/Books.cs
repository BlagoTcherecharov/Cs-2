using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Lecturer
    {
        protected string firstName, secondName, lastName;
        protected string affilation, department;

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public void addLecturer()
        {
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Enter second name: ");
            secondName = Console.ReadLine();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();

            Console.Write("Enter affilation: ");
            affilation = Console.ReadLine();
            Console.Write("Enter department: ");
            department = Console.ReadLine();
        }

        public void updateLecturer()
        {
            Console.WriteLine("Changes available: ");
            Console.WriteLine("1. Affilation");
            Console.WriteLine("2. Department");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new affilation: ");
                    affilation = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new department: ");
                    department = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public void removeLecturer()
        {
            firstName = secondName = lastName = affilation = department = null;
        }

        public void printLecturer()
        {
            Console.WriteLine("Lecturer: " + firstName + " " + secondName + " " + lastName);
            Console.WriteLine("Affilation: " + affilation + "\nDepartment: " + department);
        }
    }

    class Paper : Lecturer
    {
        int numAuthors;
        string title, ISSN, details, type;
        List<Paper> authors = new List<Paper>();
        
        public void addPaper()
        {
            Console.Write("Enter number of authors: ");
            numAuthors = int.Parse(Console.ReadLine());

            for (int i = 0; i < numAuthors; i++)
            {
                authors[i].addLecturer();
            }

            Console.WriteLine("Enter title of paper: ");
            title = Console.ReadLine();
            Console.WriteLine("Enter ISSN: ");
            ISSN = Console.ReadLine();
            Console.WriteLine("Enter details of paper: ");
            details = Console.ReadLine();
            Console.WriteLine("Enter type of paper: ");
            type = Console.ReadLine();
        }

        public void updatePaper()
        {
            Console.WriteLine("Changes available: ");
            Console.WriteLine("1. ISSN");
            Console.WriteLine("2. Details");
            Console.WriteLine("3. Type");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new ISBN: ");
                    ISSN = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new details: ");
                    details = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter new type: ");
                    type = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public void printPaper()
        {
            Console.WriteLine("Authors: \n");
            for (int i = 0; i < numAuthors; i++)
            {
                Console.WriteLine(firstName + " " + lastName);
            }
            Console.WriteLine("Title of paper: " + title);
            Console.WriteLine("ISSN: " + ISSN);
            Console.WriteLine("Details: " + details);
            Console.WriteLine("Type: " + type);
        }

        public bool Verify(Lecturer lecturer)
        {
            for (int i = 0; i < numAuthors; i++)
            {
                if (lecturer.FirstName == authors[i].firstName && lecturer.LastName == authors[i].lastName)
                    return true;
            }
            return false;
        }
    }

    class Author
    {
        protected string firstName, lastName;

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public void author()
        {
            Console.Write("Enter first name of author: ");
            firstName = Console.ReadLine();
            Console.Write("Enter last name of author: ");
            lastName = Console.ReadLine();
        }
    }

    class Book : Author
    {
        string title, ISBN, details;

        public void addBook()
        {
            author();
            Console.Write("Enter title of book: ");
            title = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            ISBN = Console.ReadLine();
            Console.Write("Enter details about the book: ");
            details = Console.ReadLine();
        }

        public void updateBook()
        {
            Console.WriteLine("Changes available: ");
            Console.WriteLine("1. ISBN");
            Console.WriteLine("2. Details");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Console.Write("Enter new ISBN: ");
                    ISBN = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new details: ");
                    details = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public void printBook()
        {
            Console.WriteLine("Author: " + firstName + " " + lastName);
            Console.WriteLine("Title of book: " + title + "\nISBN: " + ISBN);
            Console.WriteLine("Details: " + details);
        }
    }

    class Facade
    {
        Lecturer lecturer;
        Paper paper;
        Author author;
        Book book;

        public Facade()
        {
            lecturer = new Lecturer();
            paper = new Paper();
            author = new Author();
            book = new Book();
        }

        public void operations()
        {
            bool condition = true;
            int changes = 0, actions = 0;
            while(condition)
            {
                Console.WriteLine("Changes are possible for: ");
                Console.WriteLine("1. Lecturer");
                Console.WriteLine("2. Paper");
                Console.WriteLine("3. Book");
                Console.WriteLine("4. Exit");

                changes = int.Parse(Console.ReadLine());

                switch(changes)
                {
                    case 1:
                        Console.WriteLine("Changes possible for lecturer: ");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Update");
                        Console.WriteLine("3. Remove");
                        Console.WriteLine("4. View");
                        actions = int.Parse(Console.ReadLine());
                        if (actions == 1) lecturer.addLecturer();
                        else if (actions == 2) lecturer.updateLecturer();
                        else if (actions == 3) lecturer.removeLecturer();
                        else if (actions == 4) lecturer.printLecturer();
                        break;
                    case 2:
                        Console.WriteLine("Changes possible for paper: ");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Update");
                        Console.WriteLine("3. View");
                        actions = int.Parse(Console.ReadLine());
                        if (actions == 1) paper.addPaper();
                        else if (actions == 2) paper.updatePaper();
                        else if (actions == 3) paper.printPaper();
                        break;
                    case 3:
                        Console.WriteLine("Changes possible for book: ");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Update");
                        Console.WriteLine("3. View");
                        actions = int.Parse(Console.ReadLine());
                        if (actions == 1) book.addBook();
                        else if (actions == 2) book.updateBook();
                        else if (actions == 3) book.printBook();
                        break;
                    case 4:
                        condition = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void check()
        {
            if (lecturer.FirstName == book.FirstName && lecturer.LastName == book.LastName)
            {
                Console.WriteLine("Lecturer " + lecturer.FirstName + " " + lecturer.LastName + " is the author of a book");
            }

            if(paper.Verify(lecturer))
            {
                Console.WriteLine("Lecturer " + lecturer.FirstName + " " + lecturer.LastName + " is one of the authors of a paper");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.operations();
            facade.check();

            Console.ReadLine();
        }
    }
}
