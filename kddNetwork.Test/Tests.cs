using System;
using kddNeural.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kddNetwork.Test
{
    [TestClass]
    public class Tests
    {
        private const int LineCount = 15000;
        private const int StartLine = 0;
        private readonly string filename = @"C:\Users\Dasd\Desktop\kddcup.data_10_percent_corrected";
        [TestMethod]
        public void TestGenericOutput()
        {
            var network = new KddNetwork(filename, StartLine, LineCount, typeof(GenericConnectionType));

            network.StartLearning();

            var testRows = Row.LoadLinesFromFile(filename, StartLine, LineCount);

            int count = 0;
            int errors = 0;
            int notNormal = 0;
            foreach (var r in testRows)
            {
                var output = network.TestInput(r.AsIputArray());
                //if (val != output) count++;
                if ((int)output == (int)r.GenConType)
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
            var network = new KddNetwork(filename, StartLine, LineCount, typeof(MiddleSpecificConnectionType));

            network.StartLearning();

            var testRows = Row.LoadLinesFromFile(filename, StartLine, LineCount);

            int count = 0;
            int errors = 0;
            int notNormal = 0;
            foreach (var r in testRows)
            {
                var output = network.TestInput(r.AsIputArray());
                //if (val != output) count++;
                if ((int)output == (int)r.MidConType)
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
        public void TestSpecificOutput()
        {
            var network = new KddNetwork(filename, StartLine, LineCount, typeof(SpecificConnectionType));

            network.StartLearning();

            var testRows = Row.LoadLinesFromFile(filename, StartLine, LineCount);

            int count = 0;
            int errors = 0;
            int notNormal = 0;
            foreach (var r in testRows)
            {
                var output = network.TestInput(r.AsIputArray());
                //if (val != output) count++;
                if ((int)output == (int)r.ConType)
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
    }
}
