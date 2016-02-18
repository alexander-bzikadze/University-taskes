#include <iostream>
#include <fstream>

#include "prog2.h"

using namespace std;

/*
10 1 2 9 83 4 8 59 7 28 28 => "The most common element is 28."
10 0 28 0 83 4 8 59 7 28 59 4 => "The most common element is 0."
*/

int main()
{
    ifstream file("prog2.in", ios::in);
    if (!file)
    {
        cout << "Critical error!";
        return 1;
    }
    int array[maxSize] = {};
    int size = typeArray(array, file);
    int auxiliaryArray[maxSize] = {};
    cout << "The most common element is ";
    cout << findMaxElement(array, size, maxSize) << '.';
    file.close();
    return 0;
}