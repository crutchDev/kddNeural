using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kddNeural.Logic
{
    [Serializable]
    public class Pnn
    {
        private Neuron[] _inputNeurons;
        private readonly Type _outType;
        private double[] _resCounts;
        
        public Pnn(Type outputType)
        {
            _outType = outputType;
        }

        public void RunEpoch(Row[] input)
        {
            _inputNeurons = new Neuron[input.Length];
            _resCounts = new double[Enum.GetNames(_outType).Length];
            
            for (int i = 0; i < input.Count(); i++)
            {
                _inputNeurons[i] = new Neuron
                {
                    Input = input[i].AsIputArray(),
                    Res = (int)input[i].ResType(_outType)
                };
                TempNeuroResultsDictionary[i] = _inputNeurons[i].Res;
                _resCounts[_inputNeurons[i].Res]++;
            }
            var maxElems = new double[input[0].AsIputArray().Length];
            var totalMax = _inputNeurons.Select(x => x.Input.Max()).Max();
            for (int i = 0; i < maxElems.Length; i++)
            {
                maxElems[i] = _inputNeurons.Select(x => x.Input[i]).Max();
            }

            //normalization
            
            foreach (var n in _inputNeurons)
            {
                //n.Input = n.Input.Select(x => x/totalMax).ToArray();
                n.Input = n.Input.Zip(maxElems, (x, y) => (y != 0) ? x/y : 0).ToArray();
            }
        }

        public double TestInput(double[] input)
        {
            if (_resCounts == null) throw new Exception("Нейронная сеть не обучена");
            var resSums = new double[Enum.GetNames(_outType).Length];

            for (int i = 0; i < _inputNeurons.Count(); i++)
            {
                double curSum = _inputNeurons[i].Input.Zip(input, (x, y) => x * y).Sum();
                resSums[_inputNeurons[i].Res] += curSum;
            }

            int maxIndex = 0;
            
            for (int i = 0; i < resSums.Length; i++)
            {
                resSums[i] =  resSums[i] / ((_resCounts[i] != 0) ? _resCounts[i] : 1);
                if (resSums[i] > resSums[maxIndex]) maxIndex = i;
            }

            return maxIndex;
        }
        public readonly Dictionary<long, double> TempNeuroResultsDictionary = new Dictionary<long, double>();
    }

    [Serializable]
    internal class Neuron
    {
        public int Res;
        public double[] Input;
    }
}