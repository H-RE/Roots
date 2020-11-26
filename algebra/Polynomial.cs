using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra
{
    public class Polynomial
    {
        public List<SymContainer> Terms { get; set; }
        public Polynomial()
        {
            Terms = new List<SymContainer>();
        }

        static public Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            var temp = new Polynomial();
            foreach (var termA in poly1.Terms)
            {
                foreach (var termB in poly2.Terms)
                {
                    temp.Terms.Add(termA * termB);
                }
            }
            return temp;
        }

        static public Polynomial operator +(Polynomial poly, double scalar)
        {
            var temp = poly.Clone();
            var num = new SymContainer();
            num.Coefficient = Math.Abs(scalar);
            num.IsPositive = scalar > 0;
            temp.Terms.Add(num);
            return temp;
        }
        static public Polynomial operator *(double scalar, Polynomial poly)
        {
            var temp = new Polynomial();
            foreach (var termA in poly.Terms)
            {
                    temp.Terms.Add(scalar*termA);
            }
            return temp;
        }

        public Polynomial Clone()
        {
            var temp = new Polynomial();
            foreach (var term in Terms)
            {
                temp.Terms.Add(term.Clone());
            }
            return temp;
        }
        private void Clean()
        {
            for (int i = 0; i < Terms.Count - 1; i++)
            {
                for (int j = i + 1; j < Terms.Count;)
                {
                    if (Terms[i].EqualSym(Terms[j]))
                    {
                        //SE SUMAN LOS TERMINOS RESPETIDOS EN UNO SOLO
                        int signI = Terms[i].IsPositive ? 1 : -1;
                        int signJ = Terms[j].IsPositive ? 1 : -1;
                        double value = signI * Terms[i].Coefficient + signJ * Terms[j].Coefficient;
                        double Coef = Math.Abs(value);
                        Terms[i].Coefficient = Coef;
                        Terms[i].IsPositive = value > 0;
                        //ELIMINACIÓN DEL TEMINO REPETIDO
                        Terms.RemoveAt(j);
                    }
                    else j++;
                }
            }
        }
        static public Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            var temp = new Polynomial();
            temp.Terms.AddRange(poly1.Clone().Terms);
            temp.Terms.AddRange(poly2.Clone().Terms);
            //Se simplifica el polinomio
            temp.Clean();
            return temp;
        }

        public override string ToString()
        {
            string temp = "";
            foreach (var term in Terms)
            {
                temp += term.ToString() + '\t';
            }
            return temp;
        }

        public Polynomial Evaluate(string variable, double value)
        {
            var tmp = new Polynomial();
            //Se sustituyen los valores
            foreach(var V in Terms)
            {
                tmp.Terms.Add( V.Evaluate(variable, value));
            }
            //Se simplifica el polinomio
            tmp.Clean();
            return tmp;
        }
    }
}
