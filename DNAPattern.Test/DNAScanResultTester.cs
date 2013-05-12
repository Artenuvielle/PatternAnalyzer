using System;
using DNAPattern.Base;
using DNAPattern.Base.ScanResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DNAPattern.Test
{
    [TestClass]
    public class DNAScanResultTester
    {
        [TestMethod]
        public void TextResultTest()
        {
            string test = "1";
            Assert.AreEqual((new TextResult(test)).getAnswer(),test);
        }

        [TestMethod]
        public void DNASequenceResultTest()
        {
            string test = "1";
            DNASequence seq = new DNASequence("act");
            DNASequenceResult result = new DNASequenceResult(test, seq);
            Assert.AreEqual(result.getAnswer(),test);
            Assert.AreEqual<DNASequence>(result.getSequence(), seq);
        }

        [TestMethod]
        public void AbsoluteNumberResultTest()
        {
            AbsoluteNumberResult res = new AbsoluteNumberResult("1");
            res.addAbsoluteNumberToResult("a", 1);
            res.addAbsoluteNumberToResult("a", 1);
            res.addAbsoluteNumberToResult("b", 1);
            res.addAbsoluteNumberToResult("a", 1);
            System.Collections.Generic.Dictionary<string, int> values = res.getValues();
            Console.WriteLine(res.getAnswer());
            int sum = 0;
            foreach (string s in values.Keys)
            {
                Console.WriteLine(s + "  " + values[s]);
                sum += values[s];
            }
            Console.WriteLine(res.getSumOfAllValues());
            Assert.AreEqual(sum, res.getSumOfAllValues());
        }
    }
}
