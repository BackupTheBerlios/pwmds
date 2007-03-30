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
                this.statusStrip1.Items[0].Text = "Wczytuje dane...";
                this.statusStrip1.Refresh();
                Cursor.Current = Cursors.WaitCursor;
                this.mainANN.loadInputData(filePath);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Istniej� ju� dane wczytane z wybranego pliku.\n W celu wczytania tego samego pliku, nale�y zmieni� nazw� wcze�niej wczytanych danych. ", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
            }
        }
        
        private void _mNewNetwork_Click(object sender, EventArgs e)
        {
            ////CreateNetwork createDialog = new CreateNetwork();
            ////createDialog.ShowDialog();
            //if (createDialog.DialogResult == DialogResult.OK)
            //{
            //    Data.NetworkParam param = new Data.NetworkParam();
            //    //get netowrikParam
            //    //createNetowork
            //    //add Network to list
                
            //}
            //createDialog.Dispose();
        }

    }
}