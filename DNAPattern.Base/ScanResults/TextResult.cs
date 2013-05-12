using System;

namespace DNAPattern.Base.ScanResults
{
    public class TextResult:DNAScanResult
    {
        private string answer;

        public TextResult(string returningAnswer)
        {
            this.answer = returningAnswer;
        }

        override public string getAnswer()
        {
            return this.answer;
        }
    }
}
