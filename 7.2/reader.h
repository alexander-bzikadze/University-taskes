#pragma once

#include <iostream>

#include "calc.h"

template <class T>
class Reader
{
public:
    void read();

    void calculate();

    char * inputed() const;

    int result() const;

private:
    static const int maxSize = 256;
    char input[maxSize] = {};
    int size = 0; 
    Calculator<T> calc;
};

template <class T>
void Reader<T>::read()
{
    input[maxSize] = {};
    size = 0;
    while (size == 0)
    {
        std::cin.getline(input, maxSize);
        size = 0;
        while (size < maxSize && input[size])
        {
            ++size;
        }
    }
}

template <class T>
char * Reader<T>::inputed() const
{
    return input;
}

template <class T>
void Reader<T>::calculate()
{
    int number = 0;
    for (int i = 0; i < size; ++i)
    {
        // std::cout << input[i] << ':';
        if ('0' <= input[i] && '9' >= input[i])
        {
            number *= 10;
            number += input[i] - '0';
        }
        else if (input[i] == ' ')
        {
            if ('0' <= input[i - 1] && '9' >= input[i - 1])
            {
                calc.push(number);
                number = 0;
            } 
        }
        else switch(input[i])
        {
            case '+':
            {
                calc.add();
                break;
            }
            case '-':
            {
                calc.subtract();
                break;
            }
            case '*':
            {
                calc.multiply();
                break;
            }
            case '/':
            {
                // std::cout << std::endl << calc.result();
                calc.divide();
                break;
            }
            default:
            {
                break;
            }
        }
        // std::cout << calc.result() << std::endl;
    }
}

template <class T>
int Reader<T>::result() const
{
    return calc.result();
}
