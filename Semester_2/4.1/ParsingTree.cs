using System;

namespace ParsingTree
{
    public class ParsingTree
    {
        public static int ParsingTreeCounter(String sentence)
        {
            return ParsingTreeConstructor.ConstructParsingTree(sentence).Result();
        }
    }
}