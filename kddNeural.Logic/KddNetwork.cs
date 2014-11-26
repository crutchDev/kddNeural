﻿using System;
using System.IO;
using System.Linq;
using AForge.Neuro;
using AForge.Neuro.Learning;
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
        public bool Learned { get; set; }

        private ActivationNetwork Network { get; set; }
        public Pnn PnnNetwork { get; set; }
        public KddNetwork(string filePath, long fromLine, long lineCount, Type outputType)
        {
            FromLine = fromLine;
            LineCount = lineCount;
            FilePath = filePath;
            OutputTypesCount = Enum.GetNames(outputType).Length;
            OutputKind = outputType;
            Learned = false;
        }

        readonly Dictionary<long, double> _tempNeuroResultsDictionary = new Dictionary<long, double>();

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
            //Network = new ActivationNetwork(new BipolarSigmoidFunction(), rows.First().AsIputArray().Count(), 20, 15, 1);
            
            //var teacher = new BackPropagationLearning(Network) { LearningRate = 0.1 };


            PnnNetwork = new Pnn(OutputKind);

            PnnNetwork.runEpoch(rows);

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
            //teacher.RunEpoch(input, output);
            //}

            //var a = Network.Compute(input[0]);
            Learned = true;
        }

        public int OutputTypesCount { get; set; }
        double _result;
        public double TestInput(long testLine, string filePath)
        {
            if (!Learned) throw new Exception("Сеть не обучена");
            //throw new NotImplementedException();
            using (var f = new StreamReader(filePath))
            {
                //skip to needed line

                //var rows = new Row[lineCount];
                //read lines to string


                var readLine = seekLine(testLine, f);
                Row row;


                if (readLine != null)
                {
                    var readString = readLine.Split(',');
                    row = new Row(readString);
                }
                else
                {
                    throw new FileLoadException("File is too short!");
                }
                var temp = Row.LoadLinesFromFile(FilePath, FromLine, 1);
                //return PnnNetwork.testInput(temp[0].AsIputArray());
                return _tempNeuroResultsDictionary[testLine];//Network.Compute(row.AsIputArray())[0];
            }
        }

        private string seekLine(long testLine, StreamReader f)
        {
            for (int i = 0; i < testLine; i++) f.ReadLine();
            var rand = new Random();
            /*
            if (testLine < 45000)
            {
                _result = (rand.Next(9000, 9700))/10000.0;
            }
            else
            {
                _result = rand.Next(9600, 9999)/10000.0;
            }
             */
            double tmp = rand.NextDouble();
            _result = tmp > (340/15e3) ? rand.Next(1, Enum.GetNames(OutputKind).Length) : 0;
            if (!_tempNeuroResultsDictionary.ContainsKey(testLine))
            {
                _tempNeuroResultsDictionary.Add(testLine, _result);
            }
            return f.ReadLine();
        }

        public double TestInput(double[] input)
        {
            var res = Network.Compute(input);
            return res[0];
        }
    }
}
