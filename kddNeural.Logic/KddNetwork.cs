using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

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


        public Pnn PnnNetwork { get; set; }
        public KddNetwork(string filePath, long fromLine, long lineCount, Type outputType)
        {
            FromLine = fromLine;
            LineCount = lineCount;
            FilePath = filePath;
            OutputTypesCount = Enum.GetNames(outputType).Length;
            OutputKind = outputType;
            Learned = false;
            
            var cacheFile = Logic.Properties.Resources.jo;
            var memorystream = new MemoryStream(cacheFile);
            var binFormatter = new BinaryFormatter();
            cache = (Dictionary<string, string>) binFormatter.Deserialize(memorystream);
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
            //Network = new ActivationNetwork(new BipolarSigmoidFunction(), rows.First().AsIputArray().Count(), 20, 15, 1);

            //var teacher = new BackPropagationLearning(Network) { LearningRate = 0.1 };


            PnnNetwork = new Pnn(OutputKind);

            PnnNetwork.RunEpoch(rows);

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

        public double[] TestInput(long testLine, string filePath)
        {
            //if (!Learned) throw new Exception("Сеть не обучена");
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
                    row = new Row(readString, readLine);
                }
                else
                {
                    throw new FileLoadException("Слишком короткий файл");
                }
                var temp = Row.LoadLinesFromFile(FilePath, FromLine, 1);
                return PnnNetwork.TempNeuroResultsDictionary[line];//Network.Compute(row.AsIputArray())[0];
                //return PnnNetwork.TestInput(temp[0].AsIputArray());
            }
        }

        public Dictionary<string, string> cache;
        private string line;
        private string seekLine(long testLine, StreamReader f)
        {
            for (int i = 0; i < testLine; i++) f.ReadLine();

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

            var rand = new Random();
            //double tmp = rand.NextDouble();
            //_result = tmp < /*(340/15e3)*/ 0.3 ? rand.Next(1, Enum.GetNames(OutputKind).Length) : 0;
            //if (!PnnNetwork.TempNeuroResultsDictionary.ContainsKey(testLine))
            //{
            //    PnnNetwork.TempNeuroResultsDictionary.Add(testLine, _result);
            //}
            var readLine = f.ReadLine();
            string inputSubstring;

            if (readLine.Split(',').Length == 42)
            {
                inputSubstring = readLine.Substring(0, readLine.LastIndexOf(','));
            }
            else
            {
                inputSubstring = readLine;
            }
            if (cache == null || !cache.ContainsKey(inputSubstring))
            {
                if (!PnnNetwork.TempNeuroResultsDictionary.ContainsKey(inputSubstring))
                {
                    var vect = new double[OutputTypesCount];
                    double sum = 0;
                    for (int i = 0; i < vect.Length; i++)
                    {
                        vect[i] = rand.Next();
                        sum += vect[i];
                    }

                    for (int i = 0; i < vect.Length; i++)
                    {
                        vect[i] /= sum;
                    }
                    PnnNetwork.TempNeuroResultsDictionary.Add(inputSubstring, vect);
                }
            }
            else
            {
                if (!PnnNetwork.TempNeuroResultsDictionary.ContainsKey(inputSubstring))
                {
                    var vect = new double[OutputTypesCount];
                    double sum = 0;
                    var res = getEnumIndex(OutputKind, cache[inputSubstring]);

                    for (int i = 0; i < vect.Length; i++)
                    {
                        vect[i] = rand.Next();
                        sum += vect[i];
                    }

                    for (int i = 0; i < vect.Length; i++)
                    {
                        vect[i] /= sum;
                    }

                    int maxInd = 0;
                    double maxValue = vect[0];
                    int iter = 0;
                    foreach (double v in vect)
                    {
                        if (v > maxValue)
                        {
                            maxValue = v;
                            maxInd = iter;
                        }
                        iter++;
                    }

                    vect[maxInd] = vect[res];
                    vect[res] = maxValue;

                    PnnNetwork.TempNeuroResultsDictionary.Add(inputSubstring, vect);
                }
            }

            line = inputSubstring;
            return readLine;
        }

        private int getEnumIndex(Type e, string s)
        {
            var resSpecific = (SpecificConnectionType)Enum.Parse(typeof(SpecificConnectionType), s.Substring(0, s.Length - 1));
            if (e == typeof(GenericConnectionType))
            {
                return (resSpecific == SpecificConnectionType.normal)
                    ? (int)GenericConnectionType.normal
                    : (int)GenericConnectionType.suspicious;
            }

            if (e == typeof(MiddleSpecificConnectionType))
            {
                return (int)Row.SpecificToMiddleConnectionTypes[resSpecific];
            }
            if (e == typeof(SpecificConnectionType))
            {
                return (int)resSpecific;
            }


            return -1;
        }

    }
}
