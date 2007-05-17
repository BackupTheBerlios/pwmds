using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    public class Neuron
    {
        private int neuronNumber;
        private Hashtable neuronInput;
        private Hashtable prevNeuronInput;

        private Layer layer;
        private double output;
        private double inputSum;
        //private List<Neuron> neuronOutput; moze sie przyda lista neuronow w nastepnej warstwie
        
        //b³¹d lokalny dla danego neuronu
        private double localError;

        public Neuron(int neuronNum, Layer lay)
        {
            this.neuronNumber = neuronNum;            
            this.layer = lay;
            this.neuronInput = new Hashtable();
            this.prevNeuronInput = new Hashtable();
            //this.neuronOutput = new List<Neuron>();
            
        }
        public void calculateOutput()
        {
            double sum=0;

            IDictionaryEnumerator e = neuronInput.GetEnumerator();

            while (e.MoveNext())
            {
                Neuron n = (Neuron)e.Key;
                    sum += n.Output * (double)e.Value;
            }
            inputSum = sum;
            this.output = this.layer.getFunction().calculate(sum);

        }
        public int getNeuronNumber()
        {
            return this.neuronNumber;
        }
        public int getLayerNumber()
        {
            return this.layer.Number;
        }

        public double Output
        {
            get { return this.output; }
            set { output = value; }
        }


        public Hashtable getInputHashtable()
        {
            return this.neuronInput;
        }
        public void ModifyT(int neuronNr,double deltaT)
        {
            //neuronNr - numer neuronu poprzedniego
            IEnumerator e = this.neuronInput.Keys.GetEnumerator();
            while (neuronNr > 0)
            {
                e.MoveNext();
                neuronNr--;
            }
            Neuron neuronI = (Neuron)e.Current;
            //this.prevNeuronInput[neuronI] = this.neuronInput[neuronI];
            this.neuronInput[neuronI] = ((double)this.neuronInput[neuronI]) + deltaT; 
        }
        public double D
        {
            get { return localError; }
            set { localError = value; }
        }
        public void addToHashtable (Neuron n, double x)
        {
            this.neuronInput.Add(n, x);
            this.prevNeuronInput.Add(n, x);
        }
        public void printHashtable()
        {
            IDictionaryEnumerator e = neuronInput.GetEnumerator();
            Console.Out.Write("Wagi:");
            int layerNumber = this.layer.Number;
            while (e.MoveNext())
            {
                Console.Out.Write("od(" + ((Neuron)e.Key).getLayerNumber() + "," + ((Neuron)e.Key).getNeuronNumber() + ")");
                Console.Out.Write("do("+layerNumber+","+this.neuronNumber+"):"+e.Value + ";\t");
            }
            Console.Out.WriteLine();
        }

        public void ClearHashtable()
        {
            this.neuronInput.Clear();
            this.prevNeuronInput.Clear();
        }

        public void printOutput()
        {
            int layerNumber = this.layer.Number;
            //IDictionaryEnumerator e = neuronInput.GetEnumerator();
            //Console.Out.WriteLine("Wagi:");
            //while (e.MoveNext())
            {

                Console.Out.Write("(" + layerNumber + "," + this.neuronNumber + "):" + this.output + ";\t");
            }
            //Console.Out.WriteLine();
        }
        public double GetT(Neuron neuron) //neuron poczatkowy po³aczenia
        {
            //Console.Out.WriteLine("GetT:   "+layer.Number+"   "+this.neuronNumber);
            return ((double)this.neuronInput[neuron]);
        }
        public double InputSum
        {
            get { return inputSum; }
        }

        private void rewriteHashtable( Hashtable tableFrom, Hashtable tableTo ) 
        {
            IDictionaryEnumerator e = tableFrom.GetEnumerator();
            Neuron n;
            while (e.MoveNext())
            {
                n = (Neuron)e.Key;
                tableTo[n] = e.Value;
            }
        }

        public void RewriteCurrentInputToPrev()
        {
            rewriteHashtable(neuronInput, prevNeuronInput);
        }

        public void RewritePrevInputToCurrent()
        {
            rewriteHashtable(prevNeuronInput, neuronInput);
        }

       
    }
}
