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
                            UP_MARGIN = 20, DOWN_MARGIN = 20,
                            PANEL_DISTANCE = 50,
                            CONTROL_VDISTANCE_S = 5, CONTROL_HDISTANCE_S = 5,
                            CONTROL_VDISTANCE_B = 20, CONTROL_HDISTANCE_B = 20,
                            CONTROL_HEIGHT = 40, CONTROL_WIDTH = 180,
                            LAYERS_PANEL_WIDTH = 400;
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

        private Label _labelGlobalError;

        private Label _alphaRatioLabel;
        private Label _epsilonRatioLabel;
        private Label _tetaRatioLabel;
        private TextBox _tboxAlpha;
        private TextBox _tboxEpsilon;
        private TextBox _tboxTeta;

        private CheckBox _chboxKFold;
        private TextBox _tboxKFold;

        private Button _buttonLearn;
        private Button _buttonStopLearn;
    #endregion

    #region declaration_working_controls
        //private Label _workDataLabel;
        //private Label _inputWorkDataLabel;
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

        public NetPage( int nr, Hashtable inputData, Perceptron perceptron)
        {
            this.nr = nr;
            this.data = inputData;
            this.perceptron = perceptron;
            comboBoxes = new List<ComboBox>();
            InitializeComponent();
            
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

            //"Rozmiar danych"
            Label prelabelDataSize = new Label();
            prelabelDataSize.Text = "Rozmiar danych";
            prelabelDataSize.AutoSize = true;
            prelabelDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            prelabelDataSize.Location = new System.Drawing.Point(comboData.Location.X + comboData.Size.Width +
                CONTROL_HDISTANCE_B, LABEL_Y);
            prelabelDataSize.TabIndex = 0;
            panel.Controls.Add(prelabelDataSize);

            //rozmiar danych
            Label labelDataSize = new Label();
            labelDataSize.Name = "_dataSize";
            labelDataSize.Text = "" + dataSize;
            labelDataSize.AutoSize = true;
            labelDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelDataSize.Location = new System.Drawing.Point(prelabelDataSize.Location.X +
                prelabelDataSize.Size.Width + CONTROL_HDISTANCE_S, LABEL_Y);
            labelDataSize.TabIndex = 0;
            //labelDataSize.BackColor = System.Drawing.Color.White;
            panel.Controls.Add(labelDataSize);

            //"Rozmiar wektora"
            Label prelabelVectorSize = new Label();
            prelabelVectorSize.Text = "Rozmiar wektora";
            prelabelVectorSize.AutoSize = true;
            prelabelVectorSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            prelabelVectorSize.Location = new System.Drawing.Point(labelDataSize.Location.X + labelDataSize.Size.Width +
                CONTROL_HDISTANCE_B, LABEL_Y);
            prelabelVectorSize.TabIndex = 0;
            panel.Controls.Add(prelabelVectorSize);

            //rozmiar wektora
            Label labelVectorSize = new Label();
            labelVectorSize.Name = "_vectorSize";
            labelVectorSize.Text = "" + vectorSize;
            labelVectorSize.AutoSize = true;
            labelVectorSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            labelVectorSize.Location = new System.Drawing.Point(prelabelVectorSize.Location.X +
                prelabelVectorSize.Size.Width + CONTROL_HDISTANCE_S, LABEL_Y);
            labelVectorSize.TabIndex = 0;
            //labelDataSize.BackColor = System.Drawing.Color.White;
            panel.Controls.Add(labelVectorSize);

            width = labelVectorSize.Location.X + labelVectorSize.Size.Width;
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
            this._panelLearn.Location = new System.Drawing.Point(LEFT_MARGIN + LAYERS_PANEL_WIDTH+ PANEL_DISTANCE, UP_MARGIN);
            //this._panelLearn.BorderStyle = BorderStyle.FixedSingle;
            this._panelLearn.Size = new System.Drawing.Size(750, 300);

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
            this._panelLearnInputData = createProcessDataPanel("Dane wejœciowe", this._comboInputLearnData, 0, 0);
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
            this._panelLearnOutputData = createProcessDataPanel("Dane wyjœciowe", this._comboOutputLearnData, 0, 0);
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
                this._panelLearnOutputData.Size.Height + CONTROL_VDISTANCE_B );
            this._alphaRatioLabel.TabIndex = 0;
            this._alphaRatioLabel.Text = "Wspó³czynnik momentu";

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
            this._epsilonRatioLabel.Text = "Dok³adnoœæ";
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
            //
            //_tetaRatioLabel 
            //
            this._tetaRatioLabel = new Label();
            this._tetaRatioLabel.AutoSize = true;
            this._tetaRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tetaRatioLabel.Name = "_tetaRatioLabel";
            //this._tetaRatioLabel.Size = new System.Drawing.Size(80, 20);
            this._tetaRatioLabel.Location = new System.Drawing.Point(0, this._epsilonRatioLabel.Location.Y +
                        this._epsilonRatioLabel.Size.Height + CONTROL_VDISTANCE_S);
            this._tetaRatioLabel.TabIndex = 0;
            this._tetaRatioLabel.Text = "Wspó³czynnik uczenia";
            this._panelLearn.Controls.Add(this._tetaRatioLabel);

            //
            //_tboxTeta 
            //
            this._tboxTeta = new TextBox();
            this._tboxTeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._tboxTeta.Name = "_tboxTeta";
            this._tboxTeta.Size = new System.Drawing.Size(55, 22);
            this._tboxTeta.TabIndex = 1;
            this._tboxTeta.Location = new System.Drawing.Point(CONTROL_WIDTH, this._tetaRatioLabel.Location.Y);
            this._tboxTeta.TextAlign = HorizontalAlignment.Center;
            this._panelLearn.Controls.Add(this._tboxTeta);

            //
            //_tboxGlobalError
            //
