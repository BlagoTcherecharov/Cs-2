using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    class Calculator
    {
        int curr = 0;

        public void ExecuteOperation(char operation, int operand)
        {
            switch (operation)
            {
                case '+': curr += operand;
                    break;
                case '-': curr -= operand;
                    break;
                case '*': curr *= operand;
                    break;
                case '/': curr /= operand;
                    break;
            }

            Console.WriteLine("Current value = {0} (following {1} {2})", curr, operation, operand);
        }
    }

    public abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    class CalculatorCommand : Command
    {
        char operation;
        int operand;
        Calculator calculator;

        public CalculatorCommand(Calculator calculator, char operation, int operand)
        {
            this.calculator = calculator;
            this.operation = operation;
            this.operand = operand;
        }

        public override void Execute()
        {
            calculator.ExecuteOperation(operation, operand);
        }

        public override void UnExecute()
        {
            calculator.ExecuteOperation(Undo(operation), operand);
        }

        private char Undo(char operation)
        {
            switch(operation)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default: throw new ArgumentException("operation");
            }
        }
    }

    class User
    {
        Calculator calculator = new Calculator();
        List<Command> commands = new List<Command>();
        int current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels", levels);

            for(int i = 0; i < levels; i++)
            {
                if(current < commands.Count - 1)
                {
                    Command command = commands[current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels", levels);

            for (int i = 0; i < levels; i++)
            {
                if(current > 0)
                {
                    Command command = commands[--current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void Compute(char operation, int operand)
        {
            Command command = new CalculatorCommand(calculator, operation, operand);

            command.Execute();
            commands.Add(command);
            current++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            int input = 0;

            do
            {
                Console.WriteLine("Choice of operations: ");
                Console.WriteLine("1. New operation");
                Console.WriteLine("2. Redo operation(s)");
                Console.WriteLine("3. Undo operation(s)");
                input = int.Parse(Console.ReadLine());

                switch(input)
                {
                    case 1: Console.Write("Enter operation: ");
                        char operation = char.Parse(Console.ReadLine());
                        Console.Write("Enter operand: ");
                        int operand = int.Parse(Console.ReadLine());
                        user.Compute(operation, operand);
                        break;
                    case 2: Console.Write("Enter number of operations to redo: ");
                        int redo = int.Parse(Console.ReadLine());
                        user.Redo(redo);
                        break;
                    case 3: Console.Write("Enter number of operations to undo: ");
                        int undo = int.Parse(Console.ReadLine());
                        user.Undo(undo);
                        break;
                }

            } while (input > 0 && input < 4);
        }
    }
}
