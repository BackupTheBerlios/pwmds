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
        private List<Network.Layer> layers;
        private int lastLayerNr;
        private int rowHeight = 40;
        private int outLayerNr;

        private List<Network.Function> functions;
        private List<int> neuronsInLayer;
        private int type;

        public List<Network.Function> Functions
        {
            get { return functions; }
        }
        
        private int NUMBER_COL = 0,
                    NEURON_COL = 1,
                    FUNCTION_COL = 2,
                    DELETE_COL = 3;

        public CreateNetwork()
        {
            InitializeComponent();
            lastLayerNr = 0;
            //layers = new List<Network.Layer>();
            functions = new List<Network.Function>();
            neuronsInLayer = new List<int>();
            initializeLayersTable();            
        }

        private void initializeLayersTable()
        {
            Label label = new Label();
            label.Text = "Numer warstwy";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, NUMBER_COL, 0);

            label = new Label();
            label.Text = "Liczba neuronów";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, NEURON_COL, 0);

            label = new Label();
            label.Text = "Funkcja przejœcia";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, FUNCTION_COL, 0);


     /*       this._tableLayers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            label = new Label();
            label.Text = "1";
            label.Dock = DockStyle.Fill;
            this._tableLayers.Controls.Add(label, NUMBER_COL, 1);

            TextBox textBox = createTextBox();
            textBox.TextChanged += new System.EventHandler(this._tboxNeuronsNr_TextChanged);
            this._tableLayers.Controls.Add(textBox, NEURON_COL, 1);

            ComboBox comboBox = createFunctionsComboBox();
            this._tableLayers.Controls.Add(comboBox, FUNCTION_COL, 1);

            int width, height;
            width = this._tableLayers.Size.Width;
            height = this._tableLayers.Size.Height;
            height += rowHeight;

            this._tableLayers.Size = new System.Drawing.Size(width, height);
            ++lastLayerNr;
            addNewLayer();*/

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
            this._tableLayers.Controls.Add(label, NUMBER_COL, lastLayerNr);

            TextBox textBox = createTextBox();
            textBox.TextChanged += new System.EventHandler(this._tboxNeuronsNr_TextChanged);
            this._tableLayers.Controls.Add(textBox, NEURON_COL, lastLayerNr);

            ComboBox combo = createFunctionsComboBox();
            combo.SelectedValueChanged += new System.EventHandler(this._comboFunction_SelectedValueChanged);

            this._tableLayers.Controls.Add(combo, FUNCTION_COL, lastLayerNr);

            int width, height;
            width = this._tableLayers.Size.Width;
            height = this._tableLayers.Size.Height;
            height += rowHeight;
            
            this._tableLayers.Size = new System.Drawing.Size(width, height);

            //przesuñ wszystkie kontrolki poni¿ej o rowHeight
            this._buttonAddLayer.Location = new Point(this._buttonAddLayer.Location.X,
                                                this._buttonAddLayer.Location.Y + rowHeight);
            this._buttonCreateNetwork.Location = new Point(this._buttonCreateNetwork.Location.X,
                                                this._buttonCreateNetwork.Location.Y + rowHeight);
            this._labelOutLayer.Location = new Point(this._labelOutLayer.Location.X,
                                                this._labelOutLayer.Location.Y + rowHeight);
            this._cancelButton.Location = new Point(this._cancelButton.Location.X,
                                                this._cancelButton.Location.Y + rowHeight);
            this._tboxSolutionLayerNr.Location = new Point(this._tboxSolutionLayerNr.Location.X,
                                                this._tboxSolutionLayerNr.Location.Y + rowHeight);
            this.Size = new Size(this.Size.Width,
                                    this.Size.Height + rowHeight);
            //dodaj now¹ warstwê
            addNewLayer();

            this._tboxSolutionLayerNr.Enabled = true;
            this._tboxSolutionLayerNr.Text = "1";
           

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

        private void addNewLayer()
        {
         //   Network.Layer newLayer;
            //int neurons ;
        /*    try
            {
                neurons = int.Parse(this._tableLayers.Controls[(lastLayerNr - 1) * (FUNCTION_COL + 1) + NEURON_COL].Text);
            }
            catch (Exception err)
            {
                return;
            }*/
            //newLayer = new Network.Layer(lastLayerNr, 1);
            String funName = this._tableLayers.Controls[(lastLayerNr - 1) * (FUNCTION_COL + 1) + FUNCTION_COL].Text;
            Network.Function fun = new Network.Function();
            fun.setId(funName);
            functions.Add( fun );

            neuronsInLayer.Add(1);
            
            //newLayer.SetFunction(funName);
            //layers.Add(newLayer);
        }
/*
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
*/
        private void _buttonCreateNetwork_Click(object sender, EventArgs e)
        {
            //Data.NetworkParam param = new Data.NetworkParam();
            //Network.Perceptron newNet = new Network.Perceptron(param);
        }

        private void _tboxSolutionLayerNr_TextChanged(object sender, EventArgs e)
        {
            //int outLayerNr = 1;
            String text = this._tboxSolutionLayerNr.Text;
            if (text.Length == 0)
                return;
            try
            {
                outLayerNr = int.Parse( text );
            }
            catch (Exception ex)
            {
                MessageBox.Show("You've given wrong argument");
            }

            if( outLayerNr < 1 || outLayerNr > lastLayerNr )
                MessageBox.Show("You've given wrong value");

        }

        private void _tboxNeuronsNr_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int nr = getControlNumber(control);
            int y = (int)Math.Floor((double)nr / (FUNCTION_COL + 1)); //numer warstwy
            //int x = nr - y * (FUNCTION_COL + 1);
            int nnr = 0;
            TextBox box = (TextBox)sender;
            if (box.Text.Length == 0)
                return;
            try
            {
                nnr = int.Parse(box.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show("You've given wrong argument");
                return;
            }
            neuronsInLayer[y - 1] = nnr;
        }


        private void _comboFunction_SelectedValueChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int nr = getControlNumber(control);
            int y = (int)Math.Floor((double)nr / (FUNCTION_COL + 1)); //numer warstwy
            //int x = nr - y * (FUNCTION_COL + 1);
            int nnr = 0;
            ComboBox combo = (ComboBox)sender;
            int id = combo.SelectedIndex;

            String funName = (String)combo.Items[id]; 
            functions[y - 1].setId( funName );
        }
        private int getControlNumber(Control control)
        {
            int nr = 0;
            //System.Collection enumer = _tableLayers.Controls;

            while (_tableLayers.Controls[nr] != control)
            {
             
                ++nr;
            }
            return nr;
        }
        
        public List<int> NeuronsInLayer
        {
            get { return neuronsInLayer; }
        }

        public int Type
        {
            get { return type; }
        }

        public int LayersNumber
        {
            get { return lastLayerNr; }
        }
    }
}