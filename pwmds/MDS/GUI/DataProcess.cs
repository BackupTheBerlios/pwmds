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
        private Hashtable data;

        public DataProcess()
        {
            InitializeComponent();
            
        }

        #region controls processing
        private void initializeCombo()
        {
            IEnumerator ie = data.Keys.GetEnumerator();
            while (ie.MoveNext())
                this._comboSelectData.Items.Add(ie.Current);
            this._comboSelectData.SelectedIndex = 0;
        }

        #endregion

        #region getters and setters
        public Hashtable Data
        {
            get { return data; }
            set 
            { 
                data = value;
                initializeCombo();
            }
        }
        #endregion
    }
}