using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Perceptron
    {
        private int inputSize, outputSize;
        private List<Layer> layerList;

        public Perceptron(int[] neurons)  //liczba warstw i neuronow w kazdej warstwie
        {
            
            layerList = new List<Layer>();

            if (neurons == null)
            {
                throw new Exception("Bad parameters for perceptron constructor");
            }
            int layers = neurons.Length;
            this.inputSize = neurons[0];
            this.outputSize = neurons[layers - 1];
            Random r = new Random();
            for (int i = 0; i < layers; i++)
            {
                Layer l = new Layer(i,neurons[i]);
                layerList.Add(l);
            }
            for (int i = 0; i < layers-1; i++)
            {
                for (int j = 0; j < neurons[i+1]; j++)
                {
                    List<Neuron> l = this.layerList[i].getNeuronList();
                    Neuron n = this.layerList[i+1].getNeuronIndex(j);
                   
                    for (int k = 0; k < l.Count; k++)
                    {
                        n.addToHashtable(l[k],1);//r.NextDouble() );
                    }
                }
            }
        }

        public void setFunctionForLayer(int functionId, int layerNumber)
        {
            Layer l = this.layerList[layerNumber];
            l.setFunId(functionId);
        }
            
        public float[] calculateOutput(double[] input)
        {
            if (input == null) throw new Exception("Null pointer exception in calculateOutput");
            if (input.Length != this.inputSize) throw new Exception("Wrong input size in calculateOutput");

            //ustawiamy wyjscie neuronow pierwszej warstwy na wartosc wektora wejsciowego
            List<Neuron> l = this.layerList[0].getNeuronList();
            for (int i = 0; i < this.inputSize; i++)
            {
                l[i].Output = input[i];
            }
            this.layerList[0].printOutput();
            for (int i = 1; i < this.layerList.Count; i++)
            {
                this.layerList[i].calculateOutput();
                this.layerList[i].printOutput();
            }
            
            return null;
        }
        public void printWeights()
        {
            for (int i = 1; i < this.layerList.Count; i++)
            {
                this.layerList[i].printWeights();
            }
        }

        public int Size
        {
            get { return layerList.Count; }
        }
        public int MaxLayerSize
        {
            get
            {
                int n = 0;
                for (int i = 0; i < this.Size; i++)
                {
                    Layer layer = this.layerList[i];
                    int j = layer.Size;
                    if (j > n)
                        n = j;
                }
                return n;

            }
        }

        public Layer getLayer( int nr )
        {
            return layerList[nr];
        }
    }
}
