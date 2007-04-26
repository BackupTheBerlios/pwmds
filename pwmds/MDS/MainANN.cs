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
        private Data.DataPreprocessor dataProcessor;

        private String file1 = "arrhythmia.data", 
                file2 = "in.txt", 
                file3 = "out.txt",
                file4 = "in2.txt",
                file5 = "classIn2D.txt",
                file6 = "classOut2D.txt",
                file7 = "class2D.txt",
                file8 = "classIn3D.txt",
                file9 = "classOut3D.txt",
                file10 = "class3D.txt";
        private String name1 = "Arrhythmia",
                        name2 = "In",
                        name3 = "Out",
                        name4 = "In2",
                        name5 = "ClassIn_2D",
                        name6 = "ClassOut_2D",
                        name7 = "Class_2D",
                        name8 = "ClassIn_3D",
                        name9 = "ClassOut_3D",
                        name10 = "Class_3D";

        
        public MainANN()
        {
            inputData = new Hashtable();
            netList = new List<MDS.Network.Perceptron>();
            dataProcessor = new MDS.Data.DataPreprocessor();
            readDefaultFiles();
            
            
        }

        // wczytuje dane do skalowania z pliku do tablicy potem do listy inputData
        public int loadInputData(String name, String filePath)
        {
            List<double[]> loadedData;
            List<double> list = new List<double>();
            double[] row;
            double val;
            StreamReader reader;
            String line;
            String[] splitedLine;
            int j = 0;
            //int i = 0;

            if (filePath != null)
            {
                
              loadedData = new List<double[]>(); // lista z tablicami(wierszami) danych wejsciowych, jedna lista == jeden zestaw danych 
              reader = File.OpenText(filePath);
              line = reader.ReadLine();
              // wczytuje kolejno wiersze pliku i rozbija je do tablicy ktora zapisywana jest do tablicy
              while (line != null)
              {
                  list.Clear();
                  splitedLine = line.Split(',');

                  for (j = 0; j < splitedLine.Length ; j++)
                  {
                      // zamienia kropke na przecinek(np 3.5 na 3,5) aby parser dobrze zamienil
                      splitedLine[j] = splitedLine[j].Replace('.', ',');


                      if (!Double.TryParse(splitedLine[j], out val))
                          val = Double.NaN;
                     list.Add(val);
                  }

                 // row[j] = Double.PositiveInfinity; // ostatnia wczytana kolumna, ktora zawsze jest 0(tak rozdziela split). Wpisujemy do nie nieskonczonosc aby okreslic koniec danego wiersza danych, gdyz tablica ma stala wielkosc 800
                  row = new double[list.Count];
                  for (int i = 0; i < list.Count; ++i)
                      row[i] = list[i];

                  dataProcessor.ReplaceMissingValuesByMean(row);
                  loadedData.Add(row);
                  //row = new double[10];
                  line = reader.ReadLine();
                 /// i++;
//                  if (i >= 10)
  //                    break;
              }
              //this.inputData.Add(filePath, loadedData);
              
              this.inputData.Add(name, loadedData);
              reader.Close();
            }
            return 0;
        }// end loadInput Data


        /** Adds new network to network list.*/

        public int AddNetwork( Data.NetworkParam param )
        {
            Perceptron newNetwork = new Perceptron(param);
            netList.Add( newNetwork);
            return netList.Count - 1;
        }

        public void AddNewData(String dataName, List<double[]> newData)
        {
            inputData.Add(dataName, newData);
        }

        private void readDefaultFiles()
        {
            loadInputData(name1, file1);
            loadInputData(name2, file2);
            loadInputData(name3, file3);
            loadInputData(name4, file4);
            loadInputData(name5, file5);
            loadInputData(name6, file6);
            loadInputData(name7, file7);
            loadInputData(name8, file8);
            loadInputData(name9, file9);
            loadInputData(name10, file10);
        }

        public List<double[]> SelectVectorsFromData( String oldDataName, int startNr, int endNr )
        {
            return dataProcessor.SelectVectors((List<double[]>)inputData[oldDataName], startNr, endNr);
        }

        public List<double[]> Standarize(String oldDataName)
        {
            List<double[]> newData = (List<double[]>)inputData[oldDataName];
            dataProcessor.StandarizeData( newData, Data.DataPreprocessor.STANDARIZE, 0, 1);
            return newData;
        }


        public List<double[]> Scaling(String oldDataName, int startVal, int endVal)
        {
            List<double[]> newData = (List<double[]>)inputData[oldDataName];
            dataProcessor.StandarizeData(newData, Data.DataPreprocessor.SCALING, startVal, endVal);
            return newData;
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
