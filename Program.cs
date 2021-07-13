using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    class Program
    {
        static void Main()
        {
            LinkedLists buffer = new LinkedLists();
            buffer.AddLast(1);
            buffer.AddLast(2);
            buffer.AddLast(3);

            foreach (var n in buffer.GetItems())
            {
                Console.WriteLine(n);
            }
        }

        //private static string Reverse(string input)
        //{
        //    Stack<char> container = new Stack<char>();
        //    char[] buffer = input.ToCharArray();

        //    foreach (char ch in buffer)
        //        container.Push(ch);

        //    StringBuilder result = new StringBuilder();

        //    for (int i = 0; i < buffer.Length; i++)
        //        result.Append(container.Pop());

        //    return result.ToString();
        //}
    }
}