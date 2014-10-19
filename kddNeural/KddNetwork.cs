using System;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using AForge.Neuro;

namespace kddNeural
{
    public class KddNetwork
    {
        public long FromLine { get; set; }
        public long LineCount { get; set; }
        public bool Active { get; set; }
        public string FilePath { get; set; }
        private Thread T { get; set; }
        public KddNetwork(string filePath, long fromLine, long count)
        {
            FromLine = fromLine;
            LineCount = count;
            FilePath = filePath;
        }

        public void StartLearning()
        {
            Active = true;
            T = new Thread(learnThreadProcedure);
            T.Start();
            //throw new NotImplementedException();
        }

        public void Cancel()
        {
            Active = false;
            if (T.IsAlive)
                T.Abort();
        }

        public void TestInput(long testLine, string filePath)
        {
            throw new NotImplementedException();
        }

        private struct Row
        {
            public Row(string[] row)
            {
                Duration = int.Parse(row[0]);
                Output = RowHelper.GetEnumFromString<Protocol>(row[1]);
                Input = RowHelper.GetEnumFromString<Protocol>(row[2]);

                GenConType = RowHelper.GetGenericConnectionType(row[row.Length]);
                MidConType = RowHelper.GetMiddleSpecificConnectionType(row[row.Length]);
                ConType = RowHelper.GetEnumFromString<SpecificConnectionType>(row[row.Length]);

                intParams = new int[22];
                for (int i = 0; i < 20; i++)
                {
                    intParams[i] = int.Parse(row[i + 4]);
                }
                intParams[20] = int.Parse(row[31]);
                intParams[21] = int.Parse(row[32]);
                contParams = new double[15];
                for (int i = 0; i < 7; i++)
                {
                    contParams[i] = double.Parse(row[24 + i]);
                }
                for (int i = 0; i < 8; i++)
                {
                    contParams[i + 7] = double.Parse(row[33 + i]);
                }
                
            }
            public int Duration;
            public Protocol Output;
            public Protocol Input;
            public readonly int[] intParams; //4 - 23, 31, 32
            public readonly double[] contParams; //24 - 30, 33-40

            public GenericConnectionType GenConType;
            public MiddleSpecificConnectionType MidConType;
            public SpecificConnectionType ConType;

        }

        private void learnThreadProcedure()
        {
            var learnExamples = new string[LineCount][];

            using (var f = new StreamReader(FilePath))
            {
                //skip to needed line
                for (int i = 0; i < FromLine && Active; i++) f.ReadLine();

                //read lines to string
                for (int i = 0; i < LineCount && Active; i++) learnExamples[i] = f.ReadLine().Split(',');

                var a = (from s in learnExamples select s[2]).Distinct().ToArray();
                var b = (from s in learnExamples select s[3]).Distinct().ToArray();
            }
            Active = false;
        }
    }
}
