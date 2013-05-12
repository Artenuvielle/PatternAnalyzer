using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan2:DNAScan
    {
        private DNASequence scanSequence;
        private TextResult scanResult;

        public Scan2(DNASequence sequenceToScan)
        {
            setScanSequence(sequenceToScan);
        }

        override protected void setScanSequence(DNASequence sequenceToScan)
        {
            this.scanSequence = sequenceToScan;
        }

        override public string getQuestion()
        {
            return "The sequence \"CAG\" followed by exactly one \"C\" or one \"G\" and then not followed by T in the next 2 slots signifies brown eyes. Does this person have brown eyes?";
        }

        override public void RunScan()
        {
            Match matchOfSubsequence = scanSequence.FindFirstSubsequence(@"cag[cg][^t]{2}");
            var answer = "";
            if (matchOfSubsequence.Success)
            {
                answer = "The subsequence " + matchOfSubsequence.Value + " was found at position " + matchOfSubsequence.Index + ". This means the person should have brown eyes.";
            }
            else
            {
                answer = "No matching subsequence was found. This means the person should have no brown eyes.";
            }
            scanResult = new TextResult(answer);
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
