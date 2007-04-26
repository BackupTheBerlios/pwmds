using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDS.GUI
{
    public partial class DataDetails : Form
    {
        private List<double[]> data;
        private String dataName;

        public DataDetails()
        {
            InitializeComponent();
        }

        public DataDetails( List<double[]> ndata, String name, String dialogName)
        {
            InitializeComponent();
            this.Text = dialogName;
            data = ndata;
            dataName = name;

            this._tboxDataName.Text = dataName;
            this._tboxDataSize.Text = "" + data.Count;
            this._tboxVectorSize.Text = "" + data[0].Length;
            writeData();
        }

        private void writeData()
        {
            String []lines = new String[data.Count*2];
            for (int i = 0; i < data.Count; ++i)
            {
                lines[2 * i] = Data.ProcessData.GetStringList(data[i]);
                lines[2 * i + 1] = "------------------------------------";
            }
            this._tboxData.Lines = lines;
        }

        #region getter and setters

        public List<double[]> DataD
        {
            set { data = value; }
        }

        public String Name
        {
            set { dataName = value; }
        }

        #endregion

        private void _buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}