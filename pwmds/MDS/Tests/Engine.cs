using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MDS.Tests
{
    class Engine
    {
        private GUI.frmMain frmMain;

        
        public Engine()
        {
            frmMain = new MDS.GUI.frmMain(this);
            Application.Run(frmMain);
        }

        public void Test()
        {
            MessageBox.Show("ok");
        }

    }
}
