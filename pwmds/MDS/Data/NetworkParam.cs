using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Data
{
    class NetworkParam
    {
        private int layerNumber;
        private int[] neurons;
        //funkcje dla warstw
        private Network.Function[] functions;


        public Network.Function[] Functions
        {
            get { return functions; }
            set { functions = value; }
        }

        public int[] Neurons
        {
            get { return neurons; }
            set { neurons = value; }
        }
        public int LayerNumber
        {
            get { return layerNumber; }
        }
    }
}
