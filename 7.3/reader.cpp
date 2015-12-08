#include "reader.h"

Reader::Reader() :
    size(0), checkResult(false)
{
    std::fill(input, input + maxSize, 0);
}

void Reader::read()
{
    std::cin.getline(input, maxSize);
    while (size < maxSize && input[size])
    {
        ++size;
    }
}

bool Reader::isAnOpeningBrace(int index)
{
    for (int i = 0; i < bracesNumber; ++i)
    {
        if (openingBraces[i] == input[index])
        {
            return true;
        }
    }
    return false;
}

bool Reader::isAnClosingBrace(int index)
{
    for (int i = 0; i < bracesNumber; ++i)
    {
        if (closingBraces[i] == input[index])
        {
            return true;
        }
    }
    return false;
}

void Reader::check()
{
    // std::cout << size << std::endl;
    for (int i = 0; i < size; ++i)
    {
        // std::cout << input[i] << std::endl;
        if (isAnOpeningBrace(i))
        {
            stack.push(input[i]);
        }
        else if (isAnClosingBrace(i))
        {
            char poped = stack.pop();
            // std::cout << '!';
            if (input[i] == ')' && poped != input[i] - 1)
            {
                return;
            }
            if (input[i] != ')' && poped != input[i] - 2)
            {
                return;
            }
        }
    }
    // std::cout << stack.top() << std::endl;
    if (!stack.top())
    {
        checkResult = true;
    }
}

bool Reader::result()
{
    return checkResult;
}