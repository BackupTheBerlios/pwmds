using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class LearningParam
    {
        private double alpha;
        private double teta;
        private bool oneTeta;

        private double tau;/////////
        
        private double epsilon;
        
        private int kFoldSamples;

        private bool earlyStop;
        private double learnSet;
        private double validateSet;
        private double testSet;

        private List<double[]> input;
        private List<double[]> output;

        public double Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }
        public double Teta
        {
            get { return teta; }
            set { teta = value; }
        }

        public double Tau
        {
            get { return tau; }
            set { tau =  value; }
        }

        public bool OneTeta
        {
            get { return oneTeta; }
            set { oneTeta = value; }
        }

        public double Epsilon
        {
            get { return epsilon; }
            set { epsilon = value; }
        }

        public int KFoldSamples
        {
            get { return kFoldSamples; }
            set { kFoldSamples = value; }
        }

        public bool EarlyStop
        {
            get { return earlyStop; }
            set { earlyStop = value; }
        }

        public double LearnSet
        {
            get { return learnSet; }
            set { learnSet = value; }
        }

        public double ValidateSet
        {
            get { return validateSet; }
            set { validateSet = value; }
        }

        public double TestSet
        {
            get { return testSet; }
            set { testSet = value; }
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
