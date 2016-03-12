using System;

namespace ParsingTree
{
    /// "Static" class. Contains two methods - one constructs Parsing Tree
    /// and returns its result; second constructs and prints Parsing Tree.
    public class ParsingTree
    {
        public static int ParsingTreeCounter(String sentence)
        {
            return ParsingTreeConstructor.ConstructParsingTree(sentence).Result();
        }

        public static void ParsingTreeViewer(String sentence)
        {
            ParsingTreeConstructor.ConstructParsingTree(sentence).Print();
        }
    }
}