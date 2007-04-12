using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MDS
{
    class DataPreprocessor
    {

        private Hashtable standarizeData(Hashtable x, int o, int a, int b) //o - rodzaj standaryzacji a,b-konce przedzialu
        {
       
            IDictionaryEnumerator e = x.GetEnumerator();
            //double[] t = new double[8000];
            List<double[]> l;
            while (e.MoveNext())  //petla po hastable
            {
                l = (List<double[]>)e.Value;
                double[] t = new double[l.Count]; //tymczasowa tablica na zmienne
                IEnumerator<double[]> f = l.GetEnumerator();
                for (int i = 0; i < f.Current.Length; i++) 
                {
                    f.Reset();
                    if (double.IsPositiveInfinity(f.Current[i])) break;
                    int j = 0;
                    while (f.MoveNext() && j < t.Length) //petla po liscie tablic
                    {
                        t[j] = f.Current[i]; //do tymczasowej tablicy wpisujemy i-ty element kazdej tablicy
                        j++;
                    }
                    if (o == 1)
                    {
                        this.standarizeVariable(t);
                    }
                    else if (o == 2)
                    {
                        this.scaleVariable(a, b, t);
                    }
                    else throw new Exception("Bad standarizeData parameter");
                    f.Reset();
                    j = 0;
                    while (f.MoveNext() && j < t.Length)
                    {
                        f.Current[i] = t[j];  //wpisanie nowych wartosci po standaryzacji z powrotem do i-tego elementu kazdej tablicy na liscie
                        j++;
                    }
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
