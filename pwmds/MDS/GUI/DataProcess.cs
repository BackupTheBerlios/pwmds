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
        public static int MODIFY = 0,
                        SELECT_VECTORS = 1,
                        SELECT_COLUMNS = 2;
        private Hashtable inputData;
        private String selectedDataName;
        private String newDataName;
        private String dataFileName;
        private int option;
        private bool[] options;

        private int startVectorNr,
                    endVectorNr;
        private int startColumnNr,
                    endColumnNr;

        private int startVal, endVal;

        private List<int> vectorsNo;

        private List<int> columnsNo;

        public DataProcess()
        {
            InitializeComponent();
            options = new bool[3];
            
        }

        #region controls processing
        private void initializeCombo()
        {
            IEnumerator ie = inputData.Keys.GetEnumerator();
            while (ie.MoveNext())
                this._comboSelectData.Items.Add(ie.Current);
            if (this._comboSelectData.Items.Count > 0)
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

        public bool[] Options
        {
            get { return options; }
        }

        public int StartVectorNr
        {
            get { return startVectorNr; }
        }

        public int EndVectorNr
        {
            get { return endVectorNr; }
        }

        public int StartColumnNr
        {
            get { return startColumnNr; }
        }

        public int EndColumnNr
        {
            get { return endColumnNr; }
        }

        public int StartValue
        {
            get { return startVal; }
        }

        public int EndValue
        {
            get { return endVal; }
        }

        public List<int> VectorsNo
        {
            get { return vectorsNo; }
        }

        public List<int> ColumnsNo
        {
            get { return columnsNo; }
        }
        #endregion

        private void _buttonOk_Click(object sender, EventArgs e)
        {
            this.selectedDataName = this._comboSelectData.Text;
            this.dataFileName = this._tboxFileName.Text;
            this.newDataName = this._tboxDataName.Text;
            try
            {
                if (this._cboxModify.Checked == true)
                {
                    options[MODIFY] = true;
                    if (_radioStandarization.Checked == true)
                        option = Data.DataPreprocessor.STANDARIZE;
                    else
                    {
                        option = Data.DataPreprocessor.SCALING;
                        startVal = int.Parse(this._tboxStartVal.Text);
                        endVal = int.Parse(this._tboxEndVal.Text);
                    }
                }
                if( this._cboxSelectColumns.Checked == true )
                {
                    options[SELECT_COLUMNS] = true;
                    getColumnsNo(_tboxStartColumn.Text);
                    //startColumnNr = int.Parse(this._tboxStartColumn.Text);
                    //endColumnNr = int.Parse(this._tboxEndColumn.Text);
                }
                if (this._cboxSelectVectors.Checked == true)
                {
                    options[SELECT_VECTORS] = true;
                    //
                    getVectorsNo(_tboxStartVector.Text);
                    //startVectorNr = int.Parse(this._tboxStartVector.Text);
                    //endVectorNr = int.Parse(this._tboxEndVector.Text);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

        }

        private void getVectorsNo( String text )
        {
            String[] parts;
            String[] numbers;
            vectorsNo = new List<int>();
            int val1, val2;

            parts = text.Split( new char[]{','});
            foreach (String elem in parts)
            {
                numbers = elem.Split(new char[] { '-' });
                
                if (!int.TryParse(numbers[0], out val1))
                        continue;
                if (numbers.Length == 1)
                {    
                    vectorsNo.Add(val1);
                    continue;
                }
                if( !int.TryParse( numbers[1], out val2))
                    continue;
                for (int i = val1; i <= val2; ++i)
                    vectorsNo.Add(i);
            }
        }

        private void getColumnsNo(String text)
        {
            String[] parts;
            String[] numbers;
            columnsNo = new List<int>();
            int val1, val2;

            parts = text.Split(new char[] { ',' });
            foreach (String elem in parts)
            {
                numbers = elem.Split(new char[] { '-' });

                if (!int.TryParse(numbers[0], out val1))
                    continue;
                if (numbers.Length == 1)
                {
                    columnsNo.Add(val1);
                    continue;
                }
                if (!int.TryParse(numbers[1], out val2))
                    continue;
                for (int i = val1; i <= val2; ++i)
                    columnsNo.Add(i);
            }
        }
    }
}