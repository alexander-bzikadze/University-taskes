#pragma once

#include <iostream>
#include <string>

class StringSearch
{
public:
    StringSearch(std::string mainString, std::string subString);

    ~StringSearch();

    ///Checks mainString for having subString in it, then returns the position of the first match
    ///If match not found returns -1
    int search();

private:
    std::string mainString = "";

    std::string subString = "";

    int static const maxSize = 256;

    int array[maxSize] = {};
};
