using System;
using System.IO;
using System.Linq;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace kddNeural
{
    public class KddNetwork
    {
        public long FromLine { get; set; }
        public long LineCount { get; set; }
        public string FilePath { get; set; }
        public Type OutputKind { get; set; }
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
            var rows = LoadLinesFromFile();
            const double sigmoidAlphaValue = 2;
            var c = rows[0].AsIputArray().Length;
            var network = new ActivationNetwork(new BipolarSigmoidFunction(sigmoidAlphaValue), 41, rows.Length, OutputTypesCount - 1);
            var teacher = new BackPropagationLearning(network)
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

            teacher.RunEpoch(input, output);
            var a = network.Compute(input[0]);
        }

        public int OutputTypesCount { get; set; }

        public void TestInput(long testLine, string filePath)
        {
            throw new NotImplementedException();
        }

        private Row[] LoadLinesFromFile()
        {
            using (var f = new StreamReader(FilePath))
            {
                //skip to needed line
                for (int i = 0; i < FromLine; i++) f.ReadLine();

                var rows = new Row[LineCount];
                //read lines to string
                for (int i = 0; i < LineCount; i++)
                {
                    var readLine = f.ReadLine();
                    if (readLine != null)
                    {
                        var readString = readLine.Split(',');
                        rows[i] = new Row(readString);
                    }
                    else
                    {
                        throw new FileLoadException("File is too short!");
                    }
                }

                return rows;
            }
        }

    }
}
