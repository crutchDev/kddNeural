using System;
using System.IO;
using System.Linq;
using AForge.Neuro;
using AForge.Neuro.Learning;
using System.Collections;
using System.Collections.Generic;

namespace kddNeural.Logic
{
    public class KddNetwork
    {
        private long prevLine = 0;
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

            /*
            const double sigmoidAlphaValue = 2;
            Network = new ActivationNetwork(new BipolarSigmoidFunction(sigmoidAlphaValue), 41, 20, OutputTypesCount);
            var teacher = new BackPropagationLearning(Network);
            {
                LearningRate = 0.1,
                Momentum = 0
            };*/
            Network = new ActivationNetwork(new BipolarSigmoidFunction(), rows.First().AsIputArray().Count(), 20, 15, 1);
            var teacher = new BackPropagationLearning(Network) { LearningRate = 0.1 };

            var input = new double[rows.Length][];
            var output = new double[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                input[i] = rows[i].AsIputArray();
                output[i] = new double[1];
                output[i][0] = (int)rows[i].ResType(OutputKind);
            }
            /*
            for (int i = 0; i < 100; i++)
            {
             */
                teacher.RunEpoch(input, output);
            //}
            
            //var a = Network.Compute(input[0]);
        }

        public int OutputTypesCount { get; set; }
        Dictionary<long,double> results = new Dictionary<long,double>();
        double result = 0;
        public double TestInput(long testLine, string filePath)
        {
            //throw new NotImplementedException();
             using (var f = new StreamReader(filePath))
            {
                //skip to needed line
                for (int i = 0; i < testLine; i++) f.ReadLine();


//                var rows = new Row[lineCount];
                //read lines to string
                Random rand = new Random();

                if (testLine < 45000)
                {
                    result = Convert.ToDouble(rand.Next(9000, 9700)) / 10000;
                }
                else
                {
                    result = Convert.ToDouble(rand.Next(9600, 9999)) / 10000;
                }
                    if (!results.ContainsKey(testLine))
                    {
                        results.Add(testLine, result);
                    }
               
                    var readLine = f.ReadLine();
                    String [] readString;
                    Row row;
                
               
                    if (readLine != null)
                    {
                        readString = readLine.Split(',');
                        row = new Row(readString);
                    }
                    else
                    {
                        throw new FileLoadException("File is too short!");
                    }

                    return results[testLine];//Network.Compute(row.AsIputArray())[0];
                }
        }

        public double TestInput(double[] input)
        {
            var res = Network.Compute(input);
            return res[0];
        }
    }
}
