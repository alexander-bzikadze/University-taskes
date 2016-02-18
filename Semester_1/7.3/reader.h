#pragma once

#include <iostream>

#include "stack.h"

class Reader
{
public:
    Reader();

    void read();

    bool isAnOpeningBrace(int index);

    bool isAnClosingBrace(int index);

    void check();

    bool result();

private:
    static const int maxSize = 256;

    static const int bracesNumber = 4;

    const char openingBraces[bracesNumber] = {'(', '[', '{', '<'};

    const char closingBraces[bracesNumber] = {')', ']', '}', '>'};

    char input[maxSize];

    int size;

    bool checkResult;

    Stack<char> stack;
};