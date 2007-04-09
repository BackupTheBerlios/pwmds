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
        private String networkName;
        private List<String> dataNames;

        private TableLayoutPanel _layeresPanel;
        private Label label1;
        private Label _networkType;
        private ComboBox _comboData;
        

        public NetPage()
        { }

        public NetPage( int nr, List<String> dataNames, Perceptron perceptron)
        {
            
            
            this.nr = nr;
            this.dataNames = dataNames;
            this.perceptron = perceptron;
            InitializeComponent();
            initializeLayersTable();
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
            this._comboData = new ComboBox();
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
            // _comboData
            // 
            this._comboData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboData.Location = new System.Drawing.Point(700, 100);
            this._comboData.Name = "_comboData";
            this._comboData.Size = new System.Drawing.Size(100, 18);
            this._comboData.TabIndex = 0;
            for (int i = 0; i < dataNames.Count; ++i )
                this._comboData.Items.Add(this.dataNames[i]);
            // 
            // NetPage
            // 
            this.AccessibleName = "hgfds";
            this.Controls.Add(this.label1);
            this.Controls.Add(this._networkType);
            this.Controls.Add(this._layeresPanel);
            this.Controls.Add(this._comboData);
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
    }
}
;