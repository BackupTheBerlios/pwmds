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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            int[] tab = { 4, 10, 3, 4, 5};
                
            float[] x ={ 1, 4, -6, 2 };

            try
            {
                Network.Perceptron p = new Network.Perceptron(tab);
                p.printWeights();
                p.setFunctionForLayer(1, 3);
                p.calculateOutput(x);
                
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
        }
    }
}