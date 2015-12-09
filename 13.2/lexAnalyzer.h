#pragma once
#include "stage.h"
#include <iostream>

class LexAnanyzer
{
public:
    LexAnanyzer(std::string sentence);

    bool mainProcess();

private:
    unsigned short letterAnalyzer();

    std::string sentence;
    int currentStage;
    Stage tableOfStages;
};