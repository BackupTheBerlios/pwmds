using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDS.GUI
{
    public partial class DataProcess : Form
    {
        //public static int STANDARIZATION = 280,
        //                SCALING = 281,
         //               CUTTING = 282;

        private Hashtable inputData;
        private String selectedDataName;
        private String newDataName;
        private String dataFileName;
        private int option;

        private int startVectorNr,
                    endVectorNr;

        private int startVal, endVal;


        public DataProcess()
        {
            InitializeComponent();
            
        }

        #region controls processing
        private void initializeCombo()
        {
            IEnumerator ie = inputData.Keys.GetEnumerator();
            while (ie.MoveNext())
                this._comboSelectData.Items.Add(ie.Current);
            this._comboSelectData.SelectedIndex = 0;
        }

        #endregion

        #region getters and setters
        public Hashtable InputData
        {
            get { return inputData; }
            set 
            {
                inputData = value;
                initializeCombo();
            }
        }

        public String SelectedDataName
        {
            get { return selectedDataName; }
        }

        public String DataFileName
        {
            get { return dataFileName; }
        }

        public String NewDataName
        {
            get { return newDataName; }
        }


        public int Option
        {
            get { return option; }
        }

        public int StartVectorNr
        {
            get { return startVectorNr; }
        }

        public int EndVectorNr
        {
            get { return endVectorNr; }
        }

        public int StartValue
        {
            get { return startVal; }
        }

        public int EndValue
        {
            get { return endVal; }
        }
        #endregion

        private void _buttonOk_Click(object sender, EventArgs e)
        {
            this.selectedDataName = this._comboSelectData.Text;
            this.dataFileName = this._tboxFileName.Text;
            this.newDataName = this._tboxDataName.Text;
            try
            {
                if (_radioStandarization.Checked == true)
                    option = Data.DataPreprocessor.STANDARIZE;
                else if (_radioScaling.Checked == true)
                {
                    option = Data.DataPreprocessor.SCALING;
                    startVal = int.Parse(this._tboxStartVal.Text);
                    endVal = int.Parse(this._tboxEndVal.Text);
                }
                else
                {
                    option = Data.DataPreprocessor.CUTTING;
                    startVectorNr = int.Parse(this._tboxStartNr.Text);
                    endVectorNr = int.Parse(this._tboxEndNr.Text);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

        }
    }
}