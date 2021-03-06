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
        private static int LEFT_MARGIN = 30, RIGHT_MARGIN = 30,
                            UP_MARGIN = 10, DOWN_MARGIN = 10,
                            PANEL_DISTANCE = 50,
                            CONTROL_VDISTANCE_S = 5, CONTROL_HDISTANCE_S = 5,
                            CONTROL_VDISTANCE_B = 20, CONTROL_HDISTANCE_B = 10,
                            CONTROL_HEIGHT = 40, CONTROL_WIDTH = 170,
                            LAYERS_PANEL_WIDTH = 400;
        private frmMain frm;
        private int nr;
        private Perceptron perceptron;
        private String networkName;
        //private List<String> dataNames;
        private Hashtable data;
        private List<double[]> currentOutput;
        private Data.ProcessData processData;
        Network.Backpropagation backprop;

        
    #region declaration_network_info_controls

        private TableLayoutPanel _layeresPanel;
        private Label _labelPreNetType;
        private Label _labelNetType;
    #endregion
    #region declaration_learning_controls
        private Panel _panelLearn;
        private Label _labelLearnTitle;
        
        private Panel _panelLearnInputData;       
        private ComboBox _comboInputLearnData;
        
        private Panel _panelLearnOutputData;
        private ComboBox _comboOutputLearnData;


        private Label _alphaRatioLabel;
        private Label _epsilonRatioLabel;
        
        private TextBox _tboxAlpha;
        private TextBox _tboxEpsilon;
        
        private GroupBox _groupTeta;
        private Label _tetaRatioLabel;
        private TextBox _tboxTeta;
        private RadioButton _radioOneTeta;
        private RadioButton _radioDiffTeta;

        private GroupBox _groupLearnMethod;

        /** k fold cross validation */
        //private CheckBox _chboxKFold;
        private RadioButton _radioKFold;
        private TextBox _tboxKFold;

        /** early stopping */

        //private CheckBox _chboxEarlyStop;
        private RadioButton _radioEarlyStop;
        private Label _labelLearnSet;
        private Label _labelValidateSet;
        private Label _labelTestSet;

        private TextBox _tboxLearnSet;
        private TextBox _tboxValidateSet;
        private TextBox _tboxTestSet;

        private Label _labelError;
        private TextBox _tboxError;

        private Button _buttonLearn;
        private Button _buttonClose;
        //private Button _buttonPauseLearn;
        private Button _buttonStopLearn;
        private Button _buttonContinueLearn;
    #endregion

    #region declaration_working_controls
        private Label _labelWorkTitle;
        private Label _workDataLabel;
        private Panel _panelWork;
        private Panel _panelWorkInputData;
        private ComboBox _comboInputWorkData;


        private Button _startButton;
    #endregion

    #region declaration_result_controls
        private Panel _panelResult;
        private Label _prelabelResult;
        //private Label _labelResult;
        private TextBox _tboxResult;

        private Label _labelResultError;
        private TextBox _tboxResultError;

        private Label _labelStress;
        private TextBox _tboxStress;

        private Button _buttonSaveSolution;

        private Panel _panelProperOutputData;
        private ComboBox _comboProperOutputData;

        private Label _labelGood;
        private TextBox _tboxGood;
        private Button _buttonCalculateGood;

    #endregion

    #region declaration_other_controls
        private List<ComboBox> comboBoxes;
        private Label _vectorNrLabel;
        private TextBox _tboxVectorNr;
        private Label _inVectorLabel;
        private Label _inVector;

        private Label _solutionVectorLabel;
        private Label _solutionVector;

        private Label _outVectorLabel;
        private Label _outVector;
    #endregion

        public NetPage()
        { }

        public NetPage( frmMain frm,int nr, Hashtable inputData, Perceptron perceptron)
        {
            this.frm = frm;
            this.nr = nr;
            this.data = inputData;
            this.perceptron = perceptron;
            this.AutoScroll = true;
            comboBoxes = new List<ComboBox>();
            InitializeComponent();
            //setControls();
            initializeDataPanels();
            initializeRatios();
            backprop = new Backpropagation(perceptron, null);
        }

        private Panel createProcessDataPanel( String preComboText, ComboBox comboData, int dataSize, int vectorSize )
        {
            int LABEL_Y = 8, 
                width = 0, height = 40;
            Panel panel = new Panel();
            //czy dane s¹ wejœciowe, czy wyjœciowa
            Label preComboLabel = new Label();
            preComboLabel.Text = preComboText;
            preComboLabel.AutoSize = true;
            preComboLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            preComboLabel.Location = new System.Drawing.Point(0, LABEL_Y);
            preComboLabel.TabIndex = 0;
            panel.Controls.Add(preComboLabel);


            //ComboBox z danymi
            comboData.Location = new System.Drawing.Point(preComboLabel.Size.Width + CONTROL_HDISTANCE_S, 0);
            comboData.SelectedValueChanged += new EventHandler(_comboBox_SelectedValueChanged);
            comboBoxes.Add(comboData);
            panel.Controls.Add(comboData);

            Button _buttonDataDetails = new Button();
            _buttonDataDetails.Text = "Szczegóły";
            _buttonDataDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            _buttonDataDetails.Name = "_buttonDataDetails";
            _buttonDataDetails.Location = new System.Drawing.Point(comboData.Location.X + comboData.Size.Width +
                CONTROL_HDISTANCE_B, comboData.Location.Y);
            _buttonDataDetails.AutoSize = true;
            _buttonDataDetails.Click += new EventHandler(_buttonDataDetails_Click);
            panel.Controls.Add(_buttonDataDetails);


            //width = labelVectorSize.Location.X + labelVectorSize.Size.Width;
            width = _buttonDataDetails.Location.X + _buttonDataDetails.Size.Width;
            panel.Size = new System.Drawing.Size(width, height);
            return panel;
        }

        private void InitializeComponent()
        {

            this._vectorNrLabel = new Label();
            this._tboxVectorNr = new TextBox();
            this._inVectorLabel = new Label();
            this._inVector = new Label();

            this._solutionVectorLabel = new Label();
            this._solutionVector = new Label();

            this._outVectorLabel = new Label();
            this._outVector = new Label();

            this.SuspendLayout();

        #region initialization_network_info_controls
            // 
            // _labelPreNetType
            // 
            this._labelPreNetType = new System.Windows.Forms.Label();
            this._labelPreNetType.AutoSize = true;
            this._labelPreNetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelPreNetType.Location = new System.Drawing.Point(LEFT_MARGIN, UP_MARGIN);
            this._labelPreNetType.Name = "_labelPreNetType";
            this._labelPreNetType.TabIndex = 0;
            this._labelPreNetType.Text = "Typ sieci:";
            // 
            // _labelNetType
            // 
            this._labelNetType = new System.Windows.Forms.Label();
            this._labelNetType.AutoSize = true;
            this._labelNetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelNetType.Location = new System.Drawing.Point(LEFT_MARGIN + this._labelPreNetType.Size.Width + CONTROL_HDISTANCE_S, UP_MARGIN);
            this._labelNetType.Name = "_labelNetType";
            this._labelNetType.TabIndex = 0;
            this._labelNetType.Text = perceptron.TypeName;
            
            // 
            // _layeresPanel
            // 
            
            this._layeresPanel = new System.Windows.Forms.TableLayoutPanel();
            
            this._layeresPanel.BackColor = System.Drawing.Color.White;
            this._layeresPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this._layeresPanel.ColumnCount = 3;
            this._layeresPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._layeresPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._layeresPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._layeresPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._layeresPanel.Location = new System.Drawing.Point(LEFT_MARGIN, UP_MARGIN + this._labelNetType.Size.Height + CONTROL_VDISTANCE_S);
            this._layeresPanel.Name = "_layeresPanel";
            this._layeresPanel.RowCount = 2;
            this._layeresPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
//je¿eli za du¿o warstw to zrób scroll
            
            this._layeresPanel.TabIndex = 0;
            initializeLayersTable();
            
            
        #endregion
        #region initialization_learning_controls
            //_learnPanel

            this._panelLearn = new Panel();
            this._panelLearn.Location = new System.Drawing.Point(LEFT_MARGIN + LAYERS_PANEL_WIDTH+ PANEL_DISTANCE + 30, UP_MARGIN);
            //this._panelLearn.BorderStyle = BorderStyle.FixedSingle;
            //this._panelLearn.Size = new System.Drawing.Size(750, 300);
            this._panelLearn.AutoSize = true;

            // 
            // _labelLearnTitle
            // 
            this._labelLearnTitle = new Label();
            this._labelLearnTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelLearnTitle.Name = "_labelLearnTitle";
            this._labelLearnTitle.Size = new System.Drawing.Size(this._panelLearn.Size.Width, 20);
            this._labelLearnTitle.TabIndex = 0;
            this._labelLearnTitle.Text = "UCZENIE SIECI";
            this._labelLearnTitle.Location = new System.Drawing.Point(0, 5);
            this._labelLearnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this._panelLearn.Controls.Add(this._labelLearnTitle);

            // _buttonClose
            this._buttonClose = new Button();
            this._buttonClose.AutoSize = true;
            this._buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonClose.Location = new System.Drawing.Point(350, 0);
               // this._groupLearnMethod.Location.Y + this._groupLearnMethod.Size.Height + CONTROL_VDISTANCE_S);
            this._buttonClose.Name = "_buttonClose";
            //this._buttonLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonClose.TabIndex = 0;
            this._buttonClose.Text = "Zamknij zakładkę";
            this._buttonClose.Click += new System.EventHandler(this._closeButton_Click);
            this._panelLearn.Controls.Add(this._buttonClose);



            // 
            // _comboInputLearnData
            // 
            this._comboInputLearnData = new ComboBox();
            
            this._comboInputLearnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboInputLearnData.Name = "_comboInputLearnData";
            this._comboInputLearnData.Size = new System.Drawing.Size(150, 15);
            this._comboInputLearnData.TabIndex = 0;
            this._comboInputLearnData.Sorted = true;
            // 
            // _panelLearnInputData
            // 
            this._panelLearnInputData = createProcessDataPanel("Dane wejściowe", this._comboInputLearnData, 0, 0);
            this._panelLearnInputData.Location = new System.Drawing.Point(0, this._labelLearnTitle.Location.Y + 
                this._labelLearnTitle.Size.Height + CONTROL_VDISTANCE_B);

            this._panelLearn.Controls.Add(this._panelLearnInputData);

            // 
            // _comboOutputLearnData
            // 
            this._comboOutputLearnData = new ComboBox();
            this._comboOutputLearnData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboOutputLearnData.Location = new System.Drawing.Point(140, 90);
            this._comboOutputLearnData.Name = "_comboOutputLearnData";
            this._comboOutputLearnData.Size = new System.Drawing.Size(150, 15);
            this._comboOutputLearnData.TabIndex = 0;
            this._comboOutputLearnData.Sorted = true;
            

            // 
            // _panelLearnOutputData
            // 
            this._panelLearnOutputData = createProcessDataPanel("Dane wyjściowe", this._comboOutputLearnData, 0, 0);
            this._panelLearnOutputData.Location = new System.Drawing.Point(0, this._panelLearnInputData.Location.Y +
                    this._panelLearnInputData.Size.Height + CONTROL_VDISTANCE_S);

            this._panelLearn.Controls.Add(this._panelLearnOutputData);

            //
            //_alphaRatioLabel 
            //
            this._alphaRatioLabel = new Label();
            this._alphaRatioLabel.AutoSize = true;
            this._alphaRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._alphaRatioLabel.Name = "_learnRatiosLabel";
            this._alphaRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._alphaRatioLabel.Location = new System.Drawing.Point(0, this._panelLearnOutputData.Location.Y + 
                this._panelLearnOutputData.Size.Height + CONTROL_VDISTANCE_S );
            this._alphaRatioLabel.TabIndex = 0;
            this._alphaRatioLabel.Text = "Współczynnik momentu";

            this._panelLearn.Controls.Add(this._alphaRatioLabel);

            //
            //_tboxAlpha 
            //
            this._tboxAlpha = new TextBox();
            this._tboxAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxAlpha.Name = "_tboxAlpha";
            this._tboxAlpha.Size = new System.Drawing.Size(55, 22);
            this._tboxAlpha.TabIndex = 1;
            this._tboxAlpha.Location = new System.Drawing.Point(CONTROL_WIDTH , this._alphaRatioLabel.Location.Y);
            this._tboxAlpha.TextAlign = HorizontalAlignment.Center;
            this._panelLearn.Controls.Add(this._tboxAlpha);

            //this._tboxAlpha.Text = "1";
            //this._tboxVectorNr.TextChanged += new System.EventHandler(this._tboxVectorNr_TextChanged);

            //
            //_epsilonRatioLabel 
            //
            this._epsilonRatioLabel = new Label();
            this._epsilonRatioLabel.AutoSize = true;
            this._epsilonRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._epsilonRatioLabel.Name = "_epsilonRatioLabel";
            //this._epsilonRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._epsilonRatioLabel.Location = new System.Drawing.Point(0, this._alphaRatioLabel.Location.Y + 
                        this._alphaRatioLabel.Size.Height + CONTROL_VDISTANCE_S);
            this._epsilonRatioLabel.TabIndex = 0;
            this._epsilonRatioLabel.Text = "Dokładność";
            this._panelLearn.Controls.Add(this._epsilonRatioLabel);
            //
            //_tboxEpsilon 
            //
            this._tboxEpsilon = new TextBox();
            this._tboxEpsilon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxEpsilon.Name = "_tboxEpsilon";
            this._tboxEpsilon.Size = new System.Drawing.Size(55, 22);
            this._tboxEpsilon.TabIndex = 1;
            this._tboxEpsilon.Location = new System.Drawing.Point(CONTROL_WIDTH, this._epsilonRatioLabel.Location.Y);
            this._tboxEpsilon.TextAlign = HorizontalAlignment.Center;
            this._panelLearn.Controls.Add(this._tboxEpsilon);

            /** współczynnik uczenia */

            this._groupTeta = new GroupBox();
            this._groupTeta.AutoSize = true;
            this._groupTeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._groupTeta.Location = new System.Drawing.Point(0, this._epsilonRatioLabel.Location.Y +
                        this._epsilonRatioLabel.Size.Height + CONTROL_VDISTANCE_S);
            this._groupTeta.Text = "Współczynnik uczenia";
            

            //
            //_tetaRatioLabel 
            //
