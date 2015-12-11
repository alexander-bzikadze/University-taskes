#pragma once
#include <vector>
#include <algorithm>
#include "IStack.h"

template <class T>
class ArrayStack : public IStack<T>
{
public:
    ArrayStack() : index(-1), array() {};
    ~ArrayStack() {};

    void push(T const &value)
    {
        array[++index] = value;
    }

    T top() const
    {
        if (index == -1)
        {
            return T();
        }
        return array[index];
    }

    T pop()
    {
        if (index == -1)
        {
            return T();
        }
        return array[index--];
    }

private:
    int index;
    static const size_t maxSize = 100;
    T array[maxSize];
    // std::vector<T> array;
};