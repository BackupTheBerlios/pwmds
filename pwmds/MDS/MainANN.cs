/* G³owna klasa aplikacji. Tytaj trzymane sa wszystkie sieci, dane.
 * Obiekt tej klasy jest trzymany w obiekcie g³ównego formularza */
using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;


namespace MDS
{
    class MainANN
    {
        private Hashtable inputData;
        private GUI.frmMain frmMain;

        public MainANN(GUI.frmMain frmMain)
        {
            this.frmMain = frmMain;
            inputData = new Hashtable();
        }

        // wczytuje dane do skalowania z pliku do tablicy potem do listy inputData
        public void loadInputData(String filePath)
        {
            List<double[]> loadedData;
            double[] row;
            StreamReader reader;
            String line;
            String[] splitedLine;
            int j = 0;
            int i = 0;

            if (filePath != null)
            {
              row = new double[1000];
              loadedData = new List<double[]>(); // lista z tablicami(wierszami) danych wejsciowych, jedna lista == jeden zestaw danych 
              reader = File.OpenText(filePath);
              line = reader.ReadLine();
              // wczytuje kolejno wiersze pliku i rozbija je do tablicy ktora zapisywana jest do tablicy
              while (line != null)
              {
                  splitedLine = line.Split(',');
                  for (j = 0; j < splitedLine.Length; j++)
                  {
                      if (!Double.TryParse(splitedLine[j], out row[j]))
                          row[j] = Double.NaN;               
                  }
                  loadedData.Add(row);
                  line = reader.ReadLine();
                  i++;
              }
              this.inputData.Add(filePath, loadedData);
              reader.Close();
              MessageBox.Show(null, "Wczytano " + i + " rekordów. ", "Dane wczytano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }// end loadInput Data
    }
}
