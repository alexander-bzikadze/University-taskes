#pragma once
#include <string>
#include <iostream>

class SuperString
{
public:
    SuperString(const &std::string sentence);

    // ~Caser()
    char pop();
    char top() const;
    void print() const;
    // friendly std::ostream operator << (std::ostream stream, SuperString sentence)

private:
    std::string sentence;
};

// std::ostream operator << (std::ostream stream, SuperString sentence)
// {
//     std::cout << sentence.sentence;
// }