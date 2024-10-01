using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateArray
{
    class Array<T>
    {
        private T[] arr;

        public Array(int size)
        {
            arr = new T[size];
        }

        public void Read()
        {
            foreach (T i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void Set(T value, int index)
        {
            arr[index] = value;
        }

        public void Get(int index)
        {
            Console.WriteLine(arr[index]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array");
            int size = int.Parse(Console.ReadLine());

            Array<int> array = new Array<int>(size);

            int pick = 0;
            int index;
            do
            {
                Console.WriteLine("1. Change an element");
                Console.WriteLine("2. Get the value of an element");
                Console.WriteLine("3. Get whole array");
                pick = int.Parse(Console.ReadLine());

                switch(pick)
                {
                    case 1:
                        Console.Write("Enter index:");
                        index = int.Parse(Console.ReadLine());
                        Console.Write("Enter value:");
                        int value = int.Parse(Console.ReadLine());
                        array.Set(value, index);
                        break;
                    case 2:
                        Console.Write("Enter index:");
                        index = int.Parse(Console.ReadLine());
                        array.Get(index);
                        break;
                    case 3:
                        array.Read();
                        break;
                    default:
                        break;
                }
            } while (pick != 3);
        }
    }
}
