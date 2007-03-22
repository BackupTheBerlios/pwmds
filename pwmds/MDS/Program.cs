using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MDS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MDS.GUI.frmMain());
            


            try
            {
                //Demo1();
                Demo2();
                
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
        }
        static void Demo1()
        {
            int[] tab = { 4, 10, 3, 4, 5 };
            int[] tab1 = { 3, 3, 3 };

            double[] x ={ 1, 1, 1 };

            Network.Perceptron p = new Network.Perceptron(tab1);
            p.printWeights();
            p.setFunctionForLayer(3, 0);
            p.setFunctionForLayer(3, 1);
            p.setFunctionForLayer(3, 2);
            p.calculateOutput(x);

            Data.LearningParam param = createTestParam();
            Network.Backpropagation backp = new MDS.Network.Backpropagation(p, param);
            backp.Learn();
            p.printWeights();
        }
        static void Demo2()
        {
            int[] tab = { 2, 2, 2};
            Network.Perceptron p = new Network.Perceptron(tab);
            p.printWeights();
            p.setFunctionForLayer(3, 0);
            p.setFunctionForLayer(3, 1);
            p.setFunctionForLayer(3, 2);           

            Data.LearningParam param = createTestParam2();
            Network.Backpropagation backp = new MDS.Network.Backpropagation(p, param);
            backp.Learn();
            //p.printWeights();
        }
        static Data.LearningParam createTestParam2()
        {
            Data.LearningParam param = new MDS.Data.LearningParam();
            param.Alpha = 0.5;
            param.Epsilon = 10e-4;
            param.Tau = 5;
            param.Input = new List<double[]>();
            param.Output = new List<double[]>();
            double[] i =  { 0.6, 0 };
            double[] o = { 0, 0.6 };
            param.Input.Add(i);
            param.Output.Add(o);
            double[] i1 =  { 0.2, 0.5 };
            double[] o1 = { 0.2, 0.5 };
            param.Input.Add(i1);
            param.Output.Add(o1);
            double[] i2 =  { 0.1, 0.1 };
            double[] o2 = { 0.2, 0.8 };
            param.Input.Add(i2);
            param.Output.Add(o2);
            return param;
        }
        static Data.LearningParam createTestParam()
        {
            Data.LearningParam param = new MDS.Data.LearningParam();
            param.Alpha = 0.5;
            param.Epsilon = 10e-4;
            param.Tau = 5;
            param.Input = new List<double[]>();
            param.Output = new List<double[]>();
            double[] i =  { 0.6, 0, 0 };
            double[] o = { 0, 0, 0.3};
            param.Input.Add(i);
            param.Output.Add(o);
            double[] i1 =  { 0, 1, 0 };
            double[] o1 = { 0, 2, 0 };
            param.Input.Add(i1);
            param.Output.Add(o1);
            double[] i2 =  { 0, 0, 1 };
            double[] o2 = { 0, 0, 3 };
            param.Input.Add(i2);
            param.Output.Add(o2);
            return param;
        }
    }
}