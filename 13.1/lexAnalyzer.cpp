#include "lexAnalyzer.h"

using namespace std;

LexAnalyzer::LexAnalyzer(string const &sentence)
    : sentence(sentence), command(0)
{
}

bool LexAnalyzer::isInputCorrect() const
{
    return (sentence.top() <= '9' && sentence.top() >= '0');
}

bool LexAnalyzer::mainProcess()
{
    while (command < 9)
    {
        switch (command)
        {
            case 0:
            {
                if (isInputCorrect())
                {
                    command = 1;
                }
                else 
                {
                    command = 10;
                }
                break;
            }
            case 1:
            {
                if (isInputCorrect())
                {
                    sentence.pop();
                    command = 1; 
                }
                else if (sentence.top() == '.')
                {
                    command = 2;
                }
                else if (sentence.top() == 'E')
                {
                    command = 3;
                }
                else if (!sentence.top())
                {
                    command = 9;
                }
                else
                {
                    command = 10;
                }
                break;
            }
            case 2:
            {
                sentence.pop();
                if (isInputCorrect())
                {
                    command = 4;
                    break;
                }
                command = 10;
                break;
            }
            case 3:
            {
                sentence.pop();
                if (sentence.top() == '+' || sentence.top() == '-')
                {
                    command = 5;
                    break;
                }
                if (isInputCorrect())
                {
                    command = 6;
                    break;
                }
                command = 10;
                break;
            }
            case 4:
            {
                if (isInputCorrect())
                {
                    sentence.pop();
                    command = 1; 
                }
                else if (sentence.top() == 'E')
                {
                    command = 3;
                }
                else if (!sentence.top())
                {
                    command = 9;
                }
                else
                {
                    command = 10;
                }
                break;
            }
            case 5:
            {
                sentence.pop();
                if (isInputCorrect())
                {
                    command = 6;
                    break;
                }
                command = 10;
                break;
            }
            case 6:
            {
                if (isInputCorrect())
                {
                    sentence.pop();
                    command = 6;
                }
                else if (!sentence.top())
                {
                    command = 9;
                }
                else
                {
                    command = 10;
                }
                break;
            }
        }
    }
    return command % 2;
}

