using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Neuron
    {
        private int neuronNumber, layerNumber;
        private Hashtable neuronInput;
        private Layer layer;
        private double output;
        //private List<Neuron> neuronOutput; moze sie przyda lista neuronow w nastepnej warstwie

        public Neuron(int neuronNum, int layerNum, Layer lay)
        {
            this.neuronNumber = neuronNum;
            this.layerNumber = layerNum;
            this.layer = lay;
            this.neuronInput = new Hashtable();
            //this.neuronOutput = new List<Neuron>();
            
        }
        public void calculateOutput()
        {
            double sum=0;

            IDictionaryEnumerator e = neuronInput.GetEnumerator();

            while (e.MoveNext())
            {
                Neuron n = (Neuron)e.Key;
                sum += n.getOutput() * (double)e.Value;
            }
            
            this.output = this.layer.getFunction().calculate(sum);

        }
        public int getNeuronNumber()
        {
            return this.neuronNumber;
        }
        public int getLayerNumber()
        {
            return this.layerNumber;
        }
        public double getOutput()
        {
            return this.output;

        }
        public void setOutput(double x)
        {
            this.output = x;
        }
        public Hashtable getInputHashtable()
        {
            return this.neuronInput;
        }
        public void addToHashtable (Neuron n, double x)
        {
            this.neuronInput.Add(n, x);
        }
        public void printHashtable()
        {
            IDictionaryEnumerator e = neuronInput.GetEnumerator();
            Console.Out.Write("Wagi:");
            while (e.MoveNext())
            {
                Console.Out.Write("od(" + ((Neuron)e.Key).getLayerNumber() + "," + ((Neuron)e.Key).getNeuronNumber() + ")");
                Console.Out.Write("do("+this.layerNumber+","+this.neuronNumber+"):"+e.Value + ";\t");
            }
            Console.Out.WriteLine();
        }
        public void printOutput()
        {
            //IDictionaryEnumerator e = neuronInput.GetEnumerator();
            //Console.Out.WriteLine("Wagi:");
            //while (e.MoveNext())
            {
                Console.Out.Write("(" + this.layerNumber + "," + this.neuronNumber + "):" + this.output + ";\t");
            }
            //Console.Out.WriteLine();
        }

    }
}
