#pragma once

#include "tree.h"

class Dialogue
{
public:
    Dialogue();

    ~Dialogue();

    bool mainProcess();

private:
    void greating();

    void commanding();

    void addValue();

    void deleteValue();

    void checkValue();

    void seeOut();

    void farewelling();
    

    int value; //unncessery, but still useful

    short command;

    Tree tree;
};
