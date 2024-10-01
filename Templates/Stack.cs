using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTemplate
{
    class Stack<T>
    {
        private T[] stack;
        private int size;
        private int index = 0;

        public Stack(int size)
        {
            stack = new T[size];
            this.size = size;
        }

        public bool Empty()
        {
            return index == 0;
        }

        public bool Full()
        {
            return index == size;
        }

        public void Push(T value)
        {
            if (!Full())
            {
                stack[index] = value;
                index++;
            }
            else
                Console.WriteLine("Stack is full!");
        }

        public void Pop()
        {
            if (!Empty())
            {
                index--;
                Console.WriteLine(stack[index]);
            }
            else
                Console.WriteLine("Stack is empty!");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of stack");
            int size = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(size);

            int choice = 0;

            do
            {
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.Write("Enter value: ");
                        int value = int.Parse(Console.ReadLine());
                        stack.Push(value);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    default:
                        break;
                }
            } while (!stack.Empty());
        }
    }
}
