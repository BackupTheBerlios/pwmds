using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class ProcessData
    {
        List<double[]> input;
        List<double[]> output;
        List<double[]> solution;

        public ProcessData()
        {
            input = new List<double[]>();
            output = new List<double[]>();
        }

        public void AddOutput(double[] v)
        {
            output.Add(v);
        }
        
        public void AddSolution(double[] v)
        {
            solution.Add(v);
        }

        public double[] GetInputVector(int nr)
        {
            return input[nr];
        }

        public int Size
        {
            get { return input.Count; }
        }

        public List<double[]> Input
        {
            get { return input; }
            set { input = value; }
        }
        
        public List<double[]> Output
        {
            get { return output; }
            set { output = value; }
        }

        public List<double[]> Solution
        {
            get { return solution; }
            set { solution = value; }
        }

        public static String GetStringList(double[] tab)
        {
            String ret = "";
            for (int i = 0; i < tab.Length; ++i)
                ret += tab[i] + " ";
            return ret;
        }

    }
}
