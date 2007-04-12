using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace MDS.Tests
{
    static class main
    {
        static MainANN engine; 
        [STAThread]
        static void Main()
        {
/////////////////////////// GUI TESTY ///////////////////////////////////////////////////
            engine = new MainANN();
            
            Application.Run(new GUI.frmMain());

            //TestBackpropagation tb = new TestBackpropagation();
            //tb.Demo2();
////////////////////////////END GUI TESTY ///////////////////////////////////////////////
        }

            
    }
}
