using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra
{
    public class SymContainer
    {
        public List<Sym> Variables { get; set; }
        public bool IsPositive { get; set; }
        public bool IsImaginary { get; set; }
        public double Coefficient { get; set; }
        public SymContainer(string ID, double Pow)
        {
            Variables = new List<Sym>();
            Variables.Add(new Sym(ID, Pow));
            IsPositive = true;
            IsImaginary = false;
            Coefficient = 1;
        }
        public SymContainer()
        {
            Variables = new List<Sym>();
            IsPositive = true;
            IsImaginary = false;
            Coefficient = 1;
        }
        public SymContainer Evaluate(string variable, double value)
        {
            var tmp = this.Clone();
            for(int i=0; i<Variables.Count; i++)
            {
                if (variable == Variables[i]._ID)
                {
                    var tmpC = Coefficient* Math.Pow(value, Variables[i]._Pow);
                    tmp.Coefficient = Math.Abs(tmpC);
                    tmp.Variables.RemoveAt(i);
                    tmp.IsPositive = value > 0;
                    return tmp;
                }
            }
            return tmp;
        }
        public bool EqualSym(SymContainer container)
        {
            if (container.Variables.Count != Variables.Count) return false;

            //Si las variables están vacias entonces se trata de una constante
            if (Variables.Count == 0) return true;

            foreach (var V1 in Variables)
            {
                bool found = false;
                foreach (var V2 in container.Variables)
                {
                    if (V1._ID == V2._ID)
                    {
                        if (V1._Pow == V2._Pow)
                            found = true;
                        else
                            return false;
                    }
                }
                if (!found) return false;
            }
            //Hasta este punto, todos sus simbolos fueron encontrados
            return true;
        }
        public override string ToString()
        {
            string temp = Coefficient!=1? ' ' + Coefficient.ToString(): " ";
            if (!IsPositive) temp += '-';
            foreach (var l in Variables)
            {
                temp += l._ID + '^' + l._Pow + ' ';
            }
            if (IsImaginary) temp += 'j';
            return temp;
        }
        public SymContainer Clone()
        {
            var tmp = new SymContainer();
            foreach (var V in Variables)
            {
                tmp.Variables.Add(new Sym(V._ID, V._Pow));
            }
            tmp.Coefficient = Coefficient;
            tmp.IsImaginary = IsImaginary;
            tmp.IsPositive = IsPositive;
            return tmp;
        }

        static public SymContainer operator *(double scalar, SymContainer container)
        {
            var tmp = container.Clone();
            tmp.Coefficient = container.Coefficient * scalar;
            return tmp;
        }

        static public SymContainer operator *(SymContainer s1, SymContainer s2)
        {
            var tmp = new SymContainer();
            var tmp1 = s1.Clone();
            var tmp2 = s2.Clone();
            tmp.Variables.AddRange(tmp1.Variables);
            tmp.Variables.AddRange(tmp2.Variables);

            // Signos iguales entonces es positivo
            tmp.IsPositive = s1.IsPositive == s2.IsPositive;

            if (s1.IsImaginary && s2.IsImaginary)
            {
                // si ambos imaginarios, entonces hacer real y cambiar el signo
                tmp.IsImaginary = false;
                tmp.IsPositive = !tmp.IsPositive;
            }
            else
            {
                // Si solo 1 imaginario entonces imaginario de lo contrarió es real
                tmp.IsImaginary = s1.IsImaginary || s2.IsImaginary;
            }

            //Multiplicación del coeficiente
            tmp.Coefficient = s1.Coefficient * s2.Coefficient;

            int range = tmp.Variables.Count;
            for (int i = 0; i < range - 1; i++)
            {
                for (int j = i + 1; j < range;)
                {
                    if (tmp.Variables[i]._ID == tmp.Variables[j]._ID)
                    {
                        tmp.Variables[i]._Pow = tmp.Variables[i]._Pow + tmp.Variables[j]._Pow;
                        tmp.Variables.RemoveAt(j);
                        range--;
                    }
                    else j++;
                }
            }
            return tmp;
        }

        static public Polynomial operator +(SymContainer s1, SymContainer s2)
        {
            var tmp = new Polynomial();
            tmp.Terms.Add(s1.Clone());
            tmp.Terms.Add(s2.Clone());
            return tmp;
        }

    }
}