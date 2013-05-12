namespace DNAPattern.Base
{
    public abstract class DNAScan
    {
        abstract protected void setScanSequence(DNASequence sequenceToScan);

        abstract public string getQuestion();

        abstract public void RunScan();

        abstract public DNAScanResult getScanResult();
    }
}
