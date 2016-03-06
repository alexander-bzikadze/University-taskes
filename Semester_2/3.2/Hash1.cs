namespace HashTable
{
    /// The only one method takes int value and int maximum of the results
    /// and in some way does his thing. Returns int result that is under input max.
    public class Hash1 : IHash
    {
        public int Func(int value, int max)
        {
            return (value % max) * (value % max) % max;
        }
    }
}