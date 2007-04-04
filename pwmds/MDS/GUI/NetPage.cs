using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MDS.Network;

namespace MDS.GUI
{
    /** Class responsible for displaying network data.*/

    class NetPage : TabPage
    {
        private int nr;
        private Perceptron perceptron;
        private List<String> dataNames;

        public NetPage()
        { }

        public NetPage( int nr, List<String> dataNames, Perceptron perceptron)
        {
            this.nr = nr;
            this.dataNames = dataNames;
            this.perceptron = perceptron;
        }

    }
}
