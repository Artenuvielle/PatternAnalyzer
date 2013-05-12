using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan5:DNAScan
    {
        private DNASequence scanSequence;
        private AbsoluteNumberResult scanResult;

        public Scan5(DNASequence sequenceToScan)
        {
            setScanSequence(sequenceToScan);
        }

        override protected void setScanSequence(DNASequence sequenceToScan)
        {
            this.scanSequence = sequenceToScan;
        }

        override public string getQuestion()
        {
            return "Does this segment have more purines than pyrimidines?";
        }

        override public void RunScan()
        {
            int numberOfPurines = scanSequence.CountDistinctSubsequences("[ag]");
            int numberOfPyrimidines = scanSequence.CountDistinctSubsequences("[ct]");
            string comparisonResult = (numberOfPurines > numberOfPyrimidines)?"Yes, there are more purines than pyrimidines.":"No, there are more pyrimidines than purines.";
            scanResult = new AbsoluteNumberResult(comparisonResult + " The following shares have been found:");
            scanResult.addAbsoluteNumberToResult("purines", numberOfPurines);
            scanResult.addAbsoluteNumberToResult("pyrimidines", numberOfPyrimidines);
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
