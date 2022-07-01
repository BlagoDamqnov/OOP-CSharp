using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();

            Console.WriteLine(myStack.IsEmpty());

            string[] array = new string[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = $"element{i}";
            }

            myStack.AddRange(array);

            Console.WriteLine(myStack.Count);
        }
    }
}
