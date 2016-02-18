#pragma once

#include <iostream>

#include "stack.h"

class Reader
{
public:
    Reader();

    void read();

    bool isOperand(int i);

    bool isOperatorAddition(char i);

    bool isOperatorMultiplication(char i);

    void fillStacks();

    void result();

private:
    static const int maxSize = 256;

    char subStr[maxSize];

    int size;

    Stack<char> operators;

    Stack<char> outputStack;
};