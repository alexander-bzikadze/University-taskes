#include "lexAnalyzer.h"

using namespace std;

LexAnalyzer::LexAnalyzer(string sentence)
    : sentence(sentence), command(0)
{
}

bool LexAnalyzer::isInputCorrect() const
{
    return (sentence.top() <= '9' && sentence.top() >= '0');
}

void LexAnalyzer::popDigits()
{
    while (isInputCorrect())
    {
        sentence.pop();
    }
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
                popDigits();
                if (sentence.top() == '.')
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
                    popDigits();
                    if (sentence.top() == 'E')
                    {
                        command = 3;
                        break;
                    }
                    else if (!sentence.top())
                    {
                        command = 9;
                        break;
                    }
                }
                command = 10;
                break;
            }
            case 3:
            {
                sentence.pop();
                if (sentence.top() == '+' || sentence.top() == '-')
                {
                    sentence.pop();
                }
                if (isInputCorrect())
                {
                    popDigits();
                    if (!sentence.top())
                    {
                        command = 9;
                        break;
                    }
                }
                command = 10;
                break;
            }
        }
    }
    return command % 2;
}

