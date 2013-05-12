using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DNAPattern.Base
{
    public class DNASequence
    {
        // The actual string which was given to the contructor.
        private string outputSequence;

        // A string to work on with regular expressions where all whitespaces were stripped and letters are lowercase
        // to prevent additional exception handling.
        private string workSequence;

        public DNASequence(string inputSequence)
        {
            if (DNASequence.TestIfStringIsSequence(inputSequence))
            {
                this.outputSequence = inputSequence;
                this.workSequence = StripWhitespacesAndUppercase(inputSequence);
            }
            else
            {
                throw new Exception("The string " + inputSequence + " could not be interpreted as a valid DNA sequence.");
            }
        }

        public string getSequenceForOutput
        {
            get { return this.outputSequence; }
        }

        public string getSequenceForWork
        {
            get { return this.workSequence; }
        }

        public int CountDistinctSubsequences(string subsequenceToSearchFor)
        {
            Regex tempRegEx = new Regex(subsequenceToSearchFor);
            MatchCollection matches = tempRegEx.Matches(this.workSequence);
            return matches.Count;
        }

        public Match FindFirstSubsequence(string subsequenceToSearchFor)
        {
            Regex tempRegEx = new Regex(subsequenceToSearchFor);
            Match foundSubsequence = tempRegEx.Match(this.workSequence);
            return foundSubsequence;
        }

        public DNASequence GetComplimentarySequence()
        {
            // Reverse the order of the nucleobases
            char[] nucleobases = this.outputSequence.ToLower().ToCharArray();
            Array.Reverse(nucleobases);
            string reverseSequence = new string(nucleobases);

            // Replace all a with x and g with y
            string temporaryReverseSequenceWithoutAdenine = Regex.Replace(reverseSequence, "a", "x");
            string temporaryReverseSequenceWithoutPurines = Regex.Replace(temporaryReverseSequenceWithoutAdenine, "g", "y");

            // Replace all t with a and c with g
            string temporaryComplimentarySequenceWithouPurines = Regex.Replace(Regex.Replace(temporaryReverseSequenceWithoutPurines, "t", "a"), "c", "g");

            // Replace all x (old a) with t and y (olt t) with c
            string comlimentarySequence = Regex.Replace(Regex.Replace(temporaryComplimentarySequenceWithouPurines, "x", "t"), "y", "c");
            return new DNASequence(comlimentarySequence);
        }

        private string StripWhitespacesAndUppercase(string stringToWorkOn)
        {
            var patternForStripping = @"\s";
            stringToWorkOn = Regex.Replace(stringToWorkOn, patternForStripping, String.Empty, RegexOptions.IgnoreCase);
            return stringToWorkOn.ToLower();
        }

        public static bool TestIfStringIsSequence(string stringToTest)
        {
            var patternForSequence = @"[gact\s]+";
            Match patternWasFoundIn = Regex.Match(stringToTest, patternForSequence, RegexOptions.IgnoreCase);
            return (patternWasFoundIn.Index == 0 && patternWasFoundIn.Length == stringToTest.Length);
        }

        public static DNASequence LoadFromFile(string inputFilePath)
        {
            return new DNASequence(File.ReadAllText(inputFilePath));
        }
    }
}
