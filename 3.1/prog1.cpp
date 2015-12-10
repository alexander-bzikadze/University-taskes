#include <cstdio>
#include <iostream>
#include <algorithm>
#include <cstdlib>
#include <ctime>

using namespace std;
 
const int maxSize = 10000;
const int maxRange = 10000;
int const threshold = 10;

void seeOut(int * array, int size)
{
    for ( int i = 0; i < size; ++i)
    {
        cout << array[i] << ' ';
    }
    cout << endl;
} 

void generateArray(int * array, int max, int size)
{
    for (int i = 0; i < size; ++i)
    {
        array[i] = rand() % max;
    }
    return;
}

void sort(int * array, int size)
{
    int j = 0;
    // seeOut(array, size);
    for (int i = 1; i < size; ++i)
    {
        j = i;
        while (array[j] < array[j - 1])
        {
            swap(array[j], array[j - 1]);
            if (j > 1)
            {
                --j;
            }
        }
    }
}

bool checkingUp(int * array, int size)
{
    for (int i = 1; i < size; ++i)
    {
        if (array[i] < array[i - 1])
        {
            return false;
        }
    }
    return true;
}

void quickSort(int * array, int left, int right)
{
    if (right - left < threshold)
    {
        sort(array + left, right - left + 1);
        return;
    }
    int pivot = array[left + (right - left) / 2];
    int leftElement = left;
    int rightElement = right;
    while(leftElement <= rightElement)
    {
        while(array[leftElement] < pivot)
        {
            leftElement++;
        }
        while(array[rightElement] > pivot)
        {
            rightElement--;
        }
        if(leftElement <= rightElement)
        {
            swap(array[leftElement], array[rightElement]);
            leftElement++;
            rightElement--;
        }
    }
    if (leftElement < right)
    {
        quickSort(array, leftElement, right);
    }
    if (left < rightElement)
    {
        quickSort(array, left, rightElement);    
    }
}

int main()
{
    cout << "Would you kindly, type in the size of an array and the range of its elements." << endl;
    srand(time(0));
    int array[maxSize] = {};
    int size = 0;
    int range = 0;
    cin >> size >> range;
    generateArray(array, range, size);
    // seeOut(array, size);
    quickSort(array, 0, size - 1);
    seeOut(array, size);
    return !checkingUp(array, size); // If there is a mistake, this check will make the programm shut down with an exitcode 1
}