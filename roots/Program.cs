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
            //Arreglar la suma de ceros, podría ocupar memoria innecesariamente
            //CHECAR QUE FUNCIONE CON S^n y que simplificada quede y^2
            //Si funciona, hacer el calculo de roots

            
            var S = real + imag;
            var P1 = (S * S + 4 * S + 29) * (S + 1);
            
            imag.IsPositive = false;
            S = real + imag;
            var P2 = (S * S + 4 * S + 29) * (S + 1);
            

            var ev1 = P1.Evaluate("X", 1);
            var ev2 = P2.Evaluate("X", 1);

            Console.WriteLine(P1.ToString());
            Console.WriteLine(P2.ToString());
            Console.WriteLine(ev1.ToString());
            Console.WriteLine(ev2.ToString());

            ev1 = P1.Evaluate("Y", 0);
            ev1 = ev1.Evaluate("X", -0.7435);
            Console.WriteLine(ev1.ToString());
            
            double[] asd = { 29,33,5,1};
            
            var a = new SimplePoly(asd);
            var root = a.Root(-90, 0);
            Console.WriteLine("raiz: "+root.ToString());
            var Simplificado = a.Ruffini(root);
            foreach(var v in Simplificado.Coef)
            {
                Console.WriteLine(v.ToString());
            }
            //Test de raiz compleja
            Console.WriteLine(Simplificado.Root(1, 0.01));

            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
