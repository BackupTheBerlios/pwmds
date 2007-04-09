using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDS.GUI
{
    public partial class ReadData : Form
    {
        private String dataName;
        private String fileName;
        public ReadData()
        {
            InitializeComponent();
        }


        public String DataName
        {
            get { return dataName; }
        }

        public String FileName
        {
            get { return fileName; }
        }

        private void _openFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = openDlg.FileName;
                this._tboxFilePath.Text = getFileName();
            }
        }

        private String getFileName()
        {
            String[] list = fileName.Split(new char[] { '\\' });
            return list[list.Length-1];
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            dataName = this._tboxDataName.Text;
        }
    }
}