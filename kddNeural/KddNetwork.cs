using  System;
using System.Security.Cryptography.X509Certificates;
using  AForge.Neuro;

namespace kddNeural
{
    public class KddNetwork
    {
        public long FromLine { get; set; }
        public long LineCount { get; set; }
        public bool Active { get; set; }
        public string FilePath { get; set; }
        public KddNetwork(string filePath, long fromLine, long count)
        {
            FromLine = fromLine;
            LineCount = count;
            FilePath = filePath;
        }

        public void StartLearning()
        {
            Active = true;
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        internal void TestInput(long testLine, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
