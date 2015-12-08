#include <cstdio>
#include <iostream>
#include <algorithm>

using namespace std;
 
const int maxSize = 1e5;
int const threshold = 10;

void seeOut(int * array, int size)
{
    for ( int i = 0; i < size; ++i)
    {
        cout << array[i] << ' ';
    }
    cout << endl;
} 

void seeIn(int * array, int size)
{
    for ( int i = 0; i < size; ++i)
    {
        cin >> array[i];
    }
} 

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

void quickSort(int * array, int left, int right)
{
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
    int array[maxSize] = {};
    int size = 0;
    cin >> size;
    seeIn(array, size);
    // seeOut(array, size);
    quickSort(array, 0, size - 1);
    seeOut(array, size);
}