/*            this._tetaRatioLabel = new Label();
            this._tetaRatioLabel.AutoSize = true;
            this._tetaRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tetaRatioLabel.Name = "_tetaRatioLabel";
            //this._tetaRatioLabel.Size = new System.Drawing.Size(80, 20);
            //this._tetaRatioLabel.Location = new System.Drawing.Point(0, this._epsilonRatioLabel.Location.Y +
              //          this._epsilonRatioLabel.Size.Height + CONTROL_VDISTANCE_S);
            this._tetaRatioLabel.Location = new System.Drawing.Point(0, 0 );
            this._tetaRatioLabel.TabIndex = 0;
            this._tetaRatioLabel.Text = "Współczynnik uczenia";
            //this._groupTeta.Controls.Add(this._tetaRatioLabel);
            //this._panelLearn.Controls.Add(this._tetaRatioLabel);
            */

            
            //
            //_radioDiffTeta 
            //

            this._radioDiffTeta = new RadioButton();
            this._radioDiffTeta.Text = "Inny dla każdej warstwy (wg wzoru 1/n)";
            this._radioDiffTeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._radioDiffTeta.Name = "_radioDiffTeta";
            this._radioDiffTeta.AutoSize = true;
//            this._radioDiffTeta.Location = new System.Drawing.Point(CONTROL_HDISTANCE_B, this._tetaRatioLabel.Location.Y
//                + this._tetaRatioLabel.Size.Height + CONTROL_VDISTANCE_S);
            this._radioDiffTeta.Location = new System.Drawing.Point(CONTROL_HDISTANCE_B, CONTROL_VDISTANCE_B);
            //this._panelLearn.Controls.Add(this._radioDiffTeta);
            this._groupTeta.Controls.Add(this._radioDiffTeta);

            //
            //_radioOneTeta
            //

            this._radioOneTeta = new RadioButton();
            this._radioOneTeta.Text = "Jeden dla całej sieci";
            this._radioOneTeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._radioOneTeta.Name = "_radioOneTeta";
            this._radioOneTeta.AutoSize = true;
            this._radioOneTeta.Checked = true;
            this._radioOneTeta.Location = new System.Drawing.Point(CONTROL_HDISTANCE_B, this._radioDiffTeta.Location.Y
                + this._radioDiffTeta.Size.Height + CONTROL_VDISTANCE_S);
            this._radioOneTeta.CheckedChanged += new System.EventHandler(this._radioOneTeta_CheckedChanged);
            //this._panelLearn.Controls.Add(this._radioOneTeta);
            this._groupTeta.Controls.Add(this._radioOneTeta);

            //
            //_tboxTeta 
            //
            this._tboxTeta = new TextBox();
            this._tboxTeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxTeta.Name = "_tboxTeta";
            this._tboxTeta.Size = new System.Drawing.Size(55, 22);
            this._tboxTeta.TabIndex = 1;
            this._tboxTeta.Location = new System.Drawing.Point(CONTROL_WIDTH, this._radioOneTeta.Location.Y);
            this._tboxTeta.TextAlign = HorizontalAlignment.Center;
            //this._panelLearn.Controls.Add(this._tboxTeta);
            this._groupTeta.Controls.Add(this._tboxTeta);

            this._groupTeta.Size = new System.Drawing.Size(this._radioDiffTeta.Location.X + 
                _radioDiffTeta.Width + CONTROL_VDISTANCE_S, CONTROL_HEIGHT * 2);
            this._panelLearn.Controls.Add(this._groupTeta);

            //
            //_chboxKFold 
            //
