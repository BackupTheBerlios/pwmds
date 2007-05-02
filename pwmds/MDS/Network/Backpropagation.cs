using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;



namespace MDS.Network
{
    class Backpropagation
    {
        private Perceptron perceptron;
        private Data.LearningParam param;
        private int layers;
        //1 - warstwa neuronu koñcowego, 2 - pocz¹tkowy neuron, 3 - koñcowy neuron       
        private double[, ,] w, w1;   //w(t) i w(t-1)
        //mo¿e by te tavlice zainicjowac wagami pocz¹tkowymi
        private double globalError, prevError;
        private Thread learnThread;
        
        private bool endthread;
        private int iter;

        private TextBox _tboxError;
        delegate void SetTextCallback(string text);
        


        public Backpropagation(Perceptron perceptron, Data.LearningParam param)
        {
            this.perceptron = perceptron;
            this.param = param;
            layers = perceptron.Size;

            int n = perceptron.MaxLayerSize;            
            w = new double[layers, n, n];
            w1 = new double[layers, n, n];
        }

        public void StartLearn()
        {
            learnThread = new Thread( new ThreadStart(learn));
            perceptron.SetRandomWeights();
            iter = 0;
            learnThread.Start(); 
        }

        public void ContinueLearn()
        {
            learnThread = new Thread(new ThreadStart(learn));
            learnThread.Start();
        }

        public void StopLearn()
        {
            endthread = true;
        }

 /*       public void Start()
        {
            iter = 100000;
            prevError = 0;
            globalError = 0;
            Console.Out.WriteLine("Start backpropagation...   ");
            perceptron.SetRandomWeights();
            //endthread = false;
        }
        public bool NextIteration()
        {
            globalError = 0;
            for (int j = 0; j < param.Input.Count; ++j)
            {
                learnOneSample(j);
                perceptron.calculateOutput(param.Input[j]);
                globalError += calculateGlobalError(j);
            }
            globalError = globalError / param.Input.Count;
            //tboxError.Text = tboxError.Text + "\n" + globalError;
            if (globalError < param.Epsilon) 
                return false;
            if (prevError != 0 && globalError > 1.04 * prevError)
                return false;
            prevError = globalError;

            if (iter % 10000 == 0)
            {
                Console.Out.WriteLine("iter::::: " + (100000 - iter) + " GLOBAL ERROR: " + globalError);
            }
            iter--;
            return true;
        }
  */ 

        private void learn()
        {
            if (param.KFoldSamples == 0)
                learnFunction(-1, -1);
            else
                kFoldCrossValidation();
        }


        private void learnFunction( int startTestId, int endTestId )
        {
            //int startIter = 100000;
            //iter = startIter;
            double prevError = 0;
            String text;
            globalError = 0;
            Console.Out.WriteLine("Start backpropagation...   ");
            
            endthread = false;
            while (!endthread) //(iter>0)
            {
                globalError =0;
                for (int j = 0; j < param.Input.Count; ++j)
                {
                    if (j >= startTestId && j <= endTestId)
                        continue;
                    learnOneSample(j);           
                    perceptron.calculateOutput(param.Input[j]);
                    globalError += calculateGlobalError(j);
                }
                globalError = globalError / param.Input.Count;
                //tboxError.Text = tboxError.Text + "\n" + globalError;
                if (globalError == Double.NaN)
                    break;
                if (globalError < param.Epsilon) 
                    break;
                if (prevError != 0 && globalError > 1.04 * prevError)
                    this.param.Alpha = 0 ;
                prevError = globalError;

                if (iter % 1000 == 0)
                {
                    text = "iter::::: " + (iter) + " GLOBAL ERROR: " + globalError;
                    Console.Out.WriteLine(text);
                    setErrorText(text + "\n");
                }
                iter++;
            }
            
            text = "Liczba iteracji " + (iter) + " GLOBAL ERROR: " + globalError;
            Console.Out.WriteLine( text );
            text += "\nKONIEC OBLICZEÑ";
            setErrorText(text);
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

        private void setErrorText(String text)
        {
            if (this._tboxError.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setErrorText);
                this._tboxError.Invoke(d, new object[] { text });
            }
            else
            {
                this._tboxError.AppendText(text);
            }

        }

        private void kFoldCrossValidation()
        {
            int kFoldSamples = param.KFoldSamples;
            int oneSetSize = (int)Math.Floor((double)param.Input.Count / kFoldSamples );
            int start, end;
            for (int i = 0; i < kFoldSamples; ++i)
            {
                start = i * oneSetSize;
                end = start+oneSetSize - 1;
                if( end > param.Input.Count)
                    end = param.Input.Count;
                learnFunction(start, end);
            }
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
            //w: 1 - warstwa neuronu koñcowego, 2 - pocz¹tkowy neuron, 3 - koñcowy neuron
            
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
            double deltaT, teta;
            Layer layer = perceptron.getLayer(layerNr);
            Layer layerPrev = perceptron.getLayer(layerNr - 1);
            Neuron neuroni, neuronj;        
            
            int j = neuronNr;
            neuronj = layer.getNeuronIndex(neuronNr);
            int i = prevNeuronNr;   
            neuroni = layerPrev.getNeuronIndex(i);
            if (param.OneTeta)
                teta = param.Teta;
            else
                teta = 1 / layer.getNeuronList().Count;
            deltaT = 2 * teta * neuronj.D * neuroni.Output
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

                dU = neuron.Output - vect[i];
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
            {
                output[i] = lastLayer.getNeuronIndex(i).Output;
                //diff = output[i] - param.Output[vectNr];
                //error += Math.Pow(
            }
            //Console.Out.WriteLine("GlobalError: " + Function.NormSqrt(param.Input[vectNr], output));

            //return Function.NormSqrt(param.Output[vectNr], output);
            return 1.0 / 2.0 * Function.Square(param.Output[vectNr], output);
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

            Console.Out.Write("WZORZEC WYJŒCIA:   ");
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
            //while(globalError >= param.Epsilon ) //b³¹d
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
        public TextBox TBoxError
        {
            set { _tboxError = value; }
        }
        public double GlobalError
        {
            get { return globalError; }
        }

       
        public Data.LearningParam Param
        {
            get { return param; }
            set { param = value; }
        }
        
    }
}
