using System;
using System.IO;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace kddNeural.Logic
{
    public class KddNetwork
    {
        public long FromLine { get; set; }
        public long LineCount { get; set; }
        public string FilePath { get; set; }
        public Type OutputKind { get; set; }

        private ActivationNetwork Network { get; set; }
        public KddNetwork(string filePath, long fromLine, long lineCount, Type outputType)
        {
            FromLine = fromLine;
            LineCount = lineCount;
            FilePath = filePath;
            OutputTypesCount = Enum.GetNames(outputType).Length;
            OutputKind = outputType;
        }

        public void StartLearning()
        {
            var rows = Row.LoadLinesFromFile(FilePath, FromLine, LineCount);
            const double sigmoidAlphaValue = 2;
            var c = rows[0].AsIputArray().Length;
            Network = new ActivationNetwork(new BipolarSigmoidFunction(sigmoidAlphaValue), 41, OutputTypesCount, 1);
            var teacher = new BackPropagationLearning(Network)
            {
                LearningRate = 0.1,
                Momentum = 0
            };

            var input = new double[rows.Length][];
            var output = new double[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                input[i] = rows[i].AsIputArray();
                output[i] = new double[1];
                output[i][0] = rows[i].ResType(OutputKind);
            }
            for (int i = 0; i < 5; i++)
            {
                teacher.RunEpoch(input, output);
            }
            var a = Network.Compute(input[0]);
        }

        public int OutputTypesCount { get; set; }

        public void TestInput(long testLine, string filePath)
        {
            throw new NotImplementedException();
        }

        public double TestInput(double[] input)
        {
            return Network.Compute(input)[0];
        }
    }
}
