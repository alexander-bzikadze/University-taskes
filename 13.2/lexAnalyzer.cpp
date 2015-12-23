#include "lexAnalyzer.h"

using namespace std;

LexAnalyzer::LexAnalyzer(std::string const &sentence)
 : sentence(sentence), currentStage(1), tableOfStages()
{}

bool LexAnalyzer::mainProcess()
{
    while (sentence.size() > 0 && currentStage < 5)
    {
        while (currentStage == 1)
        {
            currentStage = tableOfStages.getStage(letterAnalyzer(), currentStage - 1);
            sentence.erase(0, 1);
        }
        while (currentStage == 2)
        {
            currentStage = tableOfStages.getStage(letterAnalyzer(), currentStage - 1);
            sentence.erase(0, 1);
        }
        if (currentStage == 3) //For decoration of comments
        {
            cout << "/*";
        }
        while (currentStage == 3)
        {
            cout << sentence[0];
            currentStage = tableOfStages.getStage(letterAnalyzer(), currentStage - 1);
            sentence.erase(0, 1);
        }
        while (currentStage == 4)
        {
            currentStage = tableOfStages.getStage(letterAnalyzer(), currentStage - 1);
            sentence.erase(0, 1);
        }
        if (currentStage == 1) //For decoration of comments
        {
            cout << '/' << endl;
        }
    }
    return currentStage % 2;
}

unsigned short LexAnalyzer::letterAnalyzer()
{
    if (sentence.size() > 0)
    {
        if (sentence[0] == '/')
        {
            return 1;
        }
        if (sentence[0] == '*')
        {
            return 2;
        }
        return 0;
    }
    return 3;
}
