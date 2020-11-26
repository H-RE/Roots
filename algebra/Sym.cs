using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebra
{
    public class Sym
    {
        public string _ID { get; set; }
        public double _Pow { get; set; }
        public Sym(string ID, double Pow = 1, bool Real = true)
        {
            _ID = ID;
            _Pow = Pow;
        }
        static public SymContainer operator *(Sym num1, Sym num2)
        {
            var temp = new SymContainer();
            temp.Variables.Add(new Sym(num1._ID, num1._Pow));
            temp.Variables.Add(new Sym(num2._ID, num2._Pow));
            return temp;
        }
    }
}
