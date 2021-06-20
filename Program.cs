using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a string");
            string input = Console.ReadLine();
            Console.WriteLine("Reversed string is {0}", Reverse(input));
        }

        private static string Reverse(string input)
        {
            Stack<char> container = new Stack<char>();
            char[] buffer = input.ToCharArray();

            foreach (char ch in buffer)
                container.Push(ch);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < buffer.Length; i++)
                result.Append(container.Pop());

            return result.ToString();
        }
    }
}