/*            this._chboxKFold = new CheckBox();
            this._chboxKFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._chboxKFold.Text = "K fold cross validation";
            this._chboxKFold.AutoSize = true;
            this._chboxKFold.Location = new System.Drawing.Point(0, this._radioOneTeta.Location.Y +
                    this._radioOneTeta.Size.Height + CONTROL_VDISTANCE_B);
            this._chboxKFold.CheckedChanged += new System.EventHandler(this._chboxKFold_CheckedChanged);
            this._panelLearn.Controls.Add(this._chboxKFold);
 * */

            /** learnig method */
            this._groupLearnMethod = new GroupBox();
            this._groupLearnMethod.AutoSize = true;
            this._groupLearnMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._groupLearnMethod.Location = new System.Drawing.Point(_groupTeta.Location.X + _groupTeta.Size.Width + CONTROL_HDISTANCE_B, 
                this._groupTeta.Location.Y);
            this._groupLearnMethod.Text = "Early stopping";

            //
            //_radioKFold 
            //
            this._radioKFold = new RadioButton();
            this._radioKFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._radioKFold.Text = "K fold cross validation";
            this._radioKFold.AutoSize = true;
            //this._radioKFold.Location = new System.Drawing.Point(0, this._radioOneTeta.Location.Y +
            //        this._radioOneTeta.Size.Height + CONTROL_VDISTANCE_B);
            this._radioKFold.Location = new System.Drawing.Point(CONTROL_HDISTANCE_B, CONTROL_VDISTANCE_B);
            this._radioKFold.CheckedChanged += new System.EventHandler(this._chboxKFold_CheckedChanged);
            //this._panelLearn.Controls.Add(this._radioKFold);
            //this._groupLearnMethod.Controls.Add(this._radioKFold);
            
            //
            //_tboxKFold 
            //
            this._tboxKFold = new TextBox();
            this._tboxKFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxKFold.Enabled = false;
            this._tboxKFold.TextAlign = HorizontalAlignment.Center;
            this._tboxKFold.Size = new System.Drawing.Size(55, 22);
            this._tboxKFold.Text = "0";
            //this._tboxKFold.Location = new System.Drawing.Point(this._chboxKFold.Location.X + CONTROL_WIDTH, 
            //            this._chboxKFold.Location.Y);
            this._tboxKFold.Location = new System.Drawing.Point(CONTROL_WIDTH, 
                        this._radioKFold.Location.Y);
            
            //this._panelLearn.Controls.Add(this._tboxKFold);
            //this._groupLearnMethod.Controls.Add(this._tboxKFold);
            

            /** early stopping */

            //
            //_chboxEarlyStop
            //
   /*         this._chboxEarlyStop = new CheckBox();
            this._chboxEarlyStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._chboxEarlyStop.Text = "Early stopping";
            this._chboxEarlyStop.AutoSize = true;
            this._chboxEarlyStop.Checked = true;
            this._chboxEarlyStop.Location = new System.Drawing.Point(0, this._chboxKFold.Location.Y +
                    this._chboxKFold.Size.Height + CONTROL_VDISTANCE_S);
            this._chboxEarlyStop.CheckedChanged += new System.EventHandler(this._chboxEarlyStop_CheckedChanged);
            //this._panelLearn.Controls.Add(this._chboxEarlyStop);
            */
 
            //
            //_radioEarlyStop
            //
            this._radioEarlyStop = new RadioButton();
            this._radioEarlyStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._radioEarlyStop.Text = "Early stopping";
            this._radioEarlyStop.AutoSize = true;
            this._radioEarlyStop.Checked = true;
            //this._radioEarlyStop.Location = new System.Drawing.Point(0, this._chboxKFold.Location.Y +
                    //this._chboxKFold.Size.Height + CONTROL_VDISTANCE_S);
            this._radioEarlyStop.Location = new System.Drawing.Point(CONTROL_HDISTANCE_B, this._radioKFold.Location.Y +
                    this._radioKFold.Size.Height + CONTROL_VDISTANCE_S);
            this._radioEarlyStop.CheckedChanged += new System.EventHandler(this._chboxEarlyStop_CheckedChanged);
          
