using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace MDS.Tests
{
    class TestPreprocessor
    {

        public void printProcessedHashtable(Hashtable x)
        {
            IDictionaryEnumerator e = x.GetEnumerator();
            List<double[]> l;
            while (e.MoveNext())  
            {
                l = (List<double[]>)e.Value;
                IEnumerator<double[]> f = l.GetEnumerator();
                Console.Out.WriteLine("Plik " + e.Key + ":");
                while (f.MoveNext())  
                {
                    
                    for (int i = 0; i < f.Current.Length; i++)
                    {
                        Console.Out.Write(f.Current[i] + "\t");
                    }
                    Console.Out.WriteLine();
                }
            }
        }
    }
}
