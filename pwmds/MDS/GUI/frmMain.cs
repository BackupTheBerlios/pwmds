using System;
using System.Collections.Generic;
using System.Collections;
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
            mainANN = new MainANN();
            createFirstTabPage();
            createSecondTabPage();

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
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            String filePath = null;
            int i;

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
                i = this.mainANN.loadInputData(filePath);
                if (i>0)
                    MessageBox.Show(null, "Wczytano " + i + " rekord�w. ", "Dane wczytano", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
             */
        }

        private void _mReadData_Click(object sender, EventArgs e)
        {
            ReadData readDialog = new ReadData();
            if (readDialog.ShowDialog() == DialogResult.OK)
            {
                mainANN.loadInputData(readDialog.DataName, readDialog.FileName);
            }
            readDialog.Dispose();
            setPagesNewInputData(mainANN.InputData);
        }
        
        private void _mNewNetwork_Click(object sender, EventArgs e)
        {
            CreateNetwork createDialog = new CreateNetwork();
            createDialog.ShowDialog();
            if (createDialog.DialogResult == DialogResult.OK)
            {
                Data.NetworkParam param = new Data.NetworkParam();
                param.Type = createDialog.NetworkType;
                param.Neurons = createDialog.NeuronsInLayer;
                param.LayerNumber = createDialog.LayersNumber;
                param.Functions = createDialog.Functions;
                param.SolutionLayerNr = createDialog.SolutionLayerNr;

            //    //get netowrikParam
            //    //createNetowork
            //    //add Network to list
                try
                {
                    int nr = mainANN.AddNetwork(param);
                    NetPage page = new NetPage( nr, mainANN.InputData, mainANN.GetNetwork(nr) );
                    page.NetworkName = createDialog.NetworkName;
                    this._tabControl.TabPages.Add(page);
                    this._tabControl.SelectedTab = page;

                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Creating new network failed.");
                }
                
            }
            createDialog.Dispose();
        }

        private void setPagesNewInputData( Hashtable inputData)
        {
            IEnumerator e = this._tabControl.TabPages.GetEnumerator();
            NetPage page;
            while( e.MoveNext())
            {
                page = (NetPage)e.Current;
                page.InputData = inputData;
            }
        }

        private void createFirstTabPage()
        {
            List<int >neurons = new List<int>();
            neurons.Add(10);
            neurons.Add(9);
            neurons.Add(10);

            List<Network.Function> fun = new List<Network.Function>(); 
            fun.Add( new Network.Function( Network.Function.SIGM)); 
            fun.Add( new Network.Function( Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));

            Data.NetworkParam param = new Data.NetworkParam();
            param.Type = Data.NetworkParam.MDS;
            param.Neurons = neurons;
            param.LayerNumber = neurons.Count;
            param.Functions = fun;
            param.SolutionLayerNr = 2;

            //    //get netowrikParam
            //    //createNetowork
            //    //add Network to list
                try
                {
                    int nr = mainANN.AddNetwork(param);
                    NetPage page = new NetPage( nr, mainANN.InputData, mainANN.GetNetwork(nr) );
                    page.NetworkName = "Sie� pierwsza";
                    this._tabControl.TabPages.Add(page);
                    this._tabControl.SelectedTab = page;
                }
            catch(Exception)
           {}
        }
        private void createSecondTabPage()
        {
            List<int> neurons = new List<int>();
            neurons.Add(2);
            neurons.Add(4);
            neurons.Add(4);
            neurons.Add(2);

            List<Network.Function> fun = new List<Network.Function>();
            fun.Add(new Network.Function(Network.Function.IDENTITY));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));

            Data.NetworkParam param = new Data.NetworkParam();
            param.Type = Data.NetworkParam.CLASSIFIER;
            param.Neurons = neurons;
            param.LayerNumber = neurons.Count;
            param.Functions = fun;
            //param.SolutionLayerNr = 2;

            //    //get netowrikParam
            //    //createNetowork
            //    //add Network to list
            try
            {
                int nr = mainANN.AddNetwork(param);
                NetPage page = new NetPage(nr, mainANN.InputData, mainANN.GetNetwork(nr));
                page.NetworkName = "Test";
                this._tabControl.TabPages.Add(page);
                this._tabControl.SelectedTab = page;
            }
            catch (Exception)
            { }
        }
    }
}