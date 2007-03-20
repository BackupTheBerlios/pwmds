using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Function
    {
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

    }
}
