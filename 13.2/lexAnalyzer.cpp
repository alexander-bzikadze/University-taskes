#include "lexAnalyzer.h"

using namespace std;

LexAnanyzer::LexAnanyzer(std::string sentence)
 : sentence(sentence), currentStage(1), tableOfStages()
{}

bool LexAnanyzer::mainProcess()
{
    while (sentence[0] && currentStage < 3)
    {
        switch (tableOfStages.getStage(currentStage - 1, letterAnalyzer()))
        {
            case 2:
            {
                currentStage = 2;
                cout << sentence[0];
                break;
            }
            case 3:
            {
                currentStage = 3;
                break;
            }
            case 1: //or case 1:
            {
                currentStage = 1;
                break;
            }
        }
        sentence.erase(0, 1);
    }
    cout << endl;
    if (currentStage != 1)
    {
        return 1;
    }
    return 0;
}

unsigned short LexAnanyzer::letterAnalyzer()
{
    if (sentence.size() > 1)
    {
        if (sentence[0] == '/' && sentence[1] == '*')
        {
            return 0;
        }
        if (sentence[0] == '*' && sentence[1] == '/')
        {
            cout << sentence[0] << sentence[1] << endl;
            return 1;
        }
    }
    return 2;
}
