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

        private double globalError;
        private double stress;

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

        public void Process(Data.ProcessData data)
        {
            int solutionSize,
                lastSize = this.layerList[layerList.Count-1].Size;
            
            
                
            double[] last = new double[lastSize],
                solution; 
            Layer solutionLayer;
            Layer lastLayer = layerList[layerList.Count-1];

            if (solutionLayerNr <= 0)
                solutionLayerNr = 1;
            if(type == Data.NetworkParam.MDS )
                solutionSize = this.layerList[this.solutionLayerNr - 1].Size;
            else
                solutionSize = this.layerList[this.Size - 1].Size; //rozmiar ostatniej warstwy
            solution = new double[solutionSize];
            solutionLayer = layerList[solutionLayerNr - 1];
            globalError = 0;
            foreach( double[] vector in data.Input )
            {
                calculateOutput(vector);
                //data.AddOutput(calculateOutput(vector));
                //dodaj do last i solution
                
                last = new double[lastSize];
                for (int i = 0; i < lastSize; ++i)
                    last[i] = lastLayer.getNeuronIndex(i).Output;

                solution = new double[solutionSize];
                if (type == Data.NetworkParam.MDS)
                {
                    for (int i = 0; i < solutionSize; ++i)
                        solution[i] = solutionLayer.getNeuronIndex(i).Output;
                }
                else
                    solution = Classify(last);

                data.AddOutput(last);
                data.AddSolution(solution);
                globalError += calculateError( vector, last);
            }

            globalError /= data.Input.Count;
            stress = 0;
            calculateStress(data);
        }

        private double calculateError( double[] properOutput, double[] output)
        {
            return 1.0 / 2.0 * Function.Square(properOutput, output);
        }

        public void calculateStress( Data.ProcessData data )
        {
            double dist1, dist2;
            int dataSize = data.Size;
            for(int i = 0; i < dataSize; ++i )
                for (int j = 0; j < dataSize; ++j)
                {
                    if (i == j) continue;
                    dist1 = Function.Square(data.Input[i], data.Input[j]);
                    dist2 = Function.Square(data.Solution[i], data.Solution[j]);
                    stress += Math.Abs(dist1 - dist2) / dist1;
                }
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

        public double[] Classify( double[] vector)
        {
            double max = 0;
            int max_id = -1;
            for (int i = 0; i < vector.Length; ++i)
            {
                if (vector[i] > max)
                {
                    max = vector[i];
                    max_id = i;
                }
            }
            double[] classVector = new double[vector.Length];
            for (int i = 0; i < classVector.Length; ++i)
            {
                if (i == max_id)
                    classVector[i] = 1;
                else
                    classVector[i] = 0;
            }
            return classVector;
        }

        public static int GetClassNumber(double[] vector)
        {
            int i = 0;
            while (vector[i] != 1)
                ++i;
            return i + 1;
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

        public double Error
        {
            get { return globalError; }
        }

        public double Stress
        {
            get { return stress; }
        }
    }
}
