namespace HashTable
{
    public class Hash2 : IHash
    {
        public int Func(int value, int max)
        {
            return value % max;
        }
    }
}