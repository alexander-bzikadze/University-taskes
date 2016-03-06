namespace HashTable
{
    public class Hash1 : IHash
    {
        public int Func(int value, int max)
        {
            return (value % max) * (value % max) % max;
        }
    }
}