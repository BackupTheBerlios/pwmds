/* G³owna klasa aplikacji. Tytaj trzymane sa wszystkie sieci, dane.
 * Obiekt tej klasy jest trzymany w obiekcie g³ównego formularza */
using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using MDS.Network;


namespace MDS
{
    class MainANN
    {
        private Hashtable inputData; // Hastablica zawierajaca Listy wczytanych danych, jako key otrzymuje nazwe pliku z ktorego dane byly wczytywane
        private List<Network.Perceptron> netList;

        public MainANN()
        {
            inputData = new Hashtable();
            netList = new List<MDS.Network.Perceptron>();
        }

        // wczytuje dane do skalowania z pliku do tablicy potem do listy inputData
        public int loadInputData(String name, String filePath)
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
              row = new double[800];
              loadedData = new List<double[]>(); // lista z tablicami(wierszami) danych wejsciowych, jedna lista == jeden zestaw danych 
              reader = File.OpenText(filePath);
              line = reader.ReadLine();
              // wczytuje kolejno wiersze pliku i rozbija je do tablicy ktora zapisywana jest do tablicy
              while (line != null)
              {
                  splitedLine = line.Split(',');

                  for (j = 0; j < splitedLine.Length; j++)
                  {
                      // zamienia kropke na przecinek(np 3.5 na 3,5) aby parser dobrze zamienil
                      splitedLine[j] = splitedLine[j].Replace('.', ',');
    
                      if (!Double.TryParse(splitedLine[j], out row[j]))
                          row[j] = Double.NaN;               
                  }
                  row[j] = Double.PositiveInfinity; // ostatnia wczytana kolumna, ktora zawsze jest 0(tak rozdziela split). Wpisujemy do nie nieskonczonosc aby okreslic koniec danego wiersza danych, gdyz tablica ma stala wielkosc 800
                  loadedData.Add(row);
                  row = new double[800];
                  line = reader.ReadLine();
                  i++;
              }
              //this.inputData.Add(filePath, loadedData);
              this.inputData.Add(name, loadedData);
              reader.Close();
            }
            return i;
        }// end loadInput Data


        /** Adds new network to network list.*/

        public int AddNetwork( Data.NetworkParam param )
        {
            Perceptron newNetwork = new Perceptron(param);
            netList.Add( newNetwork);
            return netList.Count - 1;
        }

        public Hashtable InputData
        {
            get { return inputData; }
            set { inputData = value; }
        }

        public Perceptron GetNetwork(int netNr)
        {
            return this.netList[netNr];
        }


        /** Gets names of available inputData.*/
        public List<String> DataNames
        {
            get 
            {
                List<String> names = new List<string>(inputData.Count);
                IEnumerator en = inputData.Keys.GetEnumerator();
                while (en.MoveNext())
                    names.Add((String)en.Current);
                return names;
            }
        }
    }
}
