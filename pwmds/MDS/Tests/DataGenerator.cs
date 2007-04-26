using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace MDS.Tests
{
    class DataGenerator
    {
        public void Generate( int size)
        {
            double[] tab;
            
            //StreamWriter wr = (StreamWriter)File.OpenText("data.txt");
             //= new StreamWriter();
            for( int i = 0; i < size; ++i)
            {
                tab = new double[5];
                SetVal(tab);
                //String str = Data.ProcessData.GetStringList(tab);
                //wr.WriteLine( str );
                for(int j=0;j<4;j++)
                    System.Console.Write(tab[j]+"* ");
                System.Console.WriteLine(tab[4]);
               // System.Console.WriteLine(str);
            }

           // wr.Close();
        }
        public void SetVal( double[] t)
        {
            Random r = new Random();
            double x = r.NextDouble(),
                y = r.NextDouble();
            t[0] = x;
            t[1] = y;
            t[2] = (x + y)/2;
            t[3] = x / 2;
            t[4] = x * y;

        }
    }
}
