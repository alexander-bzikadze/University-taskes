#include "reader.h"

Reader::Reader()
    : size(0), operators(), outputStack()
{
    std::fill(subStr, subStr + maxSize, 0);
}

void Reader::read()
{
    std::cout << "Enter the string." << std::endl;
    std::cin.getline(subStr, maxSize);
    while (size < maxSize && subStr[size])
    {
        ++size;
    }
    // for (int i = 0; i < size; ++i)
    // {
    //     std::cout << subStr[i];
    // }
    // std::cout << std::endl;
}

bool Reader::isOperand(int i)
{
    if (subStr[i] <= '9' && subStr[i] >= '0')
    {
        return true;
    }
    return false;
}

bool Reader::isOperatorAddition(char i)
{
    if (i == '+' || i == '-')
    {
        return true;
    }
    return false;
}

bool Reader::isOperatorMultiplication(char i)
{
    if (i == '*' || i == '/')
    {
        return true;
    }
    return false;
}

void Reader::fillStacks()
{
    subStr[size] = ')';
    operators.push('(');
    if (subStr[0] == '-')
    {
        outputStack.push('0');
    }
    for (int i = 0; i <= size; ++i)
    {
        if (subStr[i] == '(')
        {
            operators.push(subStr[i]);
        }
        else if (isOperand(i))
        {
            // std::cout << subStr[i];
            outputStack.push(subStr[i]);
        }
        else if (subStr[i] == ')')
        {
            while (operators.top() != '(')
            {
                outputStack.push(' ');
                // std::cout << outputStack.top();
                outputStack.push(operators.pop());
            }
            operators.pop();
            if (operators.top() != '(' && operators.top())
            {
                outputStack.push(' ');
                outputStack.push(operators.pop());
            }
        }
        else if (isOperatorAddition(subStr[i]))
        {
            outputStack.push(' ');
            while (operators.top() != '(' && operators.top())
            {
                outputStack.push(operators.pop());
                outputStack.push(' ');
            }
            operators.push(subStr[i]);
        }
        else if (isOperatorMultiplication(subStr[i]))
        {
            outputStack.push(' ');
            operators.push(subStr[i]);
        }
    }
}

void Reader::result()
{
    int size = 0;
    subStr[maxSize] = {};
    while (outputStack.top())
    {
        subStr[size++] = outputStack.pop();
    }
    // std::cout << std::endl;
    std::cout << "The prefix form is:" << std::endl;
    for (int i = size - 1; i >= 0; --i)
    {
        std::cout << subStr[i];
    }
    std::cout << std::endl;
}
