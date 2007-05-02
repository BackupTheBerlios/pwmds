using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class DataPreprocessor
    {
        public static int STANDARIZE = 1,
                        SCALING = 2;
        public static int MODIFY = 0,
                        SELECT_VECTORS = 1,
                        SELECT_COLUMNS = 2;
        private Tests.TestPreprocessor test;

        public DataPreprocessor()
        {
            this.test = new MDS.Tests.TestPreprocessor();
        }

        public List<double[]> DeleteMissingValues(List<double[]> l, double tolerance)
        {
            
            List<double[]> x = new List<double[]>();
            List<int> todelete = new List<int>(); //lista nr kolumn do usuniecia
            double[] t = new double[l.Count]; //tymczasowa tablica na skalowane zmienne
            IEnumerator<double[]> f = l.GetEnumerator();

            for (int i = 0; i < l[0].Length; i++) //wybieramy i-ty element z kazdej tablicy na liscie
            {
                f.Reset();
                int j = 0;
                while (f.MoveNext() && j < t.Length) //petla po liscie tablic
                {
                    t[j] = f.Current[i]; //do tymczasowej tablicy wpisujemy i-ty element kazdej tablicy
                    j++;
                }

                if (this.ReplaceMissingValuesByMean(t, tolerance) == true)
                {
                    f.Reset();
                    j = 0;
                    while (f.MoveNext() && j < t.Length)
                    {
                        f.Current[i] = t[j];  //wpisanie nowych wartosci z powrotem do i-tego elementu kazdej tablicy na liscie
                        j++;
                    }
                }
                
                else todelete.Add(i);
            }
                List<double> tmplist = new List<double>(); 
                double[] ar = new double[l[0].Length - todelete.Count];
                f.Reset();
                while (f.MoveNext())
                {
                    for (int j = 0; j < f.Current.Length; j++)
                    {
                        if (!todelete.Contains(j)) tmplist.Add(f.Current[j]);
                    }
                    ar=tmplist.ToArray();
                    x.Add(ar);
                    tmplist.Clear();
                }
                return x;
        }
        public bool FindMissingValues(List<double[]> l)
        {
            IEnumerator<double[]> f = l.GetEnumerator();
            while (f.MoveNext())
            {
                for (int i = 0; i < f.Current.Length; i++)
                {
                    if (double.IsNaN(f.Current[i])) return true;
                }
            }
            return false;
        }
        public bool ReplaceMissingValuesByMean(double[] tab, double tolerance)
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
            /*jesli brakujacych przypadkow jest wiecej
              niz wynosi tolerancja to false*/
            if (100*k/tolerance > n) return false;  
            mean = sum / (n-k);
            for (int i = 0; i < n; i++)
            {
                if (double.IsNaN(tab[i])) tab[i] = mean;
            }
            return true;

        }

        public List<double[]> StandarizeData(List<double[]> l, int opt, int a, int b) //o - rodzaj standaryzacji a,b-konce przedzialu
        {
            
            if ( opt!=1 && opt!=2) throw new Exception("Bad StandarizeData parameter");
            if (a == b) throw new Exception("Bad interval values");
            if (this.FindMissingValues(l) == true)
            {
                throw new Exception("Missing values present");
            }
            
            List<double[]> x = new List<double[]>();
            IEnumerator<double[]> g = l.GetEnumerator();
            while (g.MoveNext())
            {
                double[] tmp = new double[g.Current.Length];
                tmp=(double[])g.Current.Clone();
                x.Add(tmp);
            }
            
            
            double[] t = new double[x.Count]; //tymczasowa tablica na skalowane zmienne
            IEnumerator<double[]> f = x.GetEnumerator();
            
                for (int i = 0; i < x[0].Length; i++) //wybieramy i-ty element z kazdej tablicy na liscie
                {
                    f.Reset();  
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
            
            if (variance == 0)
            {
                if (tab[0] > 1 || tab[0] < 0)
                {
                    for (int i = 0; i < tab.Length; i++)
                    {
                        tab[i] = 1; //przemyslec
                    }
                    return;
                }
                else return;
            }

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
            
            if (min == max)
            {
                if (min > 1 || min < 0)
                {
                    for (int i = 0; i < tab.Length; i++)
                    {
                        tab[i] = 1; //przemyslec
                    }
                    return;
                }
                else return;
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

        public List<double[]> SelectColumns(List<double[]> data, int startColumn, int endColumn)
        {
            List<double[]> newData = new List<double[]>();
            int size = endColumn - startColumn + 1;
            double[] vector, oldVector;
            for (int i = 0; i < data.Count; ++i)
            {
                oldVector = data[i];
                vector = new double[size];
                for (int j = 0; j < size; ++j)
                    vector[j] = data[i][j + startColumn - 1];
                newData.Add(vector);
            }

            return newData;
        }

    }
}
