#include <iostream>
#include <cstdlib>
#include <ctime>
#include <cassert>

using namespace std;

int const maxSize = 1e8;
int const threshold = 10;

/* Have been tested on size < 10:
5 9 9 1 8 8 4 2 6  => 1 2 4 5 6 8 8 9 9 
Checked on size > 10:
4 47 2 84 6 62 14 89 74 72 15 76 73 97 42 81 83 20 85 8 => 2 4 6 8 14 15 20 42 47 62 72 73 74 76 81 83 84 85 89 97 
*/ 

void sort(int * array, int size)
{
    for (int i = 1; i < size; ++i)
    {
        while (array[i] < array[i - 1])
        {
            swap(array[i], array[i - 1]);
            if (i > 1)
            {
                --i;
            }
        }
    }
}

void seeOut(int * array, int size)
{
    cout << '{' << array[0];
    for ( int i = 1; i < size; ++i)
    {
        cout << ", " << array[i];
    }
    //cout << "}\n";
    cout << "}" << endl;
} 

void qsort(int * array, int size)
{
    if (size <= threshold)
    {
        sort(array, size);
        return;
    }
    int rightElement = size;
    int leftElement = 0;
    int middleElement = array[size / 2];
    while (leftElement < rightElement - 1)
    {
        // assert(leftElement >= 0);
        // assert(rightElement - 1 >= 0);
        // assert(rightElement <= size);
        // cout << rightElement - leftElement << ' ' << array[rightElement] << ' ' << array[middleElement] << ' ' << array[leftElement] << endl;
        //assert(rightElement - leftElement >= threshold);
        while (array[leftElement] < middleElement && rightElement - leftElement > 1)
        {
            ++leftElement;
        }
        while (array[rightElement - 1] >= middleElement && rightElement - leftElement > 1)
        {
            --rightElement;
        }
        if (leftElement < rightElement - 1)
        {
            swap(array[leftElement], array[rightElement - 1]);
        }
    }
    if (rightElement > 0)
    {
        qsort(array, rightElement);    
    }
    if (size > leftElement) 
    {
        qsort(array + leftElement, size - rightElement);
    }
}

void generateArray(int * array, int max, int size)
{
    for (int i = 0; i < size; ++i)
    {
        array[i] = rand() % max;
    }
    return;
}

int main()
{
    int size = 0;
    int max = 0;
    srand(time(0));
    // cout << "Would you kindly, type in the size of an array to be sorted and its max element value\n";
    // cout << "Size and max element value should be less then 1000\n";
    cin >> size >> max;
    if (size > maxSize or max > maxSize)
    {
        return 1;
    }
    int array[maxSize] = {};
    generateArray(array, max, size);
    // seeOut(array, size);
    qsort(array, size);
    seeOut(array, size);
}