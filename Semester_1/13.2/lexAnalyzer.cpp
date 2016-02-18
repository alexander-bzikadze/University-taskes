#include "lexAnalyzer.h"

using namespace std;

LexAnalyzer::LexAnalyzer(std::string const &sentence)
 : sentence(sentence), currentStage(1), tableOfStages()
{}

bool LexAnalyzer::mainProcess()
{
    while (sentence.size() > 0 && currentStage < 7)
    {
        currentStage = tableOfStages.getStage(letterAnalyzer(), currentStage - 1);
        if (currentStage == 1)
        {
            sentence.erase(0, 1);
        }
        else if (currentStage == 2)
        {
            sentence.erase(0, 1);
        }
        else if (currentStage == 5) //For decoration of comments
        {
            cout << "/*";
        }
        else if (currentStage == 3)
        {
            sentence.erase(0, 1);
            cout << sentence[0];
        }
        else if (currentStage == 4)
        {
            sentence.erase(0, 1);
        }
        else if (currentStage == 6) //For decoration of comments
        {
            cout << '/' << endl;
        }
    }
    if (currentStage == 6)
    {        
            cout << '/' << endl;
            return 1;
    }
    return currentStage < 3;
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
