#pragma once
#include <iostream>
#include <string>
using namespace std;

class StringSearch
{
public:
    StringSearch(string mainString, string subString);

    ~StringSearch();

    int search();

private:
    string mainString = "";

    string subString = "";

    int static const maxSize = 256;

    int array[maxSize] = {};
};
