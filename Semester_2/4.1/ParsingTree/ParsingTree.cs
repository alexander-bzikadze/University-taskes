using System;

namespace ParsingTree
{
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