using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan7:DNAScan
    {
        private DNASequence scanSequence;
        private DNASequenceResult scanResult;

        public Scan7(DNASequence sequenceToScan)
        {
            setScanSequence(sequenceToScan);
        }

        override protected void setScanSequence(DNASequence sequenceToScan)
        {
            this.scanSequence = sequenceToScan;
        }

        override public string getQuestion()
        {
            return "What's the complementary sequence for the entire DNA strand?";
        }

        override public void RunScan()
        {
            var answer = "The complimentary sequence is:";
            scanResult = new DNASequenceResult(answer,scanSequence.GetComplimentarySequence());
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
