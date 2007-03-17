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
            }
            return 0;
        }

    }
}
