#include "prog2.h"
#include <iostream>

using namespace std;

int typeArray(int * array, ifstream & file)
{
    int size = 0;
    while (!file.eof())
    {
        file >> array[size];
        ++size;
    }
    return size;
}

void seeOut(int * array, int size)
{
    for ( int i = 0; i < size; ++i)
    {
        cout << array[i] << ' ';
    }
    cout << endl;
}

int fillAuliliaryArray(int * array, int * auxiliaryArray, int size)
{
    for (int i = 0; i < size; ++i)
    {
        ++auxiliaryArray[array[i]];
    }
    int j = size - 1;
    while(!auxiliaryArray[j])
    {
        --j;
    }
    return j;
}

int findMaxElement(int * array, int size, int maxRange)
{
    int auxiliaryArray[maxSize] = {};
    fillAuliliaryArray(array, auxiliaryArray, size);
    int imax = 0;
    for (int i = 1; i < maxRange; ++i)
    {
        if (auxiliaryArray[i] > auxiliaryArray[imax])
        {
            imax = i;
        }
    }
    // seeOut(auxiliaryArray, maxRange);
    return imax;
}