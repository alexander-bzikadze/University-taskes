#pragma once
#include "stage.h"
#include <iostream>

class LexAnalyzer
{
public:
    LexAnalyzer(std::string sentence);

    ///Analyzes text for comments and prints them if found. 
    ///If there are mistakes with comments decoration returns 0, if not then 1.
    bool mainProcess();

private:
    unsigned short letterAnalyzer();

    std::string sentence;
    int currentStage;
    Stage tableOfStages;
};