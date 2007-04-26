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
            solution = new List<double[]>();
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
                if (tab[i].Equals(double.NaN))
                    ret += "NaN   ";
                else
                    ret += GetStringNumber( tab[i]) + "   ";
            return ret;
        }

        public static int GetMainVal(double d)
        {
            if (d < 0)
                return (int)Math.Abs(Math.Ceiling( d));
            else
                return (int)Math.Floor(d);
        }

        public static int GetFraction(double d)
        {
            double dd = Math.Abs(d) - Math.Abs(GetMainVal(d));
            dd *= 100;
            return (int)Math.Floor(dd);
        }

        public static String GetStringNumber(double d)
        {
            String number = "";
            if (d < 0)
                number = "-";
            number += GetMainVal(d) + "," + GetFraction(d);
            
            return number;
        }


    }
}
