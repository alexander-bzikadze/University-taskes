#include "array.h"

ArrayStack::ArrayStack()
{
    // stackArray[maxSize] = {};
    // index = -1;
}

ArrayStack::~ArrayStack()
{

}

void ArrayStack::push(int value)
{
    // std::cout << '2';
    stackArray[++index] = value;
}

int ArrayStack::pop()
{
    index--;
    return stackArray[index + 1];
}

int ArrayStack::top() const
{
    return stackArray[index];
}