using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    public class Layer
    {
        private int layerNumber;
        private List<Neuron> neuronList;
        private Function fun;
    

        public Layer(int layerNum, int neurons)
        {
            this.layerNumber = layerNum;
            this.neuronList = new List<Neuron>();
            this.fun = new Function();
            for (int i = 0; i < neurons; i++)
            {
                Neuron n = new Neuron(i,this);
                this.neuronList.Add(n);
            }
        }
        public int Number
        {
            get { return layerNumber; }
           
        }

        public void setFunId(int id)
        {
            this.fun.setId(id);
        }

        public void SetFunction( String name )
        {
            fun.setId(name);
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
            Console.Out.Write("Output: ");

            for (int i = 0; i < this.neuronList.Count; i++)
            {
                this.neuronList[i].printOutput();
                Console.Out.Write("\t");

            }
            Console.Out.WriteLine();

        }
        public void printWeights()
        {
            //Console.Out.WriteLine("Wagi warstwy");
            for (int i = 0; i < this.neuronList.Count; i++)
            {
                this.neuronList[i].printHashtable();
            }
        }
        public int Size
        {
            get { return this.neuronList.Count; }
            set { 
                if( value > Size )
                {
                        for( int i = Size; i < value; ++i )
                            this.neuronList.Add( new Neuron( i, this ));
                }
                else if( value < Size )
                {
                    for (int i = Size - 1; i >= value; --i)
                        this.neuronList.Remove(this.neuronList[i]);
                }

           }
        }
    }

}

