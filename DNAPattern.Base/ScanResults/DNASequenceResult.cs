using System;
using System.Collections.Generic;

namespace DNAPattern.Base.ScanResults
{
    public class DNASequenceResult:DNAScanResult
    {
        private string answer;
        private DNASequence resultSequence;

        public DNASequenceResult(string returningAnswer, DNASequence returningSequence)
        {
            this.answer = returningAnswer;
            this.resultSequence = returningSequence;
        }

        public DNASequence getSequence()
        {
            return resultSequence;
        }

        override public string getAnswer()
        {
            return this.answer;
        }
    }
}
