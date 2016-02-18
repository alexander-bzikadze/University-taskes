#pragma once
#include <iostream>
#include "stack.h"
#include "array.h"

template <class T>
class Calculator
{
public:
    void add();

    void subtract();

    void multiply();

    void divide();

    void push(int value);

    int result() const;

private:
    T stack;
};

template <class T>
void Calculator<T>::add()
{
    int first = stack.pop();
    int second = stack.pop();
    stack.push(first + second);
}

template <class T>
void Calculator<T>::subtract()
{
    int first = stack.pop();
    int second = stack.pop();
    stack.push(second - first);
}

template <class T>
void Calculator<T>::multiply()
{
    int first = stack.pop();
    int second = stack.pop();
    stack.push(first * second);
}

template <class T>
void Calculator<T>::divide()
{
    int first = stack.pop();
    int second = stack.pop();
    // std::cout << std::endl << '!' << first << '/' << second << std::endl;
    stack.push(second / first);
}

template <class T>
void Calculator<T>::push(int value)
{
    stack.push(value);
}

template <class T>
int Calculator<T>::result() const
{
    return stack.top();
}