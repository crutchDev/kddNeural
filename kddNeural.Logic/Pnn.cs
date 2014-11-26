using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kddNeural.Logic
{
    public class Pnn
    {
        private Neuron[][] neurons;
        private Type outType;
        private double[] resCounts;
        public Pnn(Type outputType)
        {
            neurons = new Neuron[2][];
            neurons[1] = new Neuron[Enum.GetNames(outputType).Length];
            outType = outputType;
        }

        public void runEpoch(Row[] input)
        {
            neurons[0] = new Neuron[input.Length];
            resCounts = new double[input.Length];

            for (int i = 0; i < input.Count(); i++)
            {
                neurons[0][i] = new Neuron()
                {
                    Input = input[i].AsIputArray(),
                    Res = (int)input[i].ResType(outType)
                };
                resCounts[neurons[0][i].Res]++;
            }
        }

        public double testInput(double[] input)
        {
            if (resCounts == null) throw new Exception("Нейронная сеть не обучена");
            var resSums = new double[Enum.GetNames(outType).Length];

            for (int i = 0; i < neurons[0].Count(); i++)
            {
                double curSum = neurons[0][i].Input.Zip(input, (x, y) => x * y).Sum();
                resSums[neurons[0][i].Res] += curSum;

            }
            int maxIndex = 0;
            for (int i = 0; i < resSums.Length; i++)
            {
                resSums[i] /= resCounts[i];
                if (resSums[i] > resSums[maxIndex]) maxIndex = i;
            }

            return maxIndex;
        }
    }
    [Serializable]
    internal class Neuron
    {
        public int Res;
        public IEnumerable<double> Input;
    }
}
