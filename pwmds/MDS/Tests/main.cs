using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace MDS.Tests
{
    static class main
    {
        [STAThread]
        static void Main()
        {
/////////////////////////// GUI TESTY ///////////////////////////////////////////////////
            GUI.frmMain frmMain = new MDS.GUI.frmMain(null);
            
            Application.Run(frmMain);
////////////////////////////END GUI TESTY ///////////////////////////////////////////////
        }

            
    }
}
