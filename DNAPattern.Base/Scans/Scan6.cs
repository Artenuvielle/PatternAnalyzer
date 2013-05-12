using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan6:DNAScan
    {
        private DNASequence scanSequence;
        private TextResult scanResult;

        public Scan6(DNASequence sequenceToScan)
        {
            setScanSequence(sequenceToScan);
        }

        override protected void setScanSequence(DNASequence sequenceToScan)
        {
            this.scanSequence = sequenceToScan;
        }

        override public string getQuestion()
        {
            return "Four purines followed by four pyrimidines have been shown to have a strong correlationwith the early onset of Frømingen's dischrypsia. Does this DNA strand show evidence for this correlation?";
        }

        override public void RunScan()
        {
            Match matchOfSubsequence = scanSequence.FindFirstSubsequence(@"[ag]{4}[ct]{4}");
            var answer = "";
            if (matchOfSubsequence.Success)
            {
                answer = "The subsequence " + matchOfSubsequence.Value + " was found at position " + matchOfSubsequence.Index + ". This shows evidence for the correlation.";
            }
            else
            {
                answer = "No matching subsequence was found. No evidence for the correlation was found.";
            }
            scanResult = new TextResult(answer);
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
