using System;
using DNAPattern.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DNAPattern.Test
{
    [TestClass]
    public class DNASequenceTest
    {
        System.Collections.Generic.List<DNASequence> sequences;
        private string givenTest = "ggaatttagggagttcccacattgcccagacgactcgtatagaattggtagttggccatg\ncgtccatatcacaaagacacagtccctggccgaccacactgtaaccacgaatatgcccta\ntcgtacgggttgggatgcacttttgagttatacgcgctcgaatctatgcccagtacacat\nggtgccgacacctaactaggcagtgaggggcactcagacctgacatgagcggaagaaaga\nacccgcgggggccccacgacgtagcggcgacggctcaaccaatgccccgcccctttcata\naggccaagcggactgggctttcgcccgagtctaaacccactgtatttaccattcatagtc\naacagagggactttcaaaattcctaaactggttactgactaagaggaatcctcgcgctaa\ntgaagacaacctccatagaggtcaaatggcgcgcagttgacttcagtattgaccttcttc\nagggtcccccatctttgatacttcacttatggacccggccaccgtgagttgaatcccggc\ngtccctcgcgtccccaacacagacaatatttttacgtgtccaagggcggaaagtgacgag\ngtgagaactggcgccgcgagaccggcccgatttctaataggcgggatagagatctgcccg\nacgcatttcacttgtagtcactcacggtatgactgtgcatgcactgaccgtcgctggcgt\ngtctttaatttaagctaggcttgacgtggagtgcagaatgaccatgttcaaggtgcttcg\ngggctatatacttgggataaacgcgatcctgcggagtagcgtcgagaacaccgactgccg\naatgtacaatccgcgtgacaatgccgaggctcgagatatcacttgaactgcgggcgaatc\ngattcgagagcccgatcgttaacaagtcgtcggctgtagccaataatatcttggttttag\natcttgagtgtgggggcgtttacttaaccatccgaacgcg";

        [TestInitialize]
        public void initTest() {
            sequences = new System.Collections.Generic.List<DNASequence>();
            sequences.Add(new DNASequence(givenTest));
        }

        [TestMethod]
        public void TestDNASequenceConstructor()
        {
            sequences.Add(new DNASequence("gagt"));
            sequences.Add(new DNASequence("ga g t"));
            sequences.Add(new DNASequence("gA gCC"));
            foreach (DNASequence seq in sequences)
                Console.WriteLine(seq.getSequenceForOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDNASequenceConstructorException()
        {
            new DNASequence("test");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDNASequenceConstructorException2()
        {
            new DNASequence("ngacn");
        }

        [TestMethod]
        public void TestDNASequenceLoadFromFile()
        {
            Assert.IsTrue((new DNASequence(givenTest)).getSequenceForWork == (DNASequence.LoadFromFile("DNATest.txt")).getSequenceForWork);
        }
    }
}