/*            this._labelGlobalError = new Label();
            this._labelGlobalError.Location = new System.Drawing.Point(this._tboxAlpha.Location.X +
                this._tboxAlpha.Width + CONTROL_HDISTANCE_B, this._tboxAlpha.Location.Y);
            this._labelGlobalError.Size = new System.Drawing.Size(100, 350);
            this._panelLearn.Controls.Add(this._labelGlobalError);

  */
            //
            //_chboxKFold 
            //
            this._chboxKFold = new CheckBox();
            this._chboxKFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._chboxKFold.Text = "K fold cross validation";
            this._chboxKFold.AutoSize = true;
            this._chboxKFold.Location = new System.Drawing.Point(0, this._tetaRatioLabel.Location.Y + 
                    this._tetaRatioLabel.Size.Height + CONTROL_VDISTANCE_B);
            this._chboxKFold.CheckedChanged += new System.EventHandler(this._chboxKFold_CheckedChanged);
            this._panelLearn.Controls.Add(this._chboxKFold);

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
            this._tboxKFold.Location = new System.Drawing.Point(this._chboxKFold.Location.X + CONTROL_WIDTH, 
                        this._chboxKFold.Location.Y);
            
            this._panelLearn.Controls.Add(this._tboxKFold);

            // 
            // _buttonLearn
            // 
            this._buttonLearn = new Button();
            this._buttonLearn.AutoSize = true;
            this._buttonLearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonLearn.Location = new System.Drawing.Point(0, this._chboxKFold.Location.Y + 
                        this._chboxKFold.Size.Height + CONTROL_VDISTANCE_B);
            this._buttonLearn.Name = "_buttonLearn";
            //this._buttonLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonLearn.TabIndex = 0;
            this._buttonLearn.Text = "Start";
            this._buttonLearn.Click += new System.EventHandler(this._learnButton_Click);
            this._panelLearn.Controls.Add(this._buttonLearn);

            // 
            // _buttonStopLearn
            // 
            this._buttonStopLearn = new Button();
            this._buttonStopLearn.AutoSize = true;
            this._buttonStopLearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._buttonStopLearn.Location = new System.Drawing.Point(this._buttonLearn.Size.Width + CONTROL_HDISTANCE_B, 
                                                                    this._buttonLearn.Location.Y);
            this._buttonStopLearn.Name = "_buttonStopLearn";
            //this._buttonStopLearn.Size = new System.Drawing.Size(150, 30);
            this._buttonStopLearn.TabIndex = 0;
            this._buttonStopLearn.Text = "Stop";
            this._buttonStopLearn.Click += new System.EventHandler(this._stopLearnButton_Click);
            this._panelLearn.Controls.Add(this._buttonStopLearn);


            
          
        #endregion
        #region initialization_working_controls
            // 
            // _workDataLabel
            // 
            this._workDataLabel = new Label();
            this._workDataLabel.AutoSize = true;
            this._workDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._workDataLabel.Location = new System.Drawing.Point(690, 350);
            this._workDataLabel.Name = "_workDataLabel";
            this._workDataLabel.Size = new System.Drawing.Size(73, 20);
            this._workDataLabel.TabIndex = 0;
            this._workDataLabel.Text = "Dane do przetwarzania";
           
            // 
            // _panelWork
            // 
            this._panelWork = new Panel();
            this._panelWork.Size = new System.Drawing.Size( this._panelLearn.Size.Width,
                300 );
            this._panelWork.Location = new System.Drawing.Point( this._panelLearn.Location.X,
                this._panelLearn.Location.Y + this._panelLearn.Size.Height + PANEL_DISTANCE);
            // 
            // _comboInputWorkData
            // 
            this._comboInputWorkData = new ComboBox();
            this._comboInputWorkData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._comboInputWorkData.Location = new System.Drawing.Point(840, 380);
            this._comboInputWorkData.Name = "_comboInputWorkData";
            this._comboInputWorkData.Size = new System.Drawing.Size(150, 15);
            this._comboInputWorkData.TabIndex = 0;

            //
            //_panelWorkInputData
            //
            this._panelWorkInputData = createProcessDataPanel("Dane wejœciowe",
                    this._comboInputWorkData, 0, 0);
            this._panelWorkInputData.Location = new System.Drawing.Point( 0, 0);
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
            this._startButton.Text = "Rozpocznij przetwarzanie";
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
                this._layeresPanel.Location.Y + this._layeresPanel.Size.Height + PANEL_DISTANCE);
            this._panelResult.Size = new System.Drawing.Size(this._layeresPanel.Size.Width, 300);
            //
            //_prelableResult 
            //

            this._prelabelResult = new Label();
            this._prelabelResult.Text = "WYNIKI";
            this._prelabelResult.Location = new System.Drawing.Point(0, 0);
            this._panelResult.Controls.Add(this._prelabelResult);

            //
            //_labelResult 
            //

