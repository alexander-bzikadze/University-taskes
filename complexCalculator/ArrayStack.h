#pragma once
#include <vector>
#include "IStack.h"

template <class T>
class ArrayStack : public IStack<T>
{
public:
    ArrayStack() : index(), array() {};
    ~ArrayStack() {};

    void push(T value)
    {
        array[++index] = value;
    }

    T top()
    {
        return array[index];
    }

    T pop()
    {
        return array[index--];
    }

private:
    T index;
    std::vector<T> array;
};