using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan1:DNAScan
    {
        private DNASequence scanSequence;
        private TextResult scanResult;

        public Scan1(DNASequence sequenceToScan)
        {
            setScanSequence(sequenceToScan);
        }

        override protected void setScanSequence(DNASequence sequenceToScan)
        {
            this.scanSequence = sequenceToScan;
        }

        override public string getQuestion()
        {
            return "Three distinct sequences of \"GGG\" within any 1000-nucleobases signify an elevated risk to acquiring Tyberius syndrome. Based on the given DNA segment, is this person at such risk?";
        }

        override public void RunScan()
        {
            int numberOfSubsequences = scanSequence.CountDistinctSubsequences(@"ggg");
            var answerPhrase = "The subsequence \"GGG\" was found " + numberOfSubsequences + " times in the given DNA segment and the risk to acquiring Tyberius syndrome is ";
            answerPhrase += (numberOfSubsequences < 3) ? "not elevated." : "significantly elevated.";
            this.scanResult = new TextResult(answerPhrase);
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
