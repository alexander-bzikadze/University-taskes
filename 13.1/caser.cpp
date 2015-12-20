#include "caser.h"

using namespace std;

SuperString::SuperString(string const &sentence)
     : sentence(sentence)
{
}

char SuperString::top() const
{
    return sentence[0];
}

char SuperString::pop()
{
    char result = top();
    sentence.erase(0, 1);
    return result;
}

void SuperString::print() const
{
    std::cout << sentence << std::endl;
}