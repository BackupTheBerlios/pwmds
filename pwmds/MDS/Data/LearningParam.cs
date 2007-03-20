using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class LearningParam
    {
        private double alpha;
        private double tau;
        private double epsilon;

        private List<double[]> input;
        private List<double[]> output;

        public double Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public double Tau
        {
            get { return tau; }
            set { tau =  value; }
        }

        public double Epsilon
        {
            get { return epsilon; }
            set { epsilon = value; }
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
    }
}
