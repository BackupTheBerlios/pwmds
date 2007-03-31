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
        private List<DataLayer> layersInfo;
        private int lastLayerNr;
        private int rowHeight = 50;

        public CreateNetwork()
        {
            InitializeComponent();
            initializeLayersTable();
            layersInfo = new List<DataLayer>();
            lastLayerNr = 1;
        }

        private void initializeLayersTable()
        {
            Label label = new Label();
            label.Text = "Numer warstwy";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add( label, 0,0);

            label = new Label();
            label.Text = "Liczba neuronów";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, 1, 0);

            label = new Label();
            label.Text = "Funkcja przejœcia";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, 2, 0);


            this._tableLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            label = new Label();
            label.Text = "1";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, 0, 1);

            TextBox textBox = new TextBox();
            //textBox.Text = ;
            textBox.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(textBox, 1, 1);

            ComboBox comboBox = new ComboBox();
            //textBox.Text = ;
            comboBox.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(comboBox, 2, 1);

            int width, height;
            width = this._tableLayers.Size.Width;
            height = this._tableLayers.Size.Height;
            height += rowHeight;

            this._tableLayers.Size = new System.Drawing.Size(width, height);

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

        private void _buttonAddLayer_Click(object sender, EventArgs e)
        {
            this._tableLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Label label = new Label();
            ++lastLayerNr;
            label.Text = lastLayerNr.ToString();
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, 0, lastLayerNr);
            int width, height;
            width = this._tableLayers.Size.Width;
            height = this._tableLayers.Size.Height;
            height += rowHeight;
            
            this._tableLayers.Size = new System.Drawing.Size(width, height);
        }

        protected class DataLayer
        {
            protected int layerNr;
            protected int neurons;
            protected String functionName;

            public DataLayer()
            {
            }

            public DataLayer( int layerNr )
            {
                this.layerNr = layerNr;
                this.neurons = 1;
                this.functionName = "";
            }
        }
        
    }
}