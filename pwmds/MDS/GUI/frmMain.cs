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
        private Data.DataPreprocessor d;
        private Tests.TestPreprocessor pretest;  //do testow
        public frmMain()
        {
            InitializeComponent();
            mainANN = new MainANN();
            createFirstTabPage();
            createSecondTabPage();

            d = new MDS.Data.DataPreprocessor();
            pretest = new MDS.Tests.TestPreprocessor();

            createThirdTabPage();
            createFourthTabPage();
            createFithTabPage();
            createSixthTabPage();
            createSeventhTabPage();

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
                    MessageBox.Show(null, "Wczytano " + i + " rekordów. ", "Dane wczytano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
                this.statusStrip1.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Istniej¹ ju¿ dane wczytane z wybranego pliku.\n W celu wczytania tego samego pliku, nale¿y zmieniæ nazwê wczeœniej wczytanych danych. ", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                this.statusStrip1.Items[0].Text = "Bezczynny";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    page.NetworkName = "Sieæ pierwsza";
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

        //kod testowy dla preprocesiingu danych
        private void _mProcessData_Click(object sender, EventArgs e)
        {
            this.mainANN.InputData.Remove("Arrythmia");
            IDictionaryEnumerator en = this.mainANN.InputData.GetEnumerator();
            while (en.MoveNext())
            {
                try
                {
                    this.d.standarizeData((List<double[]>)en.Value, 2, 1, 3);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            pretest.printProcessedHashtable(this.mainANN.InputData);
        }


        private void createThirdTabPage()
        {
            List<int> neurons = new List<int>();
            neurons.Add(2);
            neurons.Add(2);
            neurons.Add(2);
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
                page.NetworkName = "2-2-2-2";
                this._tabControl.TabPages.Add(page);
                this._tabControl.SelectedTab = page;
            }
            catch (Exception)
            { }
        }

        private void createFourthTabPage()
        {
            List<int> neurons = new List<int>();
            neurons.Add(3);
            neurons.Add(2);
            neurons.Add(2);
            neurons.Add(3);

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
                page.NetworkName = "3-2-2-3";
                this._tabControl.TabPages.Add(page);
                this._tabControl.SelectedTab = page;
            }
            catch (Exception)
            { }
        }

        private void createFithTabPage()
        {
            List<int> neurons = new List<int>();
            neurons.Add(2);
            neurons.Add(5);
            neurons.Add(5);
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
                page.NetworkName = "2-5-5-2";
                this._tabControl.TabPages.Add(page);
                this._tabControl.SelectedTab = page;
            }
            catch (Exception)
            { }
        }      
        private void createSixthTabPage()
        {
            List<int> neurons = new List<int>();
            neurons.Add(2);
            neurons.Add(10);
            neurons.Add(1);
            neurons.Add(10);
            neurons.Add(2);

            List<Network.Function> fun = new List<Network.Function>();
            fun.Add(new Network.Function(Network.Function.IDENTITY));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));

            Data.NetworkParam param = new Data.NetworkParam();
            param.Type = Data.NetworkParam.MDS;
            param.Neurons = neurons;
            param.LayerNumber = neurons.Count;
            param.Functions = fun;
            param.SolutionLayerNr = 3;

            //    //get netowrikParam
            //    //createNetowork
            //    //add Network to list
            try
            {
                int nr = mainANN.AddNetwork(param);
                NetPage page = new NetPage(nr, mainANN.InputData, mainANN.GetNetwork(nr));
                page.NetworkName = "2-10-1-10-2";
                this._tabControl.TabPages.Add(page);
                this._tabControl.SelectedTab = page;
            }
            catch (Exception)
            { }
        }
        private void createSeventhTabPage()
        {
            List<int> neurons = new List<int>();
            neurons.Add(3);
            neurons.Add(15);
            neurons.Add(1);
            neurons.Add(15);
            neurons.Add(3);

            List<Network.Function> fun = new List<Network.Function>();
            fun.Add(new Network.Function(Network.Function.IDENTITY));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));
            fun.Add(new Network.Function(Network.Function.SIGM));

            Data.NetworkParam param = new Data.NetworkParam();
            param.Type = Data.NetworkParam.MDS;
            param.Neurons = neurons;
            param.LayerNumber = neurons.Count;
            param.Functions = fun;
            param.SolutionLayerNr = 3;

            //    //get netowrikParam
            //    //createNetowork
            //    //add Network to list
            try
            {
                int nr = mainANN.AddNetwork(param);
                NetPage page = new NetPage(nr, mainANN.InputData, mainANN.GetNetwork(nr));
                page.NetworkName = "3-15-1-15-3";
                this._tabControl.TabPages.Add(page);
                this._tabControl.SelectedTab = page;
            }
            catch (Exception)
            { }
        }


    }
}