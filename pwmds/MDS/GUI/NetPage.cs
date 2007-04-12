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
        private Hashtable data;
        private List<double[]> currentOutput;
        private Data.ProcessData processData;


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

        private Button _learnButton;
        private Button _startButton;


        private Label _vectorNrLabel;
        private TextBox _tboxVectorNr;
        private Label _inVectorLabel;
        private Label _inVector;

        private Label _solutionVectorLabel;
        private Label _solutionVector;

        private Label _outVectorLabel;
        private Label _outVector;

        private Label _learnRatiosLabel;
        private Label _alphaRatioLabel;
        private Label _epsilonRatioLabel;
        private Label _tetaRatioLabel;
        private TextBox _tboxAlpha;
        private TextBox _tboxEpsilon;
        private TextBox _tboxTeta;

        public NetPage()
        { }

        public NetPage( int nr, Hashtable inputData, Perceptron perceptron)
        {
            this.nr = nr;
            this.data = inputData;
            this.perceptron = perceptron;
            InitializeComponent();
            initializeLayersTable();
            initializeComboBoxes();
            initializeRatios();
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
            
            this._learnButton = new Button();
            this._startButton = new Button();

            this._vectorNrLabel = new Label();
            this._tboxVectorNr = new TextBox();
            this._inVectorLabel = new Label();
            this._inVector = new Label();

            this._solutionVectorLabel = new Label();
            this._solutionVector = new Label();

            this._outVectorLabel = new Label();
            this._outVector = new Label();

            this._learnRatiosLabel = new Label();
            this._alphaRatioLabel = new Label();
            this._epsilonRatioLabel = new Label();
            this._tetaRatioLabel = new Label();

            this._tboxAlpha = new TextBox();
            this._tboxEpsilon = new TextBox();
            this._tboxTeta = new TextBox();

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
            this._learnDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._learnDataLabel.Location = new System.Drawing.Point(690, 70);
            this._learnDataLabel.Name = "_learnDataLabel";
            this._learnDataLabel.Size = new System.Drawing.Size(73, 20);
            this._learnDataLabel.TabIndex = 0;
            this._learnDataLabel.Text = "Dane ucz¹ce:";
            
            // 
            // _inputLearnDataLabel
            // 
            this._inputLearnDataLabel.AutoSize = true;
            this._inputLearnDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inputLearnDataLabel.Location = new System.Drawing.Point(710, 105);
            this._inputLearnDataLabel.Name = "_inputDataLabel";
            this._inputLearnDataLabel.Size = new System.Drawing.Size(80, 20);
            this._inputLearnDataLabel.TabIndex = 0;
            this._inputLearnDataLabel.Text = "Dane wejœciowe:";
            // 
            // _comboInputLearnData
            // 
            this._comboInputLearnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
                this._outputLearnDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._outputLearnDataLabel.Location = new System.Drawing.Point(710, 135);
                this._outputLearnDataLabel.Name = "_inputDataLabel";
                this._outputLearnDataLabel.Size = new System.Drawing.Size(80, 20);
                this._outputLearnDataLabel.TabIndex = 0;
                this._outputLearnDataLabel.Text = "Dane wyjœciowe:";

                // 
                // _comboOutputLearnData
                // 
                this._comboOutputLearnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._comboOutputLearnData.Location = new System.Drawing.Point(840, 130);
                this._comboOutputLearnData.Name = "_comboOutputLearnData";
                this._comboOutputLearnData.Size = new System.Drawing.Size(150, 15);
                this._comboOutputLearnData.TabIndex = 0;

            }

            //
            //_learnRatiosLabel 
            //
            this._learnRatiosLabel.AutoSize = true;
            this._learnRatiosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._learnRatiosLabel.Name = "_learnRatiosLabel";
            this._learnRatiosLabel.Size = new System.Drawing.Size(80, 20);
            this._learnRatiosLabel.Location = new System.Drawing.Point(700, 170);
            this._learnRatiosLabel.TabIndex = 0;
            this._learnRatiosLabel.Text = "Wspó³czynniki uczenia";

            //
            //_alphaRatioLabel 
            //
            this._alphaRatioLabel.AutoSize = true;
            this._alphaRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._alphaRatioLabel.Name = "_learnRatiosLabel";
            this._alphaRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._alphaRatioLabel.Location = new System.Drawing.Point(720, 200);
            this._alphaRatioLabel.TabIndex = 0;
            this._alphaRatioLabel.Text = "Wspó³czynnik alpha";

            //
            //_tboxAlpha 
            //
            this._tboxAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxAlpha.Name = "_tboxAlpha";
            this._tboxAlpha.Size = new System.Drawing.Size(50, 22);
            this._tboxAlpha.TabIndex = 1;
            this._tboxAlpha.Location = new System.Drawing.Point(880, 200);
            //this._tboxAlpha.Text = "1";
            //this._tboxVectorNr.TextChanged += new System.EventHandler(this._tboxVectorNr_TextChanged);

            //
            //_epsilonRatioLabel 
            //
            this._epsilonRatioLabel.AutoSize = true;
            this._epsilonRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._epsilonRatioLabel.Name = "_epsilonRatioLabel";
            this._epsilonRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._epsilonRatioLabel.Location = new System.Drawing.Point(720, 230);
            this._epsilonRatioLabel.TabIndex = 0;
            this._epsilonRatioLabel.Text = "Wspó³czynnik epsilon";
            //
            //_tboxEpsilon 
            //
            this._tboxEpsilon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxEpsilon.Name = "_tboxEpsilon";
            this._tboxEpsilon.Size = new System.Drawing.Size(50, 22);
            this._tboxEpsilon.TabIndex = 1;
            this._tboxEpsilon.Location = new System.Drawing.Point(880, 230);
            //
            //_tetaRatioLabel 
            //
            this._tetaRatioLabel.AutoSize = true;
            this._tetaRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tetaRatioLabel.Name = "_tetaRatioLabel";
            this._tetaRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._tetaRatioLabel.Location = new System.Drawing.Point(720, 260);
            this._tetaRatioLabel.TabIndex = 0;
            this._tetaRatioLabel.Text = "Wspó³czynnik teta";

            //
            //_tboxTeta 
            //
            this._tboxTeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxTeta.Name = "_tboxTeta";
            this._tboxTeta.Size = new System.Drawing.Size(50, 22);
            this._tboxTeta.TabIndex = 1;
            this._tboxTeta.Location = new System.Drawing.Point(880, 260);
            

            // 
            // _learnButton
            // 
            this._learnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._learnButton.Location = new System.Drawing.Point(700, 290);
            this._learnButton.Name = "_learnButton";
            this._learnButton.Size = new System.Drawing.Size(150, 30);
            this._learnButton.TabIndex = 0;
            this._learnButton.Text = "Ucz sieæ";
            this._learnButton.Click += new System.EventHandler(this._learnButton_Click);
          
            // 
            // _workDataLabel
            // 
            this._workDataLabel.AutoSize = true;
            this._workDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._workDataLabel.Location = new System.Drawing.Point(690, 350);
            this._workDataLabel.Name = "_workDataLabel";
            this._workDataLabel.Size = new System.Drawing.Size(73, 20);
            this._workDataLabel.TabIndex = 0;
            this._workDataLabel.Text = "Dane do przetwarzania";

            // 
            // _inputWorkDataLabel
            // 
            this._inputWorkDataLabel.AutoSize = true;
            this._inputWorkDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inputWorkDataLabel.Location = new System.Drawing.Point(710, 385);
            this._inputWorkDataLabel.Name = "_inputWorkDataLabel";
            this._inputWorkDataLabel.Size = new System.Drawing.Size(80, 20);
            this._inputWorkDataLabel.TabIndex = 0;
            this._inputWorkDataLabel.Text = "Dane wejœciowe:";
            // 
            // _comboInputWorkData
            // 
            this._comboInputWorkData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboInputWorkData.Location = new System.Drawing.Point(840, 380);
            this._comboInputWorkData.Name = "_comboInputWorkData";
            this._comboInputWorkData.Size = new System.Drawing.Size(150, 15);
            this._comboInputWorkData.TabIndex = 0;


            

            // 
            // _startButton
            // 
            this._startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._startButton.Location = new System.Drawing.Point(710, 500);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(150, 30);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Rozpocznij przetwarzanie";
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            
            //
            //_vectorNrLabel 
            //
            this._vectorNrLabel.AutoSize = true;
            this._vectorNrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._vectorNrLabel.Name = "_vectorNrLabel";
            this._vectorNrLabel.Size = new System.Drawing.Size(80, 20);
            this._vectorNrLabel.TabIndex = 0;
            this._vectorNrLabel.Text = "Numer wektora:";
            //
            //_tboxVectorNr 
            //
            this._tboxVectorNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            
            this._tboxVectorNr.Name = "_tboxVectorNr";
            this._tboxVectorNr.Size = new System.Drawing.Size(50, 22);
            this._tboxVectorNr.TabIndex = 1;
            this._tboxVectorNr.Text = "1";
            this._tboxVectorNr.TextChanged += new System.EventHandler(this._tboxVectorNr_TextChanged);


            //
            //_inVectorLabel 
            //
            this._inVectorLabel.AutoSize = true;
            this._inVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inVectorLabel.Name = "_inVectorLabel";
            this._inVectorLabel.Size = new System.Drawing.Size(80, 20);
            this._inVectorLabel.TabIndex = 0;
            this._inVectorLabel.Text = "Wektor wejœcia";

            //
            //_inVector
            //
            //this._inVector.AutoSize = true;
            this._inVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inVector.Name = "_inVector";
            this._inVector.BackColor = System.Drawing.Color.White;
            this._inVector.TabIndex = 0;
            this._inVector.Text = "    ";

           // if (perceptron.Type == Data.NetworkParam.MDS)
            //{

                //
                //_solutionVectorLabel 
                //
                this._solutionVectorLabel.AutoSize = true;
                this._solutionVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._solutionVectorLabel.Name = "_solutionVectorLabel";
                this._solutionVectorLabel.Size = new System.Drawing.Size(80, 20);
                this._solutionVectorLabel.TabIndex = 0;
                this._solutionVectorLabel.Text = "Wektor rozwi¹zania";

                //
                //_solutionVector
                //
                //this._inVector.AutoSize = true;
                this._solutionVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._solutionVector.Name = "_solutionVector";
                this._solutionVector.BackColor = System.Drawing.Color.White;
                this._solutionVector.TabIndex = 0;
                this._solutionVector.Text = "    ";
        //    }

                //
                //_outVectorLabel 
                //
                this._outVectorLabel.AutoSize = true;
                this._outVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._outVectorLabel.Name = "_outVectorLabel";
                this._outVectorLabel.Size = new System.Drawing.Size(80, 20);
                this._outVectorLabel.TabIndex = 0;
                this._outVectorLabel.Text = "Wektor wyjœciowy";

                //
                //_outVector
                //
                //this._inVector.AutoSize = true;
                this._outVector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this._outVector.Name = "_outVector";
                this._outVector.BackColor = System.Drawing.Color.White;
                this._outVector.TabIndex = 0;
                this._outVector.Text = "    ";

               




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

            this.Controls.Add(this._learnButton);
            this.Controls.Add(this._startButton);

            this.Controls.Add(this._vectorNrLabel);
            this.Controls.Add(this._tboxVectorNr);
            this.Controls.Add(this._inVectorLabel);
            this.Controls.Add(this._inVector);

            this.Controls.Add(this._solutionVectorLabel);
            this.Controls.Add(this._solutionVector);

            this.Controls.Add(this._outVectorLabel);
            this.Controls.Add(this._outVector);

            this.Controls.Add(this._learnRatiosLabel);
            this.Controls.Add(this._alphaRatioLabel);
            this.Controls.Add(this._epsilonRatioLabel);
            this.Controls.Add(this._tetaRatioLabel);
            
            this.Controls.Add(this._tboxAlpha);
            this.Controls.Add(this._tboxEpsilon);
            this.Controls.Add(this._tboxTeta);

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
            this._vectorNrLabel.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height);
            this._tboxVectorNr.Location = new System.Drawing.Point(180, 150 + _layeresPanel.Size.Height);
            this._inVectorLabel.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height + 70);

            this._inVector.Size = new System.Drawing.Size(_layeresPanel.Size.Width, 20);
            this._inVector.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height + 90);

            this._solutionVectorLabel.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height + 130);
            this._solutionVector.Size = new System.Drawing.Size(_layeresPanel.Size.Width, 20);
            this._solutionVector.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height + 150);

            this._outVectorLabel.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height + 190);
            this._outVector.Size = new System.Drawing.Size(_layeresPanel.Size.Width, 20);
            this._outVector.Location = new System.Drawing.Point(30, 150 + _layeresPanel.Size.Height + 210);

        }

        private void initializeComboBoxes()
        {
            this._comboInputLearnData.Items.Clear();
            this._comboOutputLearnData.Items.Clear();
            this._comboInputWorkData.Items.Clear();

            IEnumerator e = data.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                this._comboOutputLearnData.Items.Add(e.Current);
                this._comboInputLearnData.Items.Add(e.Current);
                this._comboInputWorkData.Items.Add(e.Current);
            }
            if (data.Count > 0)
            {
                this._comboInputLearnData.SelectedIndex = 0;
                this._comboOutputLearnData.SelectedIndex = 0;
                this._comboInputWorkData.SelectedIndex = 0;
            }
        }


        private void initializeRatios()
        {
            this._tboxAlpha.Text = "0,5";
            this._tboxEpsilon.Text = "0,0001";
            this._tboxTeta.Text = "0,9";
        }
        public void AddNewData( String name )
        {

        }

        //setters and getters
        public String NetworkName
        {
            get { return networkName; }
            set 
            { 
                networkName = value;
                this.Text = value;
            }
        }

        public Hashtable InputData
        {
            set 
            { 
                this.data = value;
                initializeComboBoxes();
            }
        }


        private void _learnButton_Click(object sender, EventArgs e)
        {
            Data.LearningParam param = new Data.LearningParam();
            String inputName = this._comboInputLearnData.Text,
                    outputName;
            if( perceptron.Type == Data.NetworkParam.CLASSIFIER)
                outputName = this._comboOutputLearnData.Text;
            else
                outputName = inputName;
            param.Input = (List<double[]>)data[inputName];
            param.Output = (List<double[]>)data[outputName];
            try
            {
                param.Alpha = Double.Parse(this._tboxAlpha.Text);
                //0.5;
                param.Epsilon = Double.Parse(this._tboxEpsilon.Text);
                    //0.0001;
                //param.Tau = 0;
                param.Teta = Double.Parse(this._tboxTeta.Text);
                    //0.9;

                Network.Backpropagation backprop = new Network.Backpropagation(perceptron, param);
                backprop.Learn();
            }
            catch(Exception)
            {
            }
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            
            String inputName = this._comboInputWorkData.Text;
            processData = new MDS.Data.ProcessData();
            processData.Input = (List<double[]>)data[inputName];
            try
            {

                perceptron.Process(processData);
                currentOutput = processData.Output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot start processing the network");
                Console.Out.WriteLine(ex.Message);
            }

            //
            try
            {
                int nr = 1;
                this._tboxVectorNr.Text = "1";
                this._inVector.Text = Data.ProcessData.GetStringList( processData.Input[nr-1]);
                this._solutionVector.Text = Data.ProcessData.GetStringList(processData.Solution[nr-1]);
                this._outVector.Text = Data.ProcessData.GetStringList(processData.Output[nr-1]);
            }
            catch (Exception) { }
        }

        private void _tboxVectorNr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int nr = int.Parse(_tboxVectorNr.Text);
                this._inVector.Text = Data.ProcessData.GetStringList(processData.Input[nr-1]);
                this._solutionVector.Text = Data.ProcessData.GetStringList(processData.Solution[nr-1]);
                this._outVector.Text = Data.ProcessData.GetStringList(processData.Output[nr-1]);
            }
            catch (Exception) { }
        }
    }
}
;