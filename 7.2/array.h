#pragma once

class ArrayStack
{
public:
    ArrayStack();
    ~ArrayStack();
    void push(int value);
    int pop();
    int top() const;

    int static const maxSize = 1000;

private:
    int stackArray[maxSize] = {};
    int index = -1;
};