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
        private int rowHeight = 40;

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

            TextBox textBox = createTextBox();
            this._tableLayers.Controls.Add(textBox, 1, 1);

            ComboBox comboBox = createFunctionsComboBox();
            this._tableLayers.Controls.Add(comboBox, 2, 1);

            int width, height;
            width = this._tableLayers.Size.Width;
            height = this._tableLayers.Size.Height;
            height += rowHeight;

            this._tableLayers.Size = new System.Drawing.Size(width, height);

        }

 

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

            TextBox textBox = createTextBox();
            this._tableLayers.Controls.Add(textBox, 1, lastLayerNr);

            ComboBox combo = createFunctionsComboBox();
            this._tableLayers.Controls.Add(combo, 2, lastLayerNr);

            int width, height;
            width = this._tableLayers.Size.Width;
            height = this._tableLayers.Size.Height;
            height += rowHeight;
            
            this._tableLayers.Size = new System.Drawing.Size(width, height);
        }

        private ComboBox createFunctionsComboBox()
        {
            ComboBox combo = new ComboBox();
            combo.Items.AddRange(Network.Function.FUNCTIONS);
            combo.SelectedIndex = 0;
            combo.Dock = DockStyle.Fill;
            return combo;
        }

        private TextBox createTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.Text = "1";
            textBox.Dock = DockStyle.Fill;
            return textBox;
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

        private void _buttonCreateNetwork_Click(object sender, EventArgs e)
        {
            //Data.NetworkParam param = new Data.NetworkParam();
            //Network.Perceptron newNet = new Network.Perceptron(param);
        }
        
    }
}