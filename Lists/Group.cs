using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    class Student
    {
        protected string first_name, last_name, faculty_no;
        protected float grade;

        public Student(string first_name, string last_name, string faculty_no, float grade)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.faculty_no = faculty_no;
            this.grade = grade;
        }

        public string First_name {get {return first_name;} }
        public string Last_name { get { return last_name; } }
        public string Faculty_no { get { return faculty_no; } }
        public float Grade { get { return grade; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            List<Student> group = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter first name: ");
                string first_name = Console.ReadLine();
                Console.Write("Enter last name: ");
                string last_name = Console.ReadLine();
                Console.Write("Enter faculty number: ");
                string faculty_no = Console.ReadLine();
                Console.Write("Enter average grade: ");
                float grade = float.Parse(Console.ReadLine());

                group.Add(new Student (first_name, last_name, faculty_no, grade));
            }

            Console.WriteLine("Students with a grade above 5.50: ");

            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                if(group[i].Grade >= 5.50)
                {
                    Console.WriteLine(group[i].First_name + " " + group[i].Last_name + " " + group[i].Faculty_no + " " + group[i].Grade);
                }

                sum += group[i].Grade;
            }

            Console.WriteLine("Average of the group is " + sum / n);



        }
    }
}
