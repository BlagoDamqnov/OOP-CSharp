using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList s = new RandomList();

            s.Add("A");
            s.Add("B");
            s.Add("C");
            s.Add("D");
            s.Add("E");
            s.Add("F");

            s.RandomString(s);

            Console.WriteLine(string.Join(" ",s));
        }
    }
}
