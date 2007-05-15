using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Perceptron
    {
        private int inputSize, outputSize;
        private List<Layer> layerList;
        private int solutionLayerNr;
        private int type;

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
      /*      for (int i = 0; i < layers-1; i++)
            {
                for (int j = 0; j < neurons[i+1]; j++)
                {
                    List<Neuron> l = this.layerList[i].getNeuronList();
                    Neuron n = this.layerList[i+1].getNeuronIndex(j);
                   
                    for (int k = 0; k < l.Count; k++)
                    {
                        n.addToHashtable(l[k],0.1);//r.NextDouble() );
                    }
                }
            }*/
            SetRandomWeights();
        }

        public Perceptron(Data.NetworkParam param)
        {

            if (param == null)
                throw new ArgumentNullException();

            layerList = new List<Layer>(param.LayerNumber);
            if(param.Neurons == null || param.Neurons.Count == 0)
                throw new ArgumentNullException();
            int layers = param.Neurons.Count;
            this.inputSize = param.Neurons[0];
            this.outputSize = param.Neurons[layers - 1];
            this.type = param.Type;
            this.solutionLayerNr = param.SolutionLayerNr;
            
            for (int i = 0; i < layers; i++)
            {
                Layer l = new Layer(i+1, param.Neurons[i]);
                l.SetFunction(param.Functions[i]);
                layerList.Add(l);
            }

            SetRandomWeights();

        }

        private void setWeights()
        {
            int layers = layerList.Count;
            int neurons;
            for (int i = 0; i < layers - 1; i++)
            {
                neurons = layerList[i + 1].Size;
                for (int j = 0; j < neurons; j++)
                {
                    List<Neuron> l = this.layerList[i].getNeuronList();
                    Neuron n = this.layerList[i + 1].getNeuronIndex(j);

                    for (int k = 0; k < l.Count; k++)
                    {
                        n.addToHashtable(l[k], 0.1);//r.NextDouble() );
                    }
                }
            }
        }

        public void SetRandomWeights()
        {
            int layers = layerList.Count;
            int neurons;
            Random r = new Random();
            
            for (int i = 0; i < layers - 1; i++)
            {
                neurons = layerList[i + 1].Size;
                for (int j = 0; j < neurons; j++)
                {
                    List<Neuron> l = this.layerList[i].getNeuronList();
                    Neuron n = this.layerList[i + 1].getNeuronIndex(j);
                    n.ClearHashtable();
                    for (int k = 0; k < l.Count; k++)
                    {
                        
                        n.addToHashtable(l[k], r.NextDouble()/3 );
                    }
                }
            }
        }



        public void setFunctionForLayer(int functionId, int layerNumber)
        {
            Layer l = this.layerList[layerNumber];
            l.setFunId(functionId);
        }
            
        public double[] calculateOutput(double[] input)
        {
            if (input == null) throw new Exception("Null pointer exception in calculateOutput");
            
            //trochê mi bruŸdzi³o wiêc wykomentowa³am - Agnieszka
            //if (input.Length != this.inputSize) throw new Exception("Wrong input size in calculateOutput");

            //ustawiamy wyjscie neuronow pierwszej warstwy na wartosc wektora wejsciowego
            List<Neuron> l = this.layerList[0].getNeuronList();
            for (int i = 0; i < this.inputSize; i++)
            {
                l[i].Output = input[i];
            }
            //this.layerList[0].printOutput();
            for (int i = 1; i < this.layerList.Count; i++)
            {
                this.layerList[i].calculateOutput();
                //this.layerList[i].printOutput();
            }
           
            return null;
        }

        public double Process(Data.ProcessData data)
        {
            int solutionSize,
                lastSize = this.layerList[layerList.Count-1].Size;

            double globalError;
            
                
            double[] last = new double[lastSize],
                solution; 
            Layer solutionLayer;
            Layer lastLayer = layerList[layerList.Count-1];

            if (solutionLayerNr <= 0)
                solutionLayerNr = 1;

            solutionSize = this.layerList[this.solutionLayerNr - 1].Size;
            solution = new double[solutionSize];
            solutionLayer = layerList[solutionLayerNr - 1];
            globalError = 0;
            foreach( double[] vector in data.Input )
            {
                calculateOutput(vector);
                //data.AddOutput(calculateOutput(vector));
                //dodaj do last i solution
                solution = new double[solutionSize];
                for (int i = 0; i < solutionSize; ++i)
                {
                    solution[i] = solutionLayer.getNeuronIndex(i).Output;
                }
                last = new double[lastSize];
                for (int i = 0; i < lastSize; ++i)
                {
                    last[i] = lastLayer.getNeuronIndex(i).Output;
                }
                data.AddOutput(last);
                data.AddSolution(solution);
                globalError += calculateError( vector, last);
            }

            globalError /= data.Input.Count;
            return globalError;
        }

        private double calculateError( double[] properOutput, double[] output)
        {
            return 1.0 / 2.0 * Function.Square(properOutput, output);
        }


        public void PrintOutput()
        {
            this.layerList[this.layerList.Count-1].printOutput();
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

        public String TypeName
        {
            get { return Data.NetworkParam.TYPES[type]; }
        }

        public int Type
        {
            get { return type; }
        }
    }
}
