using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Layer
    {
        private int layerNumber;
        private List<Neuron> neuronList;
        private Function fun;

        public Layer(int neurons)
        {
            neuronList = new List<Neuron>();
            this.fun = new Function();
            for (int i = 0; i < neurons; i++)
            {
                Neuron n = new Neuron(this);
                this.neuronList.Add(n);
            }
        }
        public void setFunId(int id)
        {
            this.fun.setId(id);
        }
        public Function getFunction()
        {
            return this.fun;
        }
        public void calculateOutput()
        {
            for (int i = 0; i < this.neuronList.Count; i++)
            {
                this.neuronList[i].calculateOutput();
            }
        }
        public List<Neuron> getNeuronList()
        {
            return this.neuronList;
        }
        public Neuron getNeuronIndex(int i)
        {
            if (i < 0 || i > this.neuronList.Count - 1)
            {
                throw new Exception("Out of range in getNeuronIndex");
            }
            return this.neuronList[i];
        }

        public void printOutput()
        {
            Console.Out.Write("Warstwa: ");

            for (int i = 0; i < this.neuronList.Count; i++)
            {
                Console.Out.Write(this.neuronList[i].getOutput() + "\t");

            }
            Console.Out.WriteLine();

        }
        public void printWeights()
        {
            Console.Out.WriteLine("Wagi warstwy");
            for (int i = 0; i < this.neuronList.Count; i++)
            {
                this.neuronList[i].printHashtable();
            }
        }
    }

}

