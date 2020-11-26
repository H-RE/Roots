namespace roots
{
    class Complex
    {
        public double Real { get; set; }
        public double Imag { get; set; }
        static public Complex operator *(Complex num1,Complex num2)
        {
            var Temp = new Complex
            {
                Real = num1.Real * num2.Real - num1.Imag * num2.Imag,
                Imag = num1.Real * num2.Imag + num1.Imag * num2.Real
            };
            return Temp;
        }
        static public Complex operator *(double scalar, Complex num)
        {
            var Temp = new Complex
            {
                Real = scalar * num.Real,
                Imag = scalar * num.Imag
            };
            return Temp;
        }
        static public Complex operator ^(Complex num,int n)
        {
            var Temp = new Complex();
            Temp.Real = num.Real;
            Temp.Imag = num.Imag;
            for(int i=1;i<n;i++)
            {
                Temp *= num;
            }
            return Temp;
        }
        static public Complex operator +(Complex num1, Complex num2)
        {
            var Temp = new Complex
            {
                Real = num1.Real + num2.Real,
                Imag = num1.Imag + num2.Imag
            };
            return Temp;
        }
        }
}
