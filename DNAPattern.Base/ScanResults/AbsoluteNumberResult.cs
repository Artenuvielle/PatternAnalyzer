using System;
using System.Collections.Generic;

namespace DNAPattern.Base.ScanResults
{
    public class AbsoluteNumberResult:DNAScanResult
    {
        private string answer;
        private int sumOfAllValues;
        private Dictionary<string, int> descriptionsWithAbsoluteValues;

        public AbsoluteNumberResult(string returningAnswer)
        {
            this.answer = returningAnswer;
            descriptionsWithAbsoluteValues = new Dictionary<string, int>();
            sumOfAllValues = 0;
        }

        public void addAbsoluteNumberToResult(string givenKey, int valueToAdd)
        {
            sumOfAllValues += valueToAdd;
            if (descriptionsWithAbsoluteValues.ContainsKey(givenKey))
            {
                descriptionsWithAbsoluteValues[givenKey] += valueToAdd;
            }
            else
            {
                descriptionsWithAbsoluteValues.Add(givenKey, valueToAdd);
            }
        }

        public Dictionary<string, int> getValues()
        {
            return descriptionsWithAbsoluteValues;
        }

        public int getSumOfAllValues()
        {
            return sumOfAllValues;
        }

        override public string getAnswer()
        {
            return this.answer;
        }
    }
}
