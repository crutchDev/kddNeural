using System;
using System.IO;
using System.Linq;
using kddNeural.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kddNetwork.Test
{
    [TestClass]
    public class Tests
    {
        private readonly string filename = @"C:\Users\Dasd\Desktop\kddcup.data_10_percent_corrected";
        [TestMethod]
        public void TestGenericOutput()
        {
            const int startLine = 0;
            const int lineCount = 15000;
            var network = new KddNetwork(filename, startLine, lineCount, typeof(GenericConnectionType));

            network.StartLearning();

            var testRows = Row.LoadLinesFromFile(filename, startLine, lineCount);

            int count = 0;
            int errors = 0;
            int notNormal = 0;
            double val = network.TestInput(testRows.First().AsIputArray());
            foreach (var r in testRows)
            {
                var output = network.TestInput(r.AsIputArray());
                //if (val != output) count++;
                if (Math.Round(output) == (double) r.GenConType)
                {
                    count++;
                }
                else
                {
                    errors++;
                }
                if (r.GenConType != GenericConnectionType.normal)
                {
                    notNormal++;
                }
            }
            
        }

        [TestMethod]
        public void TestMiddleSpecificOutput()
        {
            const int startLine = 0;
            const int lineCount = 1000;
            var network = new KddNetwork(filename, startLine, lineCount, typeof(MiddleSpecificConnectionType));

            //network.StartLearning();
        }

        [TestMethod]
        public void TestSpecificOutput()
        {
            const int startLine = 0;
            const int lineCount = 1000;
            var network = new KddNetwork(filename, startLine, lineCount, typeof(SpecificConnectionType));

            //network.StartLearning();
        }
    }
}
