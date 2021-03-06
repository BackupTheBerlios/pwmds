/* G�owna klasa aplikacji. Tytaj trzymane sa wszystkie sieci, dane.
 * Obiekt tej klasy jest trzymany w obiekcie g��wnego formularza */
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
                file2 = "Arrhythmia_skal", 
                file3 = "art_data.txt",
                file4 = "wine/wine_skal.data",
                file5 = "wine/wine.data",
                file6 = "wine/wine_learn_50_skal.data",
                file7 = "wine/wine_out_size3_learn_50.data",
                file8 = "wine/wine_class_learn_50.data",
                file9 = "classOut3D.txt",
                file10 = "class3D.txt";
        private String name1 = "Arrhythmia",
                        name2 = "Arrhythmia_skal",
                        name3 = "art_data",
                        name4 = "wine_skal",
                        name5 = "Wine",
                        name6 = "wine_learn50",
                        name7 = "wine_out_size3_learn_50",
                        name8 = "wine_class_learn_50",
                        name9 = "ClassOut_3D",
                        name10 = "Class_3D";

        
        public MainANN()
        {
            inputData = new Hashtable();
            netList = new List<MDS.Network.Perceptron>();
            dataProcessor = new MDS.Data.DataPreprocessor();
            readDefaultFiles();
            
            
        }

        public MainANN(bool i)
        {
            inputData = new Hashtable();
            netList = new List<MDS.Network.Perceptron>();
            dataProcessor = new MDS.Data.DataPreprocessor();
            //readDefaultFiles();


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

                  
                  loadedData.Add(row);
                  //row = new double[10];
                  line = reader.ReadLine();
                 /// i++;
//                  if (i >= 10)
  //                    break;
              }
              //this.inputData.Add(filePath, loadedData);
              loadedData = dataProcessor.DeleteMissingValues(loadedData, 0.6);
              
              this.inputData.Add(name, loadedData);
              reader.Close();
            }
            return 0;
        }// end loadInput Data


        public void WriteData(String filename, List<double[]> data )
        {
            StreamWriter writer;
            String text;
            writer = new StreamWriter(File.Open(filename, FileMode.Append));
            for (int i = 0; i < data.Count; ++i)
            {
                //for (int j = 0; j < data[i].Length; ++j)
                //{
                    /*int c = getMainVal(data[i]);
                    int fr = getFraction(data[i]);
                    writer.Write(c);
                    writer.Write(".");
                    if (fr < 10)
                        writer.Write("0");
                     */
                text = Data.ProcessData.GetStringList(data[i], true);
                writer.Write( text );
                writer.WriteLine();
            }
            writer.Close();
        }


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
            //loadInputData(name3, file3);
            loadInputData(name4, file4);
            loadInputData(name5, file5);
            loadInputData(name6, file6);
            loadInputData(name7, file7);
            loadInputData(name8, file8);
            loadInputData(name9, file9);
            loadInputData(name10, file10);

            //WriteBinaryLastValue((List<double[]>)inputData[name1]);
            //WriteBinaryFirstValue((List<double[])>)inputData[name5]);

            loadSpecificInputData("Iris", "iris/iris.data");
            WriteBinaryIrisClass((List<double[]>)inputData["Iris"]);
        }

        /*public List<double[]> SelectVectorsFromData( List<double[]> oldData, int startNr, int endNr )
        {
            return dataProcessor.SelectVectors(oldData, startNr, endNr);
        }*/
        public List<double[]> SelectVectorsFromData(List<double[]> oldData, List<int> vectorsNo)
        {
            return dataProcessor.SelectVectors(oldData, vectorsNo );
        }
        /*
        public List<double[]> SelectColumnsFromData(List<double[]> oldData, int startColumn, int endColumn)
        {
            return dataProcessor.SelectColumns(oldData, startColumn, endColumn);
        }
        */
        public List<double[]> SelectColumnsFromData(List<double[]> oldData, List<int> vectorsNo)
        {
            return dataProcessor.SelectColumns(oldData, vectorsNo);
        }

        public List<double[]> Standarize(List<double[]> oldData)
        {
            return dataProcessor.StandarizeData( oldData, 
                Data.DataPreprocessor.STANDARIZE, 0, 1);
        }


        public List<double[]> Scaling(List<double[]> oldData, int startVal, int endVal)
        {
            return dataProcessor.StandarizeData(oldData, 
                Data.DataPreprocessor.SCALING, startVal, endVal);
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

        private void WriteBinaryLastValue(List<double[]> arrytmia)
        {
            List<double[]> binary = new List<double[]>(arrytmia.Count);
            int val, rest, i;
            double[] binaryValues;

            foreach (double[] vector in arrytmia)
            {
                binaryValues = new double[16];
                for(i = 0; i < binaryValues.Length; ++i )
                    binaryValues[i] = 0;
                val = (int)vector[vector.Length - 1] - 1; //warto�ci z zakresu <0,15>
                binaryValues[val] = 1;
                binary.Add(binaryValues);
            }
            this.WriteData("classification.data", binary);
        }

        private void WriteBinaryFirstValue(List<double[]> wineData)
        {
            List<double[]> binary = new List<double[]>(wineData.Count);
            int val, rest, i;
            double[] binaryValues;

            foreach (double[] vector in wineData)
            {
                binaryValues = new double[3];
                for (i = 0; i < binaryValues.Length; ++i)
                    binaryValues[i] = 0;
                val = (int)vector[0] - 1; //warto�ci z zakresu <0,15>
                binaryValues[val] = 1;
                binary.Add(binaryValues);
            }
            this.WriteData("wine_class.data", binary);
        }

        private void WriteBinaryIrisClass(List<double[]> iris)
        {
            List<double[]> binary = new List<double[]>(iris.Count);
            int val, rest, i;
            double[] binaryValues;

            foreach (double[] vector in iris)
            {
                binaryValues = new double[3];
                for (i = 0; i < binaryValues.Length; ++i)
                    binaryValues[i] = 0;
                if (vector.Length == 0)
                    continue;
                val = (int)vector[vector.Length - 1] ; //warto�ci z zakresu <0,15>
                binaryValues[val] = 1;
                binary.Add(binaryValues);
            }
            this.WriteData("iris/iris_class.data", binary);
        }

        public int loadSpecificInputData(String name, String filePath)
        {
            List<double[]> loadedData = new List<double[]>();
            List<double> list = new List<double>();
            Hashtable hash = new Hashtable();

            double[] row;
            double val = 0;
            StreamReader reader;
            String line, str;
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

                    for (j = 0; j < splitedLine.Length; j++)
                    {
                        // zamienia kropke na przecinek(np 3.5 na 3,5) aby parser dobrze zamienil
                        splitedLine[j] = splitedLine[j].Replace('.', ',');

                        try
                        {
                            if (!Double.TryParse(splitedLine[j], out val))
                            {
                                //znaczy �e string
                                str = splitedLine[j];
                                if (str.Length == 0)
                                    continue;
                                if (!hash.Contains(str))
                                {
                                    hash.Add(str, (double)hash.Count);
                                    val = (double)hash.Count - 1;
                                }
                                else
                                    val = (double)hash[str];
                            }
                        }
                        catch (Exception ex)
                        {
                            
                                
                        }
                        list.Add(val);
                    }

                    // row[j] = Double.PositiveInfinity; // ostatnia wczytana kolumna, ktora zawsze jest 0(tak rozdziela split). Wpisujemy do nie nieskonczonosc aby okreslic koniec danego wiersza danych, gdyz tablica ma stala wielkosc 800
                    row = new double[list.Count];
                    for (int i = 0; i < list.Count; ++i)
                        row[i] = list[i];


                    loadedData.Add(row);
                    //row = new double[10];
                    line = reader.ReadLine();
                    /// i++;
                    //                  if (i >= 10)
                    //                    break;
                }
                //this.inputData.Add(filePath, loadedData);
                //loadedData = dataProcessor.DeleteMissingValues(loadedData, 0.6);

                this.inputData.Add(name, loadedData);
                reader.Close();
            }

            WriteData("iris/numeric_iris.data", loadedData);
            return 0;
        }// end loadInput Data
    }
}
