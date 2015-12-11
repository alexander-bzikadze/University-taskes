#pragma once
#include "PointerStack.h"
#include "ArrayStack.h"


template <class T>
class Calculator
{
public:
    Calculator(IStack<T> &stack) : stack(stack) {};
    ~Calculator() {};

    void add()
    {
        stack.push(stack.pop() + stack.pop());
    }

    void subtract()
    {
        stack.push(stack.pop() - stack.pop());
    }

    void multiply()
    {
        stack.push(stack.pop() * stack.pop());
    }
    
    void divide()
    {
        stack.push(stack.pop() / stack.pop());
    }

    void exp(int exp)
    {
        T x = stack.pop();
        T result = x / x;
        for (int i = exp; i > 0; i >>= 1)
        {
            if (i & 1)
            {
                result = result * x;
            }
            x = x * x;
        }
        stack.push(result);
    }
    
    void push(T const &value)
    {
        stack.push(value);
    }
    
    T result() const
    {
        return stack.top();
    }

private:
    IStack<T> &stack;
};