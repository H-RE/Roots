using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra
{
    public class SimplePoly
    {
        public readonly double[] Coef;
        public readonly int Grade;
        public SimplePoly(double[] Coefficient)
        {
            Coef = Coefficient;
            Grade = Coef.Length - 1;
        }
        public SimplePoly(int grade)
        {
            Coef = new double[grade + 1];
            Grade = grade;
        }
        public SimplePoly()
        {
            Coef = new double[1];
            Grade = 0;
        }
        public SimplePoly Ruffini(double root)
        {
            SimplePoly tmp = new SimplePoly(Grade - 1);

            int n = Grade;
            double Beta = 0;

            while (n > 0)
            {
                tmp.Coef[n - 1] = Coef[n] + Beta;
                Beta = tmp.Coef[n - 1] * root;
                n--;
            }

            if (Coef[0] + Beta != 0)
                return this;

            return tmp;
        }
        public double Evaluate(double value)
        {
            double Result = Coef[0];
            for (int i = 1; i <= Grade; i++)
            {
                Result += Coef[i] * Math.Pow(value, i);
            }
            return Result;
        }
        //public Complex ComplexRoot(int iteraciones = 100)
        //{ 
        //}
        public double Root(double X0, double error, int iteraciones = 100)
        {
            //X0 = Raiz propuesta
            //error es el rango de error permitido
            double root = X0;
            SimplePoly DPoly = Derivative();

            var E = Evaluate(root);
            int iter = 0;
            var Err = error <= 0 ? 1 / double.MaxValue : error;
            while (Math.Abs(E) >= Err && iter < iteraciones)
            {
                root -= E / DPoly.Evaluate(root);
                E = Evaluate(root);
                iter++;
            }
            return root;
        }
        public SimplePoly Derivative()
        {
            if (Grade == 0) return new SimplePoly();
            var DPoly = new SimplePoly(Grade - 1);
            for (int i = 1; i <= Grade; i++)
            {
                DPoly.Coef[i - 1] = Coef[i];
            }
            return DPoly;
        }
    }
}
