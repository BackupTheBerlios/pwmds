using System;
using System.Collections.Generic;
using System.Collections;
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
        private String networkName;
        //private List<String> dataNames;
        private Hashtable inputData;

        private TableLayoutPanel _layeresPanel;
        private Label label1;
        
        private Label _networkType;
        private Label _learnDataLabel;
        private Label _workDataLabel;
        private Label _inputLearnDataLabel;
        private Label _outputLearnDataLabel;

        private Label _inputWorkDataLabel;
        private ComboBox _comboInputLearnData;
        private ComboBox _comboOutputLearnData;
        private ComboBox _comboInputWorkData;
        

        public NetPage()
        { }

        public NetPage( int nr, Hashtable inputData, Perceptron perceptron)
        {
            
            
            this.nr = nr;
            this.inputData = inputData;
            this.perceptron = perceptron;
            InitializeComponent();
            initializeLayersTable();
            initializeComboBoxes();
        }

        //setters and getters
        public String NetworkName
        {
            get{ return networkName; }
            set { networkName = value; }
        }

        private void InitializeComponent()
        {
            this._layeresPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._networkType = new System.Windows.Forms.Label();
            
            this._learnDataLabel = new Label();
            this._inputLearnDataLabel = new Label();
            this._comboInputLearnData = new ComboBox();
            this._outputLearnDataLabel = new Label();
            this._comboOutputLearnData = new ComboBox();
            
            

            this._workDataLabel = new Label();
            this._inputWorkDataLabel = new Label();
            this._comboInputWorkData = new ComboBox();
            this.SuspendLayout();
            // 
            // _layeresPanel
            // 
            //this._layeresPanel.AutoScroll = true;
            this._layeresPanel.BackColor = System.Drawing.Color.White;
            this._layeresPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this._layeresPanel.ColumnCount = 3;
            this._layeresPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._layeresPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._layeresPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._layeresPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._layeresPanel.Location = new System.Drawing.Point(30, 100);
            this._layeresPanel.Name = "_layeresPanel";
            this._layeresPanel.RowCount = 2;
            this._layeresPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
//je¿eli za du¿o warstw to zrób scroll
            
            this._layeresPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Typ sieci:";
            // 
            // _networkType
            // 
            this._networkType.AutoSize = true;
            this._networkType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._networkType.Location = new System.Drawing.Point(100, 20);
            this._networkType.Name = "_networkType";
            this._networkType.Size = new System.Drawing.Size(0, 200);
            this._networkType.TabIndex = 0;
            this._networkType.Text = perceptron.TypeName;

            // 
            // _learnDataLabel
            // 
            this._learnDataLabel.AutoSize = true;
            this._learnDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._learnDataLabel.Location = new System.Drawing.Point(690, 70);
            this._learnDataLabel.Name = "_learnDataLabel";
            this._learnDataLabel.Size = new System.Drawing.Size(73, 20);
            this._learnDataLabel.TabIndex = 0;
            this._learnDataLabel.Text = "Dane ucz¹ce:";
            
            // 
            // _inputLearnDataLabel
            // 
            this._inputLearnDataLabel.AutoSize = true;
            this._inputLearnDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inputLearnDataLabel.Location = new System.Drawing.Point(710, 105);
            this._inputLearnDataLabel.Name = "_inputDataLabel";
            this._inputLearnDataLabel.Size = new System.Drawing.Size(80, 20);
            this._inputLearnDataLabel.TabIndex = 0;
            this._inputLearnDataLabel.Text = "Dane wejœciowe:";
            // 
            // _comboInputLearnData
            // 
            this._comboInputLearnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboInputLearnData.Location = new System.Drawing.Point(840, 100);
            this._comboInputLearnData.Name = "_comboInputLearnData";
            this._comboInputLearnData.Size = new System.Drawing.Size(150, 15);
            this._comboInputLearnData.TabIndex = 0;

            // 
            // _outputLearnDataLabel
            // 
            if (perceptron.Type.CompareTo(Data.NetworkParam.CLASSIFIER) == 0)
            {

                this._outputLearnDataLabel.AutoSize = true;
                this._outputLearnDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._outputLearnDataLabel.Location = new System.Drawing.Point(710, 135);
                this._outputLearnDataLabel.Name = "_inputDataLabel";
                this._outputLearnDataLabel.Size = new System.Drawing.Size(80, 20);
                this._outputLearnDataLabel.TabIndex = 0;
                this._outputLearnDataLabel.Text = "Dane wyjœciowe:";

                // 
                // _comboOutputLearnData
                // 
                this._comboOutputLearnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._comboOutputLearnData.Location = new System.Drawing.Point(840, 130);
                this._comboOutputLearnData.Name = "_comboOutputLearnData";
                this._comboOutputLearnData.Size = new System.Drawing.Size(150, 15);
                this._comboOutputLearnData.TabIndex = 0;

            }
          
            // 
            // _workDataLabel
            // 
            this._workDataLabel.AutoSize = true;
            this._workDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._workDataLabel.Location = new System.Drawing.Point(690, 300);
            this._workDataLabel.Name = "_workDataLabel";
            this._workDataLabel.Size = new System.Drawing.Size(73, 20);
            this._workDataLabel.TabIndex = 0;
            this._workDataLabel.Text = "Dane do przetwarzania";

            // 
            // _inputWorkDataLabel
            // 
            this._inputWorkDataLabel.AutoSize = true;
            this._inputWorkDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inputWorkDataLabel.Location = new System.Drawing.Point(710, 335);
            this._inputWorkDataLabel.Name = "_inputWorkDataLabel";
            this._inputWorkDataLabel.Size = new System.Drawing.Size(80, 20);
            this._inputWorkDataLabel.TabIndex = 0;
            this._inputWorkDataLabel.Text = "Dane wejœciowe:";
            // 
            // _comboInputWorkData
            // 
            this._comboInputWorkData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboInputWorkData.Location = new System.Drawing.Point(840, 330);
            this._comboInputWorkData.Name = "_comboInputWorkData";
            this._comboInputWorkData.Size = new System.Drawing.Size(150, 15);
            this._comboInputWorkData.TabIndex = 0;

            
            // 
            // NetPage
            // 
            this.AccessibleName = "hgfds";
            this.Controls.Add(this.label1);
            this.Controls.Add(this._networkType);
            this.Controls.Add(this._layeresPanel);
            this.Controls.Add(this._learnDataLabel);

            this.Controls.Add(this._inputLearnDataLabel);
            this.Controls.Add(this._comboInputLearnData);

            if (perceptron.Type.CompareTo(Data.NetworkParam.CLASSIFIER) == 0)
            {
                this.Controls.Add(this._outputLearnDataLabel);
                this.Controls.Add(this._comboOutputLearnData);
            }
            
            
            this.Controls.Add(this._workDataLabel);
            this.Controls.Add(this._inputWorkDataLabel);
            this.Controls.Add(this._comboInputWorkData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void initializeLayersTable()
        {
            for (int i = 0; i < perceptron.Size; ++i)
                this._layeresPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._layeresPanel.Size = new System.Drawing.Size(600, 30 * (perceptron.Size + 1) + 8);

            Label label = new Label();
            label.Text = "Numer warstwy";
            label.Dock = DockStyle.Fill;
            this._layeresPanel.Controls.Add(label, CreateNetwork.NUMBER_COL, 0);

            label = new Label();
            label.Text = "Liczba neuronów";
            label.Dock = DockStyle.Fill;
            this._layeresPanel.Controls.Add(label, CreateNetwork.NEURON_COL, 0);

            label = new Label();
            label.Text = "Funkcja przejœcia";
            label.Dock = DockStyle.Fill;
            this._layeresPanel.Controls.Add(label, CreateNetwork.FUNCTION_COL, 0);


            //dodaæ wszystkie warstwy jakie s¹ w sieci
            int size = perceptron.Size;
            Layer layer;
            for (int i = 0; i < size; ++i)
            {
                layer = perceptron.getLayer( i );
                //pierwsza komóka
                label = new Label();
                label.Text = layer.Number.ToString();
                label.Dock = DockStyle.Fill;
                this._layeresPanel.Controls.Add(label, CreateNetwork.NUMBER_COL, i + 1);
                //druga komórka
                label = new Label();
                label.Text = layer.Size.ToString();
                label.Dock = DockStyle.Fill;
                this._layeresPanel.Controls.Add(label, CreateNetwork.NEURON_COL, i+1);

                //trzecia komórka
                label = new Label();
                label.Text = layer.getFunction().Name;
                label.Dock = DockStyle.Fill;
                this._layeresPanel.Controls.Add(label, CreateNetwork.FUNCTION_COL, i + 1);
            }
        }

        private void initializeComboBoxes()
        {
            this._comboInputLearnData.Items.Clear();
            this._comboOutputLearnData.Items.Clear();
            this._comboInputWorkData.Items.Clear();

            IEnumerator e = inputData.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                this._comboOutputLearnData.Items.Add(e.Current);
                this._comboInputLearnData.Items.Add(e.Current);
                this._comboInputWorkData.Items.Add(e.Current);
            }
            if (inputData.Count > 0)
            {
                this._comboInputLearnData.SelectedIndex = 0;
                this._comboOutputLearnData.SelectedIndex = 0;
                this._comboInputWorkData.SelectedIndex = 0;
            }
        }

        public void AddNewData( String name )
        {

        }

        public Hashtable InputData
        {
            set 
            { 
                this.inputData = value;
                initializeComboBoxes();
            }
        }
    }
}
;