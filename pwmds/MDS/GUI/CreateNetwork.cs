using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDS.GUI
{
    public partial class CreateNetwork : Form
    {
        public CreateNetwork()
        {
            InitializeComponent();
        }

        private void initializeLayersTable()
        {
//            this._tableLayer;
        }

        /*private void _buttonCreateNetwork_Click(object sender, EventArgs e)
        {
            //Data.NetworkParam param = new Data.NetworkParam();
            //Network.Perceptron newNet = new Network.Perceptron(param);
            
        }*/

        public int NetworkType
        {
            get
            {
                if (this._radioClassifier.Checked == true)
                    return Data.NetworkParam.CLASSIFIER;
                else
                    return Data.NetworkParam.MDS;
            }
        }
    }
}