using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MDS
{
    class DataPreprocessor
    {

        private Hashtable standarizeData(Hashtable x)
        {
       
            IDictionaryEnumerator e = x.GetEnumerator();
            double[] t = new double[8000];
            List<double[]> l;
            while (e.MoveNext())
            {
                l = (List<double[]>)e.Value;
                IEnumerator<double[]> f = l.GetEnumerator();
                for (int i = 0; i < f.Current.Length; i++)
                {
                    f.Reset();
                    while (f.MoveNext())
                    {
                        t[i] = f.Current[i];
                    }
                    this.standarizeVariable(t);
                }
            }
            return x;
        }
        private void standarizeVariable(double[] tab)
        {
            if (tab == null) return;
            int n = tab.Length;
            double sum = 0, mean, variance=0,stdev;

            for (int i = 0; i < n; i++)
            {
                sum += tab[i];
            }
            mean = sum / n;

            for (int i = 0; i < n; i++)  
            {
                variance += (tab[i] - mean) * (tab[i] - mean);
            }
            variance /= n;
            stdev = Math.Sqrt(variance);
            for (int i = 0; i < n; i++)    //standaryzacja
            {
                tab[i] = (tab[i] - mean) / stdev;
            }
        }
        private void scaleVariable(int a, int b, double[] tab)
        {
            if (tab == null) return;
            double max, min,x,y;
            max = min = tab[0];
            for (int i = 1; i < tab.Length; i++)   //znajdujemy wartosc min i max
            {
                if (tab[i] > max) max = tab[i];
                if (tab[i] < min) min = tab[i];
            }
            y = (max - min) / (b - a);
            x = max - b * y;
            for (int i = 0; i < tab.Length; i++)  //skalowanie przedialu
            {
                tab[i] = (tab[i] - x) / y;
            }
        }
    }
}