//            this._groupLearnMethod.Controls.Add(this._radioEarlyStop);

            //
            //_labelLearnSet
            //

            this._labelLearnSet= new Label();
            this._labelLearnSet.AutoSize = true;
            this._labelLearnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelLearnSet.Name = "_labelLearnSet";
            //this._tetaRatioLabel.Size = new System.Drawing.Size(80, 20);
            //this._labelLearnSet.Location = new System.Drawing.Point(CONTROL_VDISTANCE_S,
//                this._chboxEarlyStop.Location.Y + this._chboxEarlyStop.Size.Height + CONTROL_VDISTANCE_S);
            this._labelLearnSet.Location = new System.Drawing.Point/*(this._radioEarlyStop.Location.X + 
                CONTROL_VDISTANCE_S,
                this._radioEarlyStop.Location.Y + this._radioEarlyStop.Size.Height + CONTROL_VDISTANCE_S);*/
            (CONTROL_HDISTANCE_B, CONTROL_VDISTANCE_B);
            this._labelLearnSet.TabIndex = 0;
            this._labelLearnSet.Text = "Zbiór uczący";
            //this._panelLearn.Controls.Add(this._labelLearnSet);
            this._groupLearnMethod.Controls.Add(this._labelLearnSet);

            //
            //_tboxLearnSet 
            //
            this._tboxLearnSet = new TextBox();
            this._tboxLearnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxLearnSet.TextAlign = HorizontalAlignment.Center;
            this._tboxLearnSet.Size = new System.Drawing.Size(55, 22);
            this._tboxLearnSet.Text = "0,66";
            this._tboxLearnSet.Location = new System.Drawing.Point(CONTROL_WIDTH,
                        this._labelLearnSet.Location.Y);

            //this._panelLearn.Controls.Add(this._tboxLearnSet);
            this._groupLearnMethod.Controls.Add(this._tboxLearnSet);


            //
            //_labelValidateSet
            //

            this._labelValidateSet = new Label();
            this._labelValidateSet.AutoSize = true;
            this._labelValidateSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelValidateSet.Name = "_labelValidateSet";
            //this._tetaRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._labelValidateSet.Location = new System.Drawing.Point(
                CONTROL_HDISTANCE_B,
                this._labelLearnSet.Location.Y + this._labelLearnSet.Size.Height + CONTROL_VDISTANCE_S);
            this._labelValidateSet.TabIndex = 0;
            this._labelValidateSet.Text = "Zbiór walidujący";
            //this._panelLearn.Controls.Add(this._labelValidateSet);
            this._groupLearnMethod.Controls.Add(this._labelValidateSet);

            //
            //_tboxValidateSet 
            //
            this._tboxValidateSet = new TextBox();
            this._tboxValidateSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxValidateSet.TextAlign = HorizontalAlignment.Center;
            this._tboxValidateSet.Size = new System.Drawing.Size(55, 22);
            this._tboxValidateSet.Text = "0,16";
            this._tboxValidateSet.Location = new System.Drawing.Point(CONTROL_WIDTH,
                        this._labelValidateSet.Location.Y);

            //this._panelLearn.Controls.Add(this._tboxValidateSet);
            this._groupLearnMethod.Controls.Add(this._tboxValidateSet);


            //
            //_labelTestSet
            //

            this._labelTestSet = new Label();
            this._labelTestSet.AutoSize = true;
            this._labelTestSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelTestSet.Name = "_labelTestSet";
            //this._tetaRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._labelTestSet.Location = new System.Drawing.Point(CONTROL_HDISTANCE_B,
                this._labelValidateSet.Location.Y + this._labelValidateSet.Size.Height + CONTROL_VDISTANCE_S);
            this._labelTestSet.TabIndex = 0;
            this._labelTestSet.Text = "Zbiór testujący";
            //this._panelLearn.Controls.Add(this._labelTestSet);
            this._groupLearnMethod.Controls.Add(this._labelTestSet);

            //
            //_tboxTestSet 
            //
            this._tboxTestSet = new TextBox();
            this._tboxTestSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxTestSet.TextAlign = HorizontalAlignment.Center;
            this._tboxTestSet.Size = new System.Drawing.Size(55, 22);
            this._tboxTestSet.Text = "0,16";
            this._tboxTestSet.Location = new System.Drawing.Point(CONTROL_WIDTH,
                        this._labelTestSet.Location.Y);

            this._groupLearnMethod.Controls.Add(this._tboxTestSet);

            this._panelLearn.Controls.Add(this._groupLearnMethod);
            


            /** buttons */

            // 
            // _buttonLearn
            // 
            this._buttonLearn = new Button();
            this._buttonLearn.AutoSize = true;
            this._buttonLearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonLearn.Location = new System.Drawing.Point(0, this._groupLearnMethod.Location.Y +
                        this._groupLearnMethod.Size.Height + CONTROL_VDISTANCE_S);
            this._buttonLearn.Name = "_buttonLearn";
            //this._buttonLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonLearn.TabIndex = 0;
            this._buttonLearn.Text = "Start";
            this._buttonLearn.Click += new System.EventHandler(this._learnButton_Click);
            this._panelLearn.Controls.Add(this._buttonLearn);

            // 
            // _buttonPauseLearn
            // 
