#pragma once

template <class T>
class IStack
{
public:
    virtual void push(T value) = 0;
    virtual T top() = 0;
    virtual T pop() = 0;
};