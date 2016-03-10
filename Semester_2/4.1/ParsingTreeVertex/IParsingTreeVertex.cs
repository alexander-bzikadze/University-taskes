namespace ParsingTree
{
    /// An interface for a vertex of the Parsing Tree.
    /// Returns its result and prints itself.
    public interface IParsingTreeVertex
    {
        int Result();

        void Print();
    }
}