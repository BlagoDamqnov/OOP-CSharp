using System;

namespace ClassBoxData
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double l = double.Parse(Console.ReadLine());
           double w = double.Parse(Console.ReadLine());
           double h = double.Parse(Console.ReadLine());

            Box box = null;
            try
            {
                 box = new Box(l, w, h);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
          

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
    }
}
