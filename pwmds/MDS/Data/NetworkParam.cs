using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class NetworkParam
    {
        public static int CLASSIFIER = 0, MDS = 1;
        public static String[] TYPES = { "Classifier network", "Multidimensional scaling network" };
        private int layerNumber;
        private List<int> neurons;
        /**if the network is a classifier or mds*/
        private int type;
        //funkcje dla warstw
        private List<Network.Function> functions;
        
        /**The number of layer where is the solution */
        private int solutionLayerNr;


        public List<Network.Function> Functions
        {
            get { return functions; }
            set { functions = value; }
        }

        public List<int> Neurons
        {
            get { return neurons; }
            set { neurons = value; }
        }
        public int LayerNumber
        {
            get { return layerNumber; }
            set { layerNumber = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int SolutionLayerNr
        {
            get { return solutionLayerNr; }
            set { solutionLayerNr = value; }
        }
    }
}
