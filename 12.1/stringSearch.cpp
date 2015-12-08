#include "stringSearch.h"

StringSearch::StringSearch(string mainString, string subString)
    : mainString(mainString), subString(subString)
{
}

StringSearch::~StringSearch()
{
    // mainString = "";
    // subString = "";
    // array[maxSize] = {};
}

int StringSearch::search()
{
    mainString.insert(0, "#");
    int result = 0;
    array[0] = 0;
    for (int i = 1; i < mainString.size(); ++i)
    {
        int j = array[i - 1];
        while (j > 0 && mainString[i] != subString[j])
        {
            j = array[j - 1];
        }
        if (mainString[i] == subString[j])
        {
            ++j;
        }
        array[i] = j;
        if (j == subString.size())
        {
            result++;
        }
    }
    return result;
}