/*            this._labelResult = new Label();
            this._labelResult.AutoScrollOffset = new System.Drawing.Point(10, 10);
            this._labelResult.Size = new System.Drawing.Size(this._layeresPanel.Size.Width,
                100);
            this._labelResult.BorderStyle = BorderStyle.FixedSingle;
            this._labelResult.BackColor = System.Drawing.Color.White;
            this._labelResult.Location = new System.Drawing.Point(this._prelabelResult.Location.X,
                this._prelabelResult.Location.Y + this._prelabelResult.Size.Height + CONTROL_VDISTANCE_S);
            this._panelResult.Controls.Add(this._labelResult);
            */
            _tboxResult = new TextBox();
            //_tboxResult.Enabled = false;
            _tboxResult.BackColor = System.Drawing.Color.White;
            _tboxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            _tboxResult.Location = new System.Drawing.Point(this._prelabelResult.Location.X,
                this._prelabelResult.Location.Y + this._prelabelResult.Size.Height + CONTROL_VDISTANCE_S);

            _tboxResult.Name = "_tboxResult";
            _tboxResult.Size = new System.Drawing.Size(this._panelResult.Size.Width, 250);
            _tboxResult.Multiline = true;
            _tboxResult.WordWrap = false;
            _tboxResult.ScrollBars = ScrollBars.Both;
            
            this._panelResult.Controls.Add(_tboxResult);
            this.Controls.Add(_panelResult);

        #endregion
            // 
            // NetPage
            // 
            //this.AccessibleName = "hgfds";
            this.Controls.Add(this._labelPreNetType);
            this.Controls.Add(this._labelNetType);
            this.Controls.Add(this._layeresPanel);
            this.Controls.Add(this._panelLearn);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void initializeLayersTable()
        {
            for (int i = 0; i < perceptron.Size; ++i)
                this._layeresPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._layeresPanel.Size = new System.Drawing.Size(LAYERS_PANEL_WIDTH, 30 * (perceptron.Size + 1) + 8);

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
            ComboBox combo;
            for (int i = 0; i < comboBoxes.Count; ++i)
                comboBoxes[i].Items.Clear();

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
                    comboBoxes[i].SelectedIndex = comboBoxes.Count - 1;
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
                initializeDataPanels();
            }
        }


        private void _learnButton_Click(object sender, EventArgs e)
        {
            Data.LearningParam param = new Data.LearningParam();
            String inputName = this._comboInputLearnData.Text,
                    outputName;
            //if( perceptron.Type == Data.NetworkParam.CLASSIFIER)
                outputName = this._comboOutputLearnData.Text;
            //else
              //  outputName = inputName;
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
                param.KFoldSamples = int.Parse(this._tboxKFold.Text);
                //backprop = new Network.Backpropagation(perceptron, param);
                backprop.Param = param;
                //backprop.TBoxError = this._tboxGlobalError;

                backprop.StartLearn();
                //backprop.Start();
                //while (backprop.NextIteration())
                //{
                  //  this._labelGlobalError.Text = this._labelGlobalError.Text +"\n" + backprop.GlobalError;
                //}
             }
            catch(Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
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
            int oneSize,
                size = processData.Output.Count;
            if (perceptron.Type == Data.NetworkParam.MDS)
            {
                oneSize = 8;
                size *= 8;
            }
            else
            {
                size *= 6;
                oneSize = 6;
            }
            //if()

            try
            {
                //int nr = 1;

                //this._tboxVectorNr.Text = "1";
                //this._inVector.Text = Data.ProcessData.GetStringList( processData.Input[nr-1]);
                //this._solutionVector.Text = Data.ProcessData.GetStringList(processData.Solution[nr-1]);
                //this._outVector.Text = Data.ProcessData.GetStringList(processData.Output[nr-1]);
                String[] lines = new string[size];

                for (int i = 0; i < processData.Output.Count; ++i)
                {
                    lines[i*oneSize] = "Wektor nr. " + (i+1);
                    lines[i * oneSize + 1] = "  WEJŒCIE:";
                    lines[i * oneSize + 2] = Data.ProcessData.GetStringList(processData.Input[i]);
                    lines[i * oneSize + 3] = "  WYJŒCIE:";
                    lines[i * oneSize + 4] = Data.ProcessData.GetStringList(processData.Output[i]);
                    if (perceptron.Type == Data.NetworkParam.MDS)
                    {
                        lines[i * oneSize + 5] = "  ROZWI¥ZANIE:";
                        lines[i * oneSize + 6] = Data.ProcessData.GetStringList(processData.Solution[i]);
                        lines[i * oneSize + 7] = "______________________________________________________";
                    }
                    else
                        lines[i * oneSize + 5] = "______________________________________________________";
                    this._tboxResult.Lines = lines;
                }
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
        private void _stopLearnButton_Click(object sender, EventArgs e)
        {
            backprop.StopLearn();
        }

        private void _chboxKFold_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chbox = (CheckBox)sender;
            if( chbox.Checked == true )
                this._tboxKFold.Enabled = true;
            else
                this._tboxKFold.Enabled = false;
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
    }
}
;