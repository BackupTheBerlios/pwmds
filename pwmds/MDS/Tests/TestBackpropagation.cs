using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Tests
{
    class TestBackpropagation
    {
        public void Demo2()
        {
            int[] tab = { 2, 4,4, 2 };
            Network.Perceptron p = new Network.Perceptron(tab);
            p.printWeights();
            /*p.setFunctionForLayer(0, 0);
            p.setFunctionForLayer(0, 1);
            p.setFunctionForLayer(0, 2);
            p.setFunctionForLayer(0, 3);
            */

            p.setFunctionForLayer(1, 0);
            p.setFunctionForLayer(3, 1);
            p.setFunctionForLayer(3, 2);
            p.setFunctionForLayer(3, 3);            
            //p.setFunctionForLayer(3, 4);
            //p.setFunctionForLayer(3, 5);

            Data.LearningParam param = createTestParam2();
            Network.Backpropagation backp = new MDS.Network.Backpropagation(p, param);
            backp.StartLearn();
            
            p.printWeights();

            //p.calculateOutput(param.Input[0]);
            //p.PrintOutput();
            //p.calculateOutput(param.Input[1]);
            //p.PrintOutput();
        }
        private Data.LearningParam createTestParam2()
        {
            Data.LearningParam param = new MDS.Data.LearningParam();
            param.Alpha = 0.5;
            param.Epsilon = 0.0001;
            //param.Tau = 0;
            param.Teta = 0.9;

            param.Input = new List<double[]>();
            param.Output = new List<double[]>();
            double[] i =  { 0.8, 0.1 };
            double[] o = { 0.1, 0.6 };

            double[] i1 =  { 0.1, 0.9 };
            double[] o1 = { 0.7, 0.2 };
            
            double[] i2 =  { 0.2, 0.2 };
            double[] o2 = { 0.2, 0.8 };

            param.Input.Add(i1);
            param.Output.Add(o1);
            
            param.Input.Add(i);
            param.Output.Add(o);
/* 
           param.Input.Add(i2);
            param.Output.Add(o2);

            double[] i1 =  { 0, 0.9 };
            double[] o1 = { 0.7, 0.2 };
            param.Input.Add(i1);
            param.Output.Add(o1);*/


            return param;
        }

    }
}
