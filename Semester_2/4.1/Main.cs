using System;

namespace ParsingTree
{
    class CL
    {
        static void Main()
        {
            String sentence = "(- (+ (- (- (+ (+ 1 1) 1) 1) 1) 1) 1)";
            int result = ParsingTree.ParsingTreeCounter(sentence);
            Console.WriteLine("{0}, {1}", sentence, result);
        }
    }
}