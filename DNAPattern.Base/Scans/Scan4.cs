using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan4:DNAScan
    {
        private DNASequence scanSequence;
        private TextResult scanResult;

        public Scan4(DNASequence sequenceToScan)
        {
            setScanSequence(sequenceToScan);
        }

        override protected void setScanSequence(DNASequence sequenceToScan)
        {
            this.scanSequence = sequenceToScan;
        }

        override public string getQuestion()
        {
            return "How many of each nucleobase does this segment have?";
        }

        override public void RunScan()
        {
            Match matchOfSubsequence = scanSequence.FindFirstSubsequence(@"ctag");
            var answer = "";
            if (matchOfSubsequence.Success)
            {
                answer = "The subsequence " + matchOfSubsequence.Value + " was found at position " + matchOfSubsequence.Index + " at first.";
            }
            else
            {
                answer = "The subsequence was not found.";
            }
            scanResult = new TextResult(answer);
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
