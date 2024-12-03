using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class Strategy
    {
        public abstract void Sort(int [] arr);
    }

    public class BubbleSort : Strategy
    {
        public override void Sort(int [] arr)
        {
            int n = arr.Length;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                bool swap = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        count++;
                        swap = true;
                    }
                }

                if (!swap)
                    break;
            }

            foreach (var a in arr)
            {
                Console.Write(a + " ");
            }

            Console.Write("\nSwaps: " + count);
            Console.WriteLine("\n");
        }
    }

    public class SelectionSort : Strategy
    {
        private int index, min;

        public override void Sort(int[] arr)
        {
            int n = arr.Length;
            int count = 0;
            
            for (int i = 0; i < n; i++)
            {
                min = arr[i];
                index = i;
                for (int j = i; j < n; j++)
                {
                    if(arr[j] < min)
                    {
                        min = arr[j];
                        index = j;
                    }
                }

                if (index != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[index];
                    arr[index] = temp;

                    count++;
                }
            }

            foreach (var a in arr)
            {
                Console.Write(a + " ");
            }

            Console.Write("\nSwaps: " + count);
            Console.WriteLine("\n");
        }
    }

    public class InsertionSort : Strategy
    {
        public override void Sort(int[] arr)
        {
            int n = arr.Length;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                int j = i - 1;
                int k = arr[i];

                while (j >= 0 && arr[j] > k)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;

                    count++;
                }

                arr[j + 1] = k;
            }

            foreach (var a in arr)
            {
                Console.Write(a + " ");
            }

            Console.Write("\nSwaps: " + count);
        }
    }

    public class Context
    {
        Strategy strategy;
        int[] arr;

        public Context(Strategy strategy, int [] arr)
        {
            this.strategy = strategy;
            this.arr = arr;
        }

        public void ContextInterface()
        {
            strategy.Sort(arr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context context;

            int[] arr = { 5, 6, 21, 43, 9, 4, 1 };
            //int[] arr1 = { 5, 6, 21, 43, 9, 4, 1 };
            //int[] arr2 = { 5, 6, 21, 43, 9, 4, 1 };

            int choice;

            Console.WriteLine("Sorting algorithms: ");
            Console.WriteLine("1. Bubble sort");
            Console.WriteLine("2. Selection sort");
            Console.WriteLine("3. Insertion sort");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    context = new Context(new BubbleSort(), arr);
                    context.ContextInterface();
                    break;
                case 2:
                    context = new Context(new SelectionSort(), arr);
                    context.ContextInterface();
                    break;
                case 3:
                    context = new Context(new InsertionSort(), arr);
                    context.ContextInterface();
                    break;
                default:
                    break;
            }
        }
    }
}
