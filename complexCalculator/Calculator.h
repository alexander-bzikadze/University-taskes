#pragma once
#include "PointerStack.h"
#include "ArrayStack.h"


template <class T>
class Calculator
{
public:
    Calculator(IStack<T> &stack) : stack(stack) {};
    ~Calculator();

    void add();

    void subtract();

    void multiply();
    
    void divide();
    
    void push(T value);
    
    T result() const;

private:
    IStack<T> &stack;
};