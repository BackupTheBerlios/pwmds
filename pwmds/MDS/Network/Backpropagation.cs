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
        //1 - warstwa neuronu koñcowego, 2 - pocz¹tkowy neuron, 3 - koñcowy neuron
        private double[,,] deltaT;

        public Backpropagation( Perceptron perceptron, Data.LearningParam param)
        {
            this.perceptron = perceptron;
            this.param = param;
            layers = perceptron.Size;

            int n = perceptron.MaxLayerSize;
            deltaT = new double[layers, n, n];

        }

        public void Learn()
        {
        }

        private void learnOne( int vectNr )
        {
            int iter = 10;
            //double d;
            while(iter-- != 0) //b³¹d
            {
                perceptron.calculateOutput(param.Input[vectNr]);
                //warstwa ostatnia
                this.calculateLastLayerErrors(vectNr);
                //pozostale warstwy
                for (int k = perceptron.Size - 2; k >= 0; k--)
                    this.calculateHiddenLayerErorrs(vectNr, k);
                
                for (int k = perceptron.Size - 1; k >= 0; k--)
                    this.calculateDeltaT(k);

                for (int k = 1; k < perceptron.Size; k++) //warstwy
                    for (int j = 0; j < perceptron.getLayer(k).Size; j++)
                        for (int i = 0; i < perceptron.getLayer(k - 1).Size; i++) //neurony poprzedzajace
                            this.modifyT(k, j, i);                
            }
 
        }
        //layerNr - nr warstwy neuronu koncowego, neuronNrJ - neuron koncowy, neuronNrI- neuron poczatkowy
        private void modifyT(int layerNr, int neuronNrJ, int neuronNrI)
        {

        }

        private void calculateLastLayer()
        {
            return;
        }
        private void calculateDeltaT(int layerNr)
        {
            if(layerNr == 0)
                return;

            Layer layer = perceptron.getLayer(layerNr);
            Layer layerPrev = perceptron.getLayer(layerNr-1);
            Neuron neuroni,neuronj;
            double dj, fEi;          

            for (int j = 0; j < layer.Size; ++j) 
            {
                neuronj = layer.getNeuronIndex(j);
                dj = neuronj.D;
                for(int i=0; i < layerPrev.Size; i++)
                {
                    neuroni = layerPrev.getNeuronIndex(i);                    
                    fEi = layerPrev.getFunction().calculate(neuroni.InputSum);
                    this.deltaT[layerNr, i, j] = param.Alpha * this.deltaT[layerNr, i, j]
                        + (1 - param.Alpha) * dj * fEi;
                }

            }

        }
        private void calculateLastLayerErrors( int vectNr )
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
                nextlayer = perceptron.getLayer(layerNr+1);
            Neuron neuron,neuron1;
            double[] vect = param.Output[vectNr];            
            for (int i = 0; i < layer.Size; ++i)
            {
                neuron = layer.getNeuronIndex(i);
                double d, dU,T;

                dU = 0;
                for (int j = 0; j < nextlayer.Size; j++)
                {
                    neuron1 = nextlayer.getNeuronIndex(j);
                    T = (double) neuron1.getInputHashtable()[neuron1];
                    dU += neuron1.D * T;
                }
                d = dU * layer.getFunction().derivative(neuron.InputSum);
                neuron.D = d;
            }

        }

        public Data.LearningParam Param
        {
            get { return param; }
            set { param = value; }
        }
    }
}
