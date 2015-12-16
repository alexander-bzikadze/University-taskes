#include <fstream>
#include "mergeSort.h"

// Tested on:
// 1 -4 93 72 8 747 929 7 37 9 17 748 37 
// 268 5 74 83 94 72 95 73 85 39 8 737 850
// 829 48 326 648 950 73 628 49 57 38 2 858 
// 8298 27 37 84 82 74 -334 -1 -98
// =>
//  -334 -98 -4 -1 1 2 5 7 8 8 9 17 27 37 37 37 
//  38 39 48 49 57 72 72 73 73 74 74 82 83 84 
//  85 93 94 95 268 326 628 648 737 747 748 
//  829 850 858 929 950 8298 

int main()
{
    AbstractList<PointerList> list = AbstractList<PointerList>();
    // AbstractList<ArrayList> list = AbstractList<ArrayList>();
    ifstream file("main.in");
    if (!file.is_open())
    {
        return 1;
    }
    int value = 0;
    while (file >> value)
    {
        list.add(value);
    }
    cout << "Unsorted List: ";
    list.print();
    list.sort();
    cout << "Sorted List: ";
    list.print();
    cout << "Number of lists: " << list.getGlobal() << endl;
    return 0;
}