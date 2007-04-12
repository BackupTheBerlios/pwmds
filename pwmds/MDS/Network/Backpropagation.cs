using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Network
{
    class Backpropagation
    {
        private Perceptron perceptron;
        private Data.LearningParam param;
        private int layers;
        //1 - warstwa neuronu ko�cowego, 2 - pocz�tkowy neuron, 3 - ko�cowy neuron       
        private double[, ,] w, w1;   //w(t) i w(t-1)

        public Backpropagation(Perceptron perceptron, Data.LearningParam param)
        {
            this.perceptron = perceptron;
            this.param = param;
            layers = perceptron.Size;

            int n = perceptron.MaxLayerSize;            
            w = new double[layers, n, n];
            w1 = new double[layers, n, n];
        }
        public void Learn()
        {
            int startIter = 100000;
            int iter = startIter;
            double globalError=0;
            Console.Out.WriteLine("Start backpropagation...   ");
            while (iter >= 0)
            {
                globalError =0;
                for (int j = 0; j < param.Input.Count; ++j)
                {    
                    learnOneSample(j);           
                    perceptron.calculateOutput(param.Input[j]);
                    globalError += calculateGlobalError(j);
                }
                globalError = globalError / param.Input.Count;                    
                if (globalError < param.Epsilon) break;
                    
                if (iter % 10000 == 0)
                {
                    Console.Out.WriteLine("iter::::: " + (startIter-iter) + " GLOBAL ERROR: " + globalError);
                }
                iter--;
            }
            Console.Out.WriteLine("Liczba iteracji " + (startIter-iter) + " GLOBAL ERROR: " + globalError);
            Console.Out.WriteLine("PO NAUCE WSZYSTKICH WZORCOW:   ");
            for (int k = 0; k < param.Input.Count; ++k)
            {
                perceptron.calculateOutput(param.Input[k]);
                PrintResultsOfLearning(k);
            }



            /*globalError =0; 
            for (int j = 0; j < param.Input.Count; ++j)
            {                
                perceptron.calculateOutput(param.Input[j]);
                Layer lastLayer = perceptron.getLayer(layers - 1);
                double[] output = new double[lastLayer.Size];
                for (int i = 0; i < lastLayer.Size; ++i)
                    output[i] = lastLayer.getNeuronIndex(i).Output;

                Console.Out.WriteLine("GlobalError j: " +j+" :: " +Function.NormSqrt(param.Input[j], output));
                globalError += Function.NormSqrt(param.Input[j], output);
            }
              globalError = globalError / param.Input.Count; 
              Console.Out.WriteLine("GlobalError :!!!!!: "+ globalError ); 
             */ 
            
        }
        private void learnOneSample(int vectNr)
        {
           
            perceptron.calculateOutput(param.Input[vectNr]);
            this.calculateLastLayerErrors(vectNr);//warstwa ostatnia               
            for (int k = perceptron.Size - 2; k >= 0; k--) //pozostale warstwy //!!!!!!!!>=0
                this.calculateHiddenLayerErorrs(vectNr, k);

            for (int k = 1; k < perceptron.Size; k++) //warstwy
                for (int j = 0; j < perceptron.getLayer(k).Size; j++) 
                    for (int i = 0; i < perceptron.getLayer(k - 1).Size; i++) //neurony poprzedzajace
                    {
                        double deltaT = this.calculateDeltaT(k,j,i);
                        this.modifyT(k, j, i, deltaT);
                    }                         
            this.updateTableW();
        }

        private void updateTableW()
        {
            //w: 1 - warstwa neuronu ko�cowego, 2 - pocz�tkowy neuron, 3 - ko�cowy neuron
            
            for (int k = 1; k < this.perceptron.Size; k++)
            {
                Layer layer = this.perceptron.getLayer(k);
                Layer prevLayer = this.perceptron.getLayer(k - 1);
                for (int i = 0; i < layer.Size; i++)
                {
                    Neuron neuron = layer.getNeuronIndex(i);
                    for (int j = 0; j < prevLayer.Size; j++)
                    {
                        Neuron neuron1 = prevLayer.getNeuronIndex(j);
                        this.w1[k, j, i] = this.w[k, j, i];
                        this.w[k, j, i] = neuron.GetT(neuron1);                        
                    }
                }
            }      
        }
        //layerNr - nr warstwy neuronu koncowego, neuronNrJ - neuron koncowy, neuronNrI- neuron poczatkowy
        private void modifyT(int layerNr, int neuronNrJ, int neuronNrI,double deltaT)
        {
            Neuron prevNeuron = perceptron.getLayer(layerNr - 1).getNeuronIndex(neuronNrI);
            double actT = (double)perceptron.getLayer(layerNr).getNeuronIndex(neuronNrJ).getInputHashtable()[prevNeuron];
            double newT;

            newT = actT - deltaT;
            perceptron.getLayer(layerNr).getNeuronIndex(neuronNrJ).getInputHashtable()[prevNeuron] = newT;

        }
        
        private double calculateDeltaT(int layerNr, int neuronNr, int prevNeuronNr)
        {
            if (layerNr == 0)
            {
                return 0.0;
            }
            double deltaT;
            Layer layer = perceptron.getLayer(layerNr);
            Layer layerPrev = perceptron.getLayer(layerNr - 1);
            Neuron neuroni, neuronj;        
            
            int j = neuronNr;
            neuronj = layer.getNeuronIndex(neuronNr);
            int i = prevNeuronNr;   
            neuroni = layerPrev.getNeuronIndex(i);            
            deltaT = 2 * param.Teta * neuronj.D * neuroni.Output
                + param.Alpha * (w[layerNr, i, j] - w1[layerNr, i, j]);               
                      
            return deltaT;
        }
        private void calculateLastLayerErrors(int vectNr)
        {
            Layer layer = perceptron.getLayer(layers - 1);
            Neuron neuron;
            double[] vect = param.Output[vectNr];
            for (int i = 0; i < layer.Size; ++i)
            {
                neuron = layer.getNeuronIndex(i);
                double d, dU;

                dU = vect[i] - neuron.Output;
                d = dU * layer.getFunction().derivative(neuron.InputSum);
                neuron.D = d;
            }

        }
        private void calculateHiddenLayerErorrs(int vectNr, int layerNr)
        {
            Layer layer = perceptron.getLayer(layerNr),
                nextlayer = perceptron.getLayer(layerNr + 1);
            Neuron neuron, neuron1;
            double[] vect = param.Output[vectNr];
            for (int i = 0; i < layer.Size; ++i)
            {
                neuron = layer.getNeuronIndex(i);
                double d, dU, T;

                dU = 0;
                for (int j = 0; j < nextlayer.Size; ++j)
                {
                    neuron1 = nextlayer.getNeuronIndex(j);
                    T = (double)neuron1.getInputHashtable()[neuron];
                    dU += neuron1.D * T;
                }
                d = dU * layer.getFunction().derivative(neuron.InputSum);
                neuron.D = d;
            }

        }
        private double calculateGlobalError(int vectNr)
        {
            Layer lastLayer = perceptron.getLayer(layers - 1);
            double[] output = new double[lastLayer.Size];
            for (int i = 0; i < lastLayer.Size; ++i)
                output[i] = lastLayer.getNeuronIndex(i).Output;
            //Console.Out.WriteLine("GlobalError: " + Function.NormSqrt(param.Input[vectNr], output));
            return Function.NormSqrt(param.Output[vectNr], output);
        }
        public Data.LearningParam Param
        {
            get { return param; }
            set { param = value; }
        }
        public void PrintResultsOfLearning(int i)
        {

            Console.Out.WriteLine();
            Console.Out.Write("WEJSCIE:   ");

            for (int j = 0; j < param.Input[i].Length; ++j)
            {
                Console.Out.Write(param.Input[i][j] + " ");
            }
            Console.Out.WriteLine();

            Console.Out.Write("WZORZEC WYJ�CIA:   ");
            for (int j = 0; j < param.Output[i].Length; ++j)
            {
                Console.Out.Write(param.Output[i][j] + " ");
            }
            Console.Out.WriteLine();

            Console.Out.Write("PO NAUCE:  ");
            perceptron.calculateOutput(param.Input[i]);
            perceptron.PrintOutput();
            Console.Out.WriteLine();
        }
        public void PrintLocalError()
        {
            Console.Out.WriteLine("");
            Console.Out.WriteLine("PRINT LOCAL ERROR:");
            for (int k = 1; k < perceptron.Size; k++) //warstwy
                for (int j = 0; j < perceptron.getLayer(k).Size; j++)
                {
                    for (int i = 0; i < perceptron.getLayer(k - 1).Size; i++) //neurony poprzedzajace
                        Console.Out.Write("\tdT[:" + k + ",od" + i + ",do" + j + "]: " );//+ deltaT[k, i, j]);
                    Console.Out.WriteLine("");
                    Console.Out.WriteLine("Layer: " + k + " neuron: " + j + " d: "
                        + perceptron.getLayer(k).getNeuronIndex(j).D);

                }
        }
        
        /*public void Learn1()
        {                    
            for (int i = 0; i < 5; ++i) 
            {
                for (int j = 0; j < param.Input.Count; ++j)
                    learnOneSample(j);
             
                                 
                //    Console.Out.Write("po uczeniu nr: " + i + " :: wzorzec nr: " + j);
                //    PrintResultsOfLearning(j);
                //}
            }
           

            Console.Out.WriteLine("PO NAUCE WSZYSTKICH WZORCOW:   ");
            for (int k = 0; k < param.Input.Count; ++k)
            {
                PrintResultsOfLearning(k);
            }

        }
        private void learnOneSample1(int vectNr)
        {
            int iter = 30000;
            double globalError = param.Epsilon;
            //while(globalError >= param.Epsilon ) //b��d
            while (iter < 1)
            {
                if (globalError < param.Epsilon) break;

                perceptron.calculateOutput(param.Input[vectNr]);
                this.calculateLastLayerErrors(vectNr);//warstwa ostatnia               
                for (int k = perceptron.Size - 2; k >= 0; k--) //pozostale warstwy //!!!!!!!!>=0
                    this.calculateHiddenLayerErorrs(vectNr, k);

                for (int k = 1; k < perceptron.Size; k++) //warstwy
                    for (int j = 0; j < perceptron.getLayer(k).Size; j++)
                        for (int i = 0; i < perceptron.getLayer(k - 1).Size; i++) //neurony poprzedzajace
                        {
                            double deltaT = this.calculateDeltaT(k, j, i);
                            this.modifyT(k, j, i, deltaT);
                        }

                globalError = calculateGlobalError(vectNr);
                this.updateTableW();

                iter++;
                //if (iter % 100 == 0)
                //{
                 //   Console.Out.Write("iter::::: " + iter + " GLOBAL ERROR: " + globalError);
                //
                //}
                //Console.Out.WriteLine(iter);
            }          


        }*/
       
    }
}
