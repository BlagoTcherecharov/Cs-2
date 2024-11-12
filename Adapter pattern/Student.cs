using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Group
    {
        private string[] data = { "Ivan", "Ivanov", "21905111", "i.ivanov@gmail.com", "18.5" };

        public string GetItem(string item)
        {
            switch(item.ToLower())
            {
                case "name": return data[0];
                case "family": return data[1];
                case "id": return data[2];
                case "email": return data[3];
                case "score": return data[4];
                default: return "";
            }
        }
    }

    abstract class Student
    {
        protected string name;
        protected string family;
        protected string id;
        protected string email;
        protected string score;
        protected string grade;

        public abstract void Input();
        public void Calculate()
        {
            double s = Convert.ToDouble(score);

            if (13.5 <= s && s <= 17.5)
                grade = "3";
            else if (18 <= s && s <= 22)
                grade = "4";
            else if (22.5 <= s && s <= 25)
                grade = "5";
            else if (25.5 <= s)
                grade = "6";
            else
                grade = "2";

            Result(grade);
        }

        public void Result(string g)
        {
            Console.WriteLine("Result -------");
            Console.WriteLine("Name: " + name + " " + family);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Result: " + g);
            Console.WriteLine("Exam points: " + score);
        }

        public void Protocol()
        {
            Console.WriteLine("\nProtocol -------");
            Console.WriteLine("Name: " + name + " " + family);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Grade: " + grade);
        }
    }

    class MyStudents: Student
    {
        private Group group;


        public override void Input()
        {
            group = new Group();
            name = group.GetItem("name");
            family = group.GetItem("family");
            id = group.GetItem("id");
            email = group.GetItem("email");
            score = group.GetItem("score");

            Calculate();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new MyStudents();
            student.Input();
            student.Protocol();
        }
    }
}
