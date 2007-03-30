using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace MDS.Tests
{
    class testLoadData
    {

        public testLoadData(MDS.MainANN mainANN)
        {
            Hashtable data = mainANN.InputData;
            //List<double[]> oneSet;
            StreamWriter writer;
            writer = File.CreateText("test.data");
            foreach (List<double[]> oneSet in data.Values)
            {
                foreach(double[] row in oneSet)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        writer.Write(row[i].ToString());
                        writer.Write(" ");
                    }
                    writer.Write("\r\n");
                }
            }
            writer.Close();
        }
    }
}
