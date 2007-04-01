using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Function
    {
        public static String[] FUNCTIONS = {"Funkcja identycznoœciowa",
                            "Funkcja tangensowa",
                            "Funkcja sigmoidalna",
                            "Jakaœ"};
        public static int IDENTITY = 0,
                        TANH = 1,
                        CONST = 2,
                        SIGM = 3;

                            
        private int id;
        /*public Function(int ident)
        {
            this.id = ident;
        )*/
        public void setId(int ident)
        {
            this.id = ident;
        }
        public double calculate (double x)
        {
            switch (this.id)
            {
                case 0:
                    return x;
                case 1:
                    return Math.Tanh(x);
                case 2:
                    return 1;
                case 3:
                    return 1 / (1 + Math.Exp(-x));
            }
            return 0;
        }

        public double derivative(double x)
        {
            switch (this.id)
            {
                case 0:
                    return 1;
                case 1:
                    return Math.Tanh(x);
                case 2:
                    return 0;
                case 3:
                    return -(Math.Exp(-x)) / Math.Pow((1 + Math.Exp(-x)), 2);
            }
            return 0;
        }

        public static double NormSqrt(double[] x, double[] y)
        {
            double res = 0;
            int size = x.Length;
            if( y.Length < size)
                size = y.Length;
            for (int i = 0; i < size; ++i)
                res += Math.Pow(x[i] - y[i], 2);

            return Math.Sqrt(res);
        }



    }
}
