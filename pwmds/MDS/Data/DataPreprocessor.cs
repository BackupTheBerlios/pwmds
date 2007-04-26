using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class DataPreprocessor
    {
        public static int STANDARIZE = 1,
                        SCALING = 2,
                        CUTTING = 3;
        public bool ReplaceMissingValuesByMean (double []tab)
        {
            if (tab == null) return false;
            int n = tab.Length, k = 0;
            double mean, sum=0;
            for (int i = 0; i < n; i++)
            {
                if (double.IsNaN(tab[i]))
                {
                    k++;
                    continue;
                } 
                sum += tab[i];
            }
            if (2 * k > n) return false;  //do przemyslenia kiedy usuwac zmienna
            mean = sum / n;
            for (int i = 0; i < n; i++)
            {
                if (double.IsNaN(tab[i])) tab[i] = mean;
            }
            return true;

        }
        public void StandarizeData(List<double[]> l, int opt, int a, int b) //o - rodzaj standaryzacji a,b-konce przedzialu
        {
            if ( opt!=1 && opt!=2) throw new Exception("Bad standarizeData parameter"); 
            
                double[] t = new double[l.Count]; //tymczasowa tablica na skalowane zmienne
                IEnumerator<double[]> f = l.GetEnumerator();
                                
                for (int i = 0; i < l[0].Length; i++) //wybieramy i-ty element z kazdej tablicy na liscie
                {
                    f.Reset();
                    //if (double.IsNaN(l[0][i])) break;
                    int j = 0;
                    while (f.MoveNext() && j < t.Length) //petla po liscie tablic
                    {
                        t[j] = f.Current[i]; //do tymczasowej tablicy wpisujemy i-ty element kazdej tablicy
                        j++;
                    }
                    if (opt == STANDARIZE)
                    {
                        this.standarizeVariable(t);
                    }
                    else if (opt == SCALING)
                    {
                        this.scaleVariable(a, b, t);
                    }
                    
                    f.Reset();
                    j = 0;
                    while (f.MoveNext() && j < t.Length)
                    {
                        f.Current[i] = t[j];  //wpisanie nowych wartosci po standaryzacji z powrotem do i-tego elementu kazdej tablicy na liscie
                        j++;
                    }
                }
            
            
        }
        private void standarizeVariable(double[] tab)
        {
            if (tab == null) return;
            int n = tab.Length;
            double sum = 0, mean, variance=0,stdev;

            this.ReplaceMissingValuesByMean(tab);
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

            this.ReplaceMissingValuesByMean(tab);
            max = min = tab[0];
            for (int i = 1; i < tab.Length; i++)   //znajdujemy wartosc min i max
            {
                if (tab[i] > max) max = tab[i];
                if (tab[i] < min) min = tab[i];
            }
            //skalowanie przedzialu
            y = (max - min) / (b - a);
            x = max - b * y;
            for (int i = 0; i < tab.Length; i++)  
            {
                tab[i] = (tab[i] - x) / y;
            }
        }

        public List<double[]> SelectVectors(List<double[]> data, int startVector, int endVector)
        {
            List<double[]> newData = new List<double[]>();
            double[] vector;
            for(int i = startVector-1; i <= endVector; ++i )   
            {
                vector = new double[data[i].Length];
                data[i].CopyTo(vector, 0 );
                newData.Add( vector );
            }

            return newData;
        }
    }
}
