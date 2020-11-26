using System;
using System.Collections.Generic;
using algebra;
namespace roots
{
    class Program
    {
        static void Main(string[] args)
        {
            SymContainer x = new SymContainer("X", 1);
            SymContainer y = new SymContainer("Y", 1);
            SymContainer A = new SymContainer("A", 1);
            SymContainer B = new SymContainer("B", 1);
            var real = x;
            var imag = y;
            imag.IsImaginary = true;

            var S = real + imag;
            var P1 = S * S + 4 * S+29;
            Console.WriteLine(P1.ToString());

            var lis = new List<int>();
            Console.WriteLine(lis.Count);

            Console.ReadKey();
        }
    }
}