/*            this._buttonPauseLearn = new Button();
            this._buttonPauseLearn.AutoSize = true;
            this._buttonPauseLearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonPauseLearn.Location = new System.Drawing.Point(this._buttonLearn.Size.Width + CONTROL_HDISTANCE_B,
                                                                    this._buttonLearn.Location.Y);
            this._buttonPauseLearn.Name = "_buttonPauseLearn";
            //this._buttonStopLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonPauseLearn.TabIndex = 0;
            this._buttonPauseLearn.Text = "Pause";
            this._buttonPauseLearn.Click += new System.EventHandler(this._pauseLearnButton_Click);
            this._panelLearn.Controls.Add(this._buttonPauseLearn);
*/
            // 
            // _buttonContinueLearn
            // 
            this._buttonContinueLearn = new Button();
            this._buttonContinueLearn.AutoSize = true;
            this._buttonContinueLearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonContinueLearn.Location = new System.Drawing.Point(this._buttonLearn.Location.X +
                this._buttonLearn.Size.Width + CONTROL_HDISTANCE_B,
                                                                    this._buttonLearn.Location.Y);
            this._buttonContinueLearn.Name = "_buttonContinueLearn";
            //this._buttonStopLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonContinueLearn.TabIndex = 0;
            this._buttonContinueLearn.Text = "Continue";
            this._buttonContinueLearn.Click += new System.EventHandler(this._continueLearnButton_Click);
            this._panelLearn.Controls.Add(this._buttonContinueLearn);

            // 
            // _buttonStopLearn
            // 
            this._buttonStopLearn = new Button();
            this._buttonStopLearn.AutoSize = true;
            this._buttonStopLearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonStopLearn.Location = new System.Drawing.Point(this._buttonContinueLearn.Location.X + 
                this._buttonContinueLearn.Size.Width + CONTROL_HDISTANCE_B, 
                                                                    this._buttonLearn.Location.Y);
            this._buttonStopLearn.Name = "_buttonStopLearn";
            //this._buttonStopLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonStopLearn.TabIndex = 0;
            this._buttonStopLearn.Text = "Stop";
            this._buttonStopLearn.Click += new System.EventHandler(this._stopLearnButton_Click);
            this._panelLearn.Controls.Add(this._buttonStopLearn);

            //
            //_labelError
            //

            this._labelError = new Label();
            this._labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelError.Location = new System.Drawing.Point(this._buttonLearn.Location.X,
                this._buttonLearn.Location.Y + this._buttonLearn.Height + CONTROL_VDISTANCE_B);
            this._labelError.Text = "Błąd globalny";
            this._labelError.AutoSize = true;
            this._panelLearn.Controls.Add(this._labelError);

            //
            //_tboxError
            //
            this._tboxError = new TextBox();
            this._tboxError.Location = new System.Drawing.Point(this._buttonLearn.Location.X,
                this._labelError.Location.Y + this._labelError.Height + CONTROL_VDISTANCE_S);
            this._tboxError.Size = new System.Drawing.Size(this._panelLearnInputData.Width, 150);
            this._tboxError.Multiline = true;
            this._tboxError.ReadOnly = true;
            this._tboxError.ScrollBars = ScrollBars.Both;
            this._tboxError.BackColor = System.Drawing.Color.White;
            this._panelLearn.Controls.Add(this._tboxError);

            
          
        #endregion
        #region initialization_working_controls

            // 
            // _panelWork
            // 
            this._panelWork = new Panel();
            //this._panelWork.Size = new System.Drawing.Size(this._layeresPanel.Size.Width,
             //   70);
            this._panelWork.AutoSize = true;
            this._panelWork.Location = new System.Drawing.Point(this._layeresPanel.Location.X,
                this._layeresPanel.Location.Y + this._layeresPanel.Size.Height + CONTROL_VDISTANCE_B);


            //
            //_labelWorkTitle
            //

            this._labelWorkTitle = new Label();
            this._labelWorkTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelWorkTitle.Name = "_labelWorkTitle";
            this._labelWorkTitle.Size = new System.Drawing.Size(this._panelWork.Size.Width, 20);
            this._labelWorkTitle.TabIndex = 0;
            this._labelWorkTitle.Text = "OBLICZENIE";
            this._labelWorkTitle.Location = new System.Drawing.Point(0, 5);
            this._labelWorkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._panelWork.Controls.Add(this._labelWorkTitle);

            // 
            // _workDataLabel
            // 
            /*
            this._workDataLabel = new Label();
            this._workDataLabel.AutoSize = true;
            this._workDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._workDataLabel.Location = new System.Drawing.Point(690, 350);
            this._workDataLabel.Name = "_workDataLabel";
            this._workDataLabel.Size = new System.Drawing.Size(73, 20);
            this._workDataLabel.TabIndex = 0;
            this._workDataLabel.Text = "Dane do przetwarzania";
           */
            
            // 
            // _comboInputWorkData
            // 
            this._comboInputWorkData = new ComboBox();
            this._comboInputWorkData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboInputWorkData.Location = new System.Drawing.Point(840, 380);
            this._comboInputWorkData.Name = "_comboInputWorkData";
            this._comboInputWorkData.Size = new System.Drawing.Size(150, 15);
            this._comboInputWorkData.TabIndex = 0;
            this._comboInputWorkData.Sorted = true;

            //
            //_panelWorkInputData
            //
            this._panelWorkInputData = createProcessDataPanel("Dane wejściowe",
                    this._comboInputWorkData, 0, 0);
            this._panelWorkInputData.Location = new System.Drawing.Point(0, this._labelWorkTitle.Location.Y + 
                this._labelWorkTitle.Size.Height + CONTROL_VDISTANCE_B);
            // 
            // _inputWorkDataLabel
            // 
