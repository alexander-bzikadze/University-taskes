#pragma once

template <class T>
class IStack
{
public:
    virtual void push(T const &value) = 0;
    virtual T top() const = 0;
    virtual T pop() = 0;
};