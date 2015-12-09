#pragma once
#include "caser.h"

class LexAnalyzer
{
public:
    LexAnalyzer(std::string sentence);

    bool mainProcess();

private:
    bool isInputCorrect() const;
    void popDigits();

    SuperString sentence;
    short unsigned command;
};