using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MDS.GUI
{
    public partial class frmMain : Form
    {
        private MainANN mainANN; // glowna klasa "Engine" aplikacji.

        public frmMain()
        {
            InitializeComponent();
            mainANN = new MainANN(this);
        }
      
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        // wczytuje z pliku dane do skalowania
        private void wczytajDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            String filePath = null;

            try
            {
            // pobiera nazwe pliku z danymi     
                openFileDialog.Filter = "data files (*.data)|*.data|All files (*.*)|*.*";
                openFileDialog.Title = "Wybierz plik z danymi do przeskalowania.";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;

            // wywolanie fun. wczytujacej dane z pliku 
                this.statusStrip1.Text = "Wczytuje dane...";
                Cursor.Current = Cursors.WaitCursor;
                this.mainANN.loadInputData(filePath);
                this.statusStrip1.Text = "Bezczynny";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.errorHandler(ex);
            }
        }
        
        // funkcja obslugi bledu
        private void errorHandler(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _mNewNetwork_Click(object sender, EventArgs e)
        {
            CreateNetwork createDialog = new CreateNetwork();
            createDialog.ShowDialog();
            if (createDialog.DialogResult == DialogResult.OK)
            {
                Data.NetworkParam param = new Data.NetworkParam();
                //get netowrikParam
                //createNetowork
                //add Network to list
                
            }
            createDialog.Dispose();
        }

    }
}