/*            this._inputWorkDataLabel.AutoSize = true;
            this._inputWorkDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._inputWorkDataLabel.Location = new System.Drawing.Point(710, 385);
            this._inputWorkDataLabel.Name = "_inputWorkDataLabel";
            this._inputWorkDataLabel.Size = new System.Drawing.Size(80, 20);
            this._inputWorkDataLabel.TabIndex = 0;
            this._inputWorkDataLabel.Text = "Dane wejœciowe:";
 */
            this._panelWork.Controls.Add(this._panelWorkInputData);
            
            // 
            // _startButton
            // 
            this._startButton = new Button();
            this._startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._startButton.Location = new System.Drawing.Point(0, 
                this._panelWorkInputData.Location.Y + this._panelWorkInputData.Size.Height);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(150, 30);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Rozpocznij obliczenie";
            this._startButton.Click += new System.EventHandler(this._startButton_Click);

            this._panelWork.Controls.Add(this._startButton);

            this.Controls.Add(this._panelWork);
        #endregion

        #region initialization_result_controls

            //
            //_panelResult
            //

            this._panelResult = new Panel();
            this._panelResult.Location = new System.Drawing.Point(this._layeresPanel.Location.X,
                this._panelWork.Location.Y + this._panelWork.Size.Height + CONTROL_VDISTANCE_B);
            this._panelResult.Size = new System.Drawing.Size(this._layeresPanel.Size.Width + 37, 400);
            //
            //_prelableResult 
            //

            this._prelabelResult = new Label();
            this._prelabelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._prelabelResult.Text = "Wyniki";
            this._prelabelResult.Location = new System.Drawing.Point(0, 0);
            this._panelResult.Controls.Add(this._prelabelResult);

            //
            //_tboxResult
            //

            _tboxResult = new TextBox();
            _tboxResult.ReadOnly = true;
            _tboxResult.BackColor = System.Drawing.Color.White;
            _tboxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            _tboxResult.Location = new System.Drawing.Point(this._prelabelResult.Location.X,
                this._prelabelResult.Location.Y + this._prelabelResult.Size.Height + CONTROL_VDISTANCE_S);

            _tboxResult.Name = "_tboxResult";
            _tboxResult.Size = new System.Drawing.Size(this._panelResult.Size.Width, 150);
            _tboxResult.Multiline = true;
            _tboxResult.WordWrap = false;
            _tboxResult.ScrollBars = ScrollBars.Both;
            
            this._panelResult.Controls.Add(_tboxResult);

            //
            //_labelResultError
            //

            this._labelResultError = new Label();
            this._labelResultError.AutoSize = true;
            this._labelResultError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelResultError.Text = "Błąd";
            this._labelResultError.Location = new System.Drawing.Point(0, this._tboxResult.Location.Y + 
                this._tboxResult.Size.Height + CONTROL_VDISTANCE_S);
            this._panelResult.Controls.Add(this._labelResultError);

            //
            //_tboxResultError
            //

            this._tboxResultError = new TextBox();
            this._tboxResultError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxResultError.Location = new System.Drawing.Point(this._labelResultError.Width + CONTROL_HDISTANCE_S, 
                this._tboxResult.Location.Y + this._tboxResult.Size.Height + CONTROL_VDISTANCE_S);
            this._tboxResultError.Size = new System.Drawing.Size(CONTROL_WIDTH - 10 , 0);
            this._panelResult.Controls.Add(this._tboxResultError);


            //
            //_labelStress
            //

            this._labelStress = new Label();
            this._labelStress.AutoSize = true;
            this._labelStress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelStress.Text = "Naprężenie";
            this._labelStress.Location = new System.Drawing.Point(0, this._tboxResultError.Location.Y +
                this._tboxResultError.Size.Height + CONTROL_VDISTANCE_S);
            this._panelResult.Controls.Add(this._labelStress);

            //
            //_tboxStress
            //

            this._tboxStress = new TextBox();
            this._tboxStress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxStress.Location = new System.Drawing.Point(this._labelStress.Width + CONTROL_HDISTANCE_S,
                this._tboxResultError.Location.Y + this._tboxResultError.Size.Height + CONTROL_VDISTANCE_S);
            this._tboxStress.Size = new System.Drawing.Size(CONTROL_WIDTH - 10, 0);
            this._panelResult.Controls.Add(this._tboxStress);



            //
            //_buttonSaveSolution
            //

            this._buttonSaveSolution = new Button();
            this._buttonSaveSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonSaveSolution.AutoSize = true;
            this._buttonSaveSolution.Text = "Zapisz rozwiązanie";
            this._buttonSaveSolution.Click += new System.EventHandler(this._buttonSaveSolution_Click);
            this._buttonSaveSolution.Enabled = false;
            this._buttonSaveSolution.Location = new System.Drawing.Point(_tboxResultError.Location.X + _tboxResultError.Size.Width + CONTROL_VDISTANCE_B,
                _tboxResultError.Location.Y);
            this._panelResult.Controls.Add(this._buttonSaveSolution);


            // 
            // _comboInputWorkData
            // 
            this._comboProperOutputData = new ComboBox();
            this._comboProperOutputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboProperOutputData.Location = new System.Drawing.Point(840, 380);
            this._comboProperOutputData.Name = "_comboInputWorkData";
            this._comboProperOutputData.Size = new System.Drawing.Size(150, 15);
            this._comboProperOutputData.TabIndex = 0;
            this._comboProperOutputData.Sorted = true;


            //
            //_panelProperOutputData
            //
            this._panelProperOutputData = createProcessDataPanel("Poprawne dane wyjściowe",
                    this._comboProperOutputData, 0, 0);
            this._panelProperOutputData.Location = new System.Drawing.Point(0, _tboxStress.Location.Y +
                2 * CONTROL_VDISTANCE_B);
            this._panelResult.Controls.Add(this._panelProperOutputData);


            //
            //_labelGood 
            //

            _labelGood = new Label();
            this._labelGood.AutoSize = true;
            this._labelGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._labelGood.Text = "Dobroć klasyfikacji";
            this._labelGood.Location = new System.Drawing.Point(0, this._panelProperOutputData.Location.Y + 
                this._panelProperOutputData.Size.Height + CONTROL_VDISTANCE_S);
            this._panelResult.Controls.Add(this._labelGood);

    
            //
            //_tboxGood;
            //

            this._tboxGood = new TextBox();
            this._tboxGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxGood.Location = new System.Drawing.Point(this._labelGood.Width + CONTROL_HDISTANCE_S,
                this._panelProperOutputData.Location.Y + this._panelProperOutputData.Size.Height + CONTROL_VDISTANCE_S);
            this._tboxGood.Size = new System.Drawing.Size(CONTROL_WIDTH - 10, 0);
            this._panelResult.Controls.Add(this._tboxGood);

            //
            //_buttonCalculateGood;
            //

            this._buttonCalculateGood = new Button();
            this._buttonCalculateGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonCalculateGood.AutoSize = true;
            this._buttonCalculateGood.Text = "Oblicz dobroć";
            this._buttonCalculateGood.Click += new System.EventHandler(this._buttonCalculateGood_Click);
            this._buttonCalculateGood.Enabled = false;
            this._buttonCalculateGood.Location = new System.Drawing.Point(_tboxGood.Location.X + _tboxGood.Size.Width + CONTROL_VDISTANCE_B,
                this._panelProperOutputData.Location.Y + this._panelProperOutputData.Size.Height + CONTROL_VDISTANCE_S);
            this._panelResult.Controls.Add(this._buttonCalculateGood);


            this.Controls.Add(_panelResult);

        #endregion
            // 
            // NetPage
            // 
            this.Controls.Add(this._labelPreNetType);
            this.Controls.Add(this._labelNetType);
            this.Controls.Add(this._layeresPanel);
            this.Controls.Add(this._panelLearn);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void initializeLayersTable()
        {
            int maxVisible = 4;
            for (int i = 0; i < perceptron.Size; ++i)
                this._layeresPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            if (perceptron.Size < maxVisible)
                this._layeresPanel.Size = new System.Drawing.Size(LAYERS_PANEL_WIDTH, 30 * (perceptron.Size + 1) + 8);
            else
            {
                this._layeresPanel.AutoScroll = true;
                this._layeresPanel.Size = new System.Drawing.Size(LAYERS_PANEL_WIDTH, 30 * (maxVisible+1) + 8);
            }

            Label label = new Label();
            label.Text = "Numer warstwy";
            label.Dock = DockStyle.Fill;
            this._layeresPanel.Controls.Add(label, CreateNetwork.NUMBER_COL, 0);

            label = new Label();
            label.Text = "Liczba neuronów";
            label.Dock = DockStyle.Fill;
            this._layeresPanel.Controls.Add(label, CreateNetwork.NEURON_COL, 0);

            label = new Label();
            label.Text = "Funkcja przejścia";
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
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Text = layer.Number.ToString();
                label.Dock = DockStyle.Fill;
                this._layeresPanel.Controls.Add(label, CreateNetwork.NUMBER_COL, i + 1);
                //druga komórka
                label = new Label();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Text = layer.Size.ToString();
                label.Dock = DockStyle.Fill;
                this._layeresPanel.Controls.Add(label, CreateNetwork.NEURON_COL, i+1);

                //trzecia komórka
                label = new Label();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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

        private void initializeDataPanels()
        {
            IEnumerator e;
            
            String[] selectedText = new String[comboBoxes.Count];
            for (int i = 0; i < comboBoxes.Count; ++i)
            {
                selectedText[i] = comboBoxes[i].Text;
                comboBoxes[i].Items.Clear();
            }

            e = data.Keys.GetEnumerator();
            while (e.MoveNext())
            {
                for (int i = 0; i < comboBoxes.Count; ++i)
                {
                    comboBoxes[i].Items.Add(e.Current);
                    
                }
            }
            if (data.Count > 0)
            {
                for (int i = 0; i < comboBoxes.Count; ++i)
                {
                    comboBoxes[i].Text = selectedText[i];
                    if (comboBoxes[i].Text.CompareTo("") == 0)
                        comboBoxes[i].SelectedIndex = 0;
                    actualizeFields(comboBoxes[i]);
                }
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

        #region setters and getters
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
                initializeDataPanels();
            }
        }


        #endregion


        private void _closeButton_Click(object sender, EventArgs e)
        {
            this.frm.removeTab();    
        }

        private void _learnButton_Click(object sender, EventArgs e)
        {
            Data.LearningParam param = new Data.LearningParam();
            String inputName = this._comboInputLearnData.Text,
                    outputName;

            outputName = this._comboOutputLearnData.Text;

            this._tboxError.Text = "";
            try
            {
                if (((List<double[]>)data[inputName])[0].Length != perceptron.getLayer(0).Size)
                    throw new Exception("Wrong input data size");
                if (((List<double[]>)data[outputName])[0].Length != perceptron.getLayer(perceptron.Size-1).Size)
                    throw new Exception("Wrong output data size");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
                return;
            }
            
            try
            {
                //check if size of input and output data is proper
                

                param.Input = (List<double[]>)data[inputName];
                param.Output = (List<double[]>)data[outputName];
                param.Alpha = Double.Parse(this._tboxAlpha.Text);
                param.Epsilon = Double.Parse(this._tboxEpsilon.Text);
                if (this._radioDiffTeta.Checked == true)
                    param.OneTeta = false;
                else
                    param.OneTeta = true;
                param.Teta = Double.Parse(this._tboxTeta.Text);
                if (this._radioEarlyStop.Checked == true)
                {
                    param.EarlyStop = true;
                    param.LearnSet = double.Parse(this._tboxLearnSet.Text);
                    param.ValidateSet = double.Parse(this._tboxValidateSet.Text);
                    param.TestSet = double.Parse(this._tboxTestSet.Text);
                }
                else
                {
                    param.EarlyStop = true;
                    param.KFoldSamples = int.Parse(this._tboxKFold.Text);
                }
                
                backprop.Param = param;
                backprop.TBoxError = this._tboxError;
                backprop.StartButton= this._buttonLearn;
                backprop.ContinueButton = this._buttonContinueLearn;
                backprop.StopButton = this._buttonStopLearn;

                backprop.StartLearn();
             }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                MessageBox.Show("Some learning problem has occured", "Warning");
            }


        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            String inputName = this._comboInputWorkData.Text;
            processData = new MDS.Data.ProcessData();
            //check if size of input data is proper for the network
            try
            {
                if (((List<double[]>)data[inputName])[0].Length != perceptron.getLayer(0).Size)
                    throw new Exception("Wrong data size");

                processData.Input = (List<double[]>)data[inputName];
                perceptron.Process(processData);
                if (perceptron.Type == Data.NetworkParam.MDS)
                {
                    _tboxResultError.Text = "" + perceptron.Error;
                    _tboxStress.Text = "" + perceptron.Stress;
                }
                currentOutput = processData.Solution;
                
                printResults();
                _buttonSaveSolution.Enabled = true;
                _buttonCalculateGood.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning" );
                Console.Out.WriteLine(ex.Message);
            }
        }

        private void printResults()
        {
            int oneSize, size;

            size = processData.Output.Count;
/*            if (perceptron.Type == Data.NetworkParam.MDS)
            {*/
                oneSize = 8;
                size *= 8;
           /* }
            else
            {
                size *= 6;
                oneSize = 6;
            }*/

            String[] lines = new string[size];

            for (int i = 0; i < processData.Output.Count; ++i)
            {
                lines[i * oneSize] = "Wektor nr. " + (i + 1);
                lines[i * oneSize + 1] = "  WEJŚCIE:";
                lines[i * oneSize + 2] = Data.ProcessData.GetStringList(processData.Input[i], false);
                lines[i * oneSize + 3] = "  WYJŚCIE:";
                lines[i * oneSize + 4] = Data.ProcessData.GetStringList(processData.Output[i], false);
                if (perceptron.Type == Data.NetworkParam.MDS)
                {
                    lines[i * oneSize + 5] = "  ROZWIĄZANIE:";
                    lines[i * oneSize + 6] = Data.ProcessData.GetStringList(processData.Solution[i], false);
                    lines[i * oneSize + 7] = "______________________________________________________";
                }
                else
                {
                    lines[i * oneSize + 5] = "  KLASA nr " + Perceptron.GetClassNumber( processData.Solution[i]);

                    lines[i * oneSize + 6] = "______________________________________________________";
                }
                this._tboxResult.Lines = lines;
            }
        }

