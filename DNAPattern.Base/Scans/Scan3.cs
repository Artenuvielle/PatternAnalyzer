using System;
using System.Text.RegularExpressions;
using DNAPattern.Base.ScanResults;

namespace DNAPattern.Base.Scans
{
    public class Scan3:DNAScan
    {
        private DNASequence scanSequence;
        private AbsoluteNumberResult scanResult;

        public Scan3(DNASequence sequenceToScan)
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
            scanResult = new AbsoluteNumberResult("The following shares of nucleobases have been found:");
            foreach (char nucleobase in new char[] { 'g', 'a', 'c', 't' })
            {
                int matchOfSubsequence = scanSequence.CountDistinctSubsequences(nucleobase.ToString());
                scanResult.addAbsoluteNumberToResult(nucleobase.ToString(), matchOfSubsequence);
            }
        }

        public override DNAScanResult getScanResult()
        {
            return this.scanResult;
        }
    }
}
