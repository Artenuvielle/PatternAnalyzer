using System;
using DNAPattern.Base;
using DNAPattern.Base.Scans;
using DNAPattern.Base.ScanResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DNAPattern.Test
{
    [TestClass]
    public class DNAScannerTest
    {
        private string givenTest = "ggaatttagggagttcccacattgcccagacgactcgtatagaattggtagttggccatg\ncgtccatatcacaaagacacagtccctggccgaccacactgtaaccacgaatatgcccta\ntcgtacgggttgggatgcacttttgagttatacgcgctcgaatctatgcccagtacacat\nggtgccgacacctaactaggcagtgaggggcactcagacctgacatgagcggaagaaaga\nacccgcgggggccccacgacgtagcggcgacggctcaaccaatgccccgcccctttcata\naggccaagcggactgggctttcgcccgagtctaaacccactgtatttaccattcatagtc\naacagagggactttcaaaattcctaaactggttactgactaagaggaatcctcgcgctaa\ntgaagacaacctccatagaggtcaaatggcgcgcagttgacttcagtattgaccttcttc\nagggtcccccatctttgatacttcacttatggacccggccaccgtgagttgaatcccggc\ngtccctcgcgtccccaacacagacaatatttttacgtgtccaagggcggaaagtgacgag\ngtgagaactggcgccgcgagaccggcccgatttctaataggcgggatagagatctgcccg\nacgcatttcacttgtagtcactcacggtatgactgtgcatgcactgaccgtcgctggcgt\ngtctttaatttaagctaggcttgacgtggagtgcagaatgaccatgttcaaggtgcttcg\ngggctatatacttgggataaacgcgatcctgcggagtagcgtcgagaacaccgactgccg\naatgtacaatccgcgtgacaatgccgaggctcgagatatcacttgaactgcgggcgaatc\ngattcgagagcccgatcgttaacaagtcgtcggctgtagccaataatatcttggttttag\natcttgagtgtgggggcgtttacttaaccatccgaacgcg";

        [TestMethod]
        public void Scan1Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan1 scantest = new Scan1(sequence);
            scantest.RunScan();
            TextResult tr = (TextResult) scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());

            sequence = new DNASequence("ggg ac  gg tcggg");
            scantest = new Scan1(sequence);
            scantest.RunScan();
            tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
        }

        [TestMethod]
        public void Scan2Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan2 scantest = new Scan2(sequence);
            scantest.RunScan();
            TextResult tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());

            sequence = new DNASequence("ggg ac  gg tcagggg");
            scantest = new Scan2(sequence);
            scantest.RunScan();
            tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
        }

        [TestMethod]
        public void Scan3Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan3 scantest = new Scan3(sequence);
            scantest.RunScan();
            AbsoluteNumberResult tr = (AbsoluteNumberResult)scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());
            System.Collections.Generic.Dictionary<string, int> values = tr.getValues();
            foreach (string s in values.Keys)
            {
                Console.WriteLine(s + "  " + values[s]);
            }

            sequence = new DNASequence("ggg ac  gg tcagggg");
            scantest = new Scan3(sequence);
            scantest.RunScan();
            tr = (AbsoluteNumberResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
            values = tr.getValues();
            foreach (string s in values.Keys)
            {
                Console.WriteLine(s + "  " + values[s]);
            }
        }

        [TestMethod]
        public void Scan4Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan4 scantest = new Scan4(sequence);
            scantest.RunScan();
            TextResult tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());

            sequence = new DNASequence("ggg ac  gg tcagggg");
            scantest = new Scan4(sequence);
            scantest.RunScan();
            tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
        }

        [TestMethod]
        public void Scan5Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan5 scantest = new Scan5(sequence);
            scantest.RunScan();
            AbsoluteNumberResult tr = (AbsoluteNumberResult)scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());
            System.Collections.Generic.Dictionary<string, int> values = tr.getValues();
            foreach (string s in values.Keys)
            {
                Console.WriteLine(s + "  " + values[s]);
            }

            sequence = new DNASequence("ggg accccccccccccccccccccccccc  gg tcagggg");
            scantest = new Scan5(sequence);
            scantest.RunScan();
            tr = (AbsoluteNumberResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
            values = tr.getValues();
            foreach (string s in values.Keys)
            {
                Console.WriteLine(s + "  " + values[s]);
            }
        }

        [TestMethod]
        public void Scan6Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan6 scantest = new Scan6(sequence);
            scantest.RunScan();
            TextResult tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());

            sequence = new DNASequence("ggg ac  gg tcagggg");
            scantest = new Scan6(sequence);
            scantest.RunScan();
            tr = (TextResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
        }

        [TestMethod]
        public void Scan7Test()
        {
            DNASequence sequence = new DNASequence(givenTest);
            Scan7 scantest = new Scan7(sequence);
            scantest.RunScan();
            DNASequenceResult tr = (DNASequenceResult)scantest.getScanResult();
            Console.WriteLine(scantest.getQuestion());
            Console.WriteLine(tr.getAnswer());
            Console.WriteLine(tr.getSequence().getSequenceForOutput);

            sequence = new DNASequence("TTAC");
            scantest = new Scan7(sequence);
            scantest.RunScan();
            tr = (DNASequenceResult)scantest.getScanResult();
            Console.WriteLine(tr.getAnswer());
            Console.WriteLine(tr.getSequence().getSequenceForOutput);
        }
    }
}