/*        private void _tboxVectorNr_TextChanged(object sender, EventArgs e)
        {
           try
            {
                int nr = int.Parse(_tboxVectorNr.Text);
                this._inVector.Text = Data.ProcessData.GetStringList(processData.Input[nr-1]);
                this._solutionVector.Text = Data.ProcessData.GetStringList(processData.Solution[nr-1]);
                this._outVector.Text = Data.ProcessData.GetStringList(processData.Output[nr-1]);
            }
            catch (Exception) { }
  
        }*/
        private void _stopLearnButton_Click(object sender, EventArgs e)
        {
            backprop.StopLearn();
        }

        private void _pauseLearnButton_Click(object sender, EventArgs e)
        {
            backprop.StopLearn();
        }

        private void _continueLearnButton_Click(object sender, EventArgs e)
        {
            backprop.ContinueLearn();
        }

        private void _chboxKFold_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            //if(radio.Checked )
            this._tboxKFold.Enabled = true;

            this._tboxLearnSet.Enabled = false;
            this._tboxValidateSet.Enabled = false;
            this._tboxTestSet.Enabled = false;
        }

        private void _chboxEarlyStop_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            this._tboxLearnSet.Enabled = true;
            this._tboxValidateSet.Enabled = true;
            this._tboxTestSet.Enabled = true;

            this._tboxKFold.Enabled = false;
        }

        private void _radioOneTeta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked == true)
                this._tboxTeta.Enabled = true;
            else
                this._tboxTeta.Enabled = false;
        }

        private void actualizeFields( ComboBox combo )
        {
            Panel panel = (Panel)combo.Parent;
            String name = combo.Text;
            Control control;

            int dataSize = ((List<double[]>)data[name]).Count;
            int vectorSize = ((List<double[]>)data[name])[0].Length;

            IEnumerator en = panel.Controls.GetEnumerator();
            while (en.MoveNext())
            {
                control = (Control)en.Current;
                if (control.Name.CompareTo("_dataSize") == 0)
                    control.Text = "" + dataSize;
                if (control.Name.CompareTo("_vectorSize") == 0)
                    control.Text = "" + vectorSize;
            }
        }

        private void _comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            actualizeFields(combo);
           
        }
        private void _buttonDataDetails_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Panel panel = (Panel)button.Parent;
            
            String name = "",
                    dialogName = "";

            List<double[]> actData;
            IEnumerator ie = panel.Controls.GetEnumerator();
            while (ie.MoveNext())
            {
                System.Console.Out.WriteLine(ie.Current.GetType());
                if (ie.Current.GetType().IsInstanceOfType(new ComboBox()))
                    name = ((ComboBox)ie.Current).Text;
                if (ie.Current.GetType().IsInstanceOfType(new Label()))
                    dialogName = ((Label)ie.Current).Text;

            }
            if (name.CompareTo("") == 0)
                return;
            actData = (List<double[]>)data[name];
            DataDetails dialog = new DataDetails( actData, name, dialogName );
            dialog.Show();
        }

        private void _buttonSaveSolution_Click(object sender, EventArgs e)
        {
            String fileName = this._comboInputWorkData.Text + "_out";
            new MainANN(true).WriteData(fileName , currentOutput);
            MessageBox.Show("Rozwiązanie zostało zapisane w pliku " + fileName, "Info");
        }

        private void _buttonCalculateGood_Click(object sender, EventArgs e)
        {
            /*Oblicz dobroć klasyfikacji*/
            try
            {

                String dataName = _comboProperOutputData.Text;
                List<double[]> correctData = (List<double[]>)data[dataName];
                List<double[]> currData = processData.Solution;

                if (correctData.Count != currData.Count ||
                    correctData[0].Length != currData[0].Length)
                    throw new Exception("Rozmiar danych się nie zgadza."); 

                double[] correctVector, currVector;
                double maxsize = processData.Solution.Count;
                double correct = 0.0;
                int j;

                double result;
                for (int i = 0; i < maxsize; ++i)
                {
                    currVector = currData[i];
                    correctVector = correctData[i];
                    j = 0;
                    while ( j < correctVector.Length && correctVector[j] == currVector[j] )
                        j++;
                    if (j == correctVector.Length)
                        correct++;
                }

                result = correct / maxsize * 100;
                _tboxGood.Text = " " + result + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uwaga");
            }
        }
    }
}
;