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
        private Object mainClass; // g³owna klasa programu z metoda main, ktora wywoluje formularz glowny GUI
        private String[,] loadedData; // tablica wczytanych danych z pliku bazy danych
        private Thread loader; // watek wczytujacy dane bedace skalowane do tablicy
        private String filePath = null;

        public frmMain(Object mainClass)
        {
            InitializeComponent();
            this.mainClass = mainClass;
            this.loadedData = new String[8000,620];
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

            try
            {
            // pobiera nazwe pliku z danymi     
                openFileDialog.Filter = "data files (*.data)|*.data|All files (*.*)|*.*";
                openFileDialog.Title = "Wybierz plik z danymi do przeskalowania.";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog.FileName;

            // wywolanie fun. wczytujacej dane z pliku (funkcja wczytujaca plik do tablicy, uruchamiana jest w nowym watku)
                loader = new Thread(new ThreadStart(this.readToArray));
                loader.Priority = ThreadPriority.Highest;
                loader.Start();
            }
            catch (Exception ex)
            {
                this.errorHandler(ex);
            }
        }

        // wczytuje dane z pliku
        private void readToArray()
        {
            StreamReader reader;
            String line;
            String[] splitedLine;
            int i = 0;
            int j = 0;

            try
            {
                // blokuje dostep do tablicy na czas dzialania watku
                lock (this.loadedData)  
                {
                    if (filePath != null)
                    {
                        reader = File.OpenText(filePath);
                        line = reader.ReadLine();
                        // wczytuje kolejno wiersze pliku i rozbija je do tablicy ktora zapisywana jest do tablicy
                        while (line != null)
                        {
                            splitedLine = line.Split(',');
                               for (j = 0; j < splitedLine.Length; j++)
                               {
                                loadedData[i, j] = splitedLine[j];    // uwaga ostatnia kolumna loadedData zawiera bia³y znak(lub null), nale¿y j¹ ignorowaæ
                               }
                            line = reader.ReadLine();
                            i++;
                        }
                        MessageBox.Show("Wczytano " + i + " rekordów. ", "Dane wczytano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reader.Close();
                    }
                }
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

    }
}