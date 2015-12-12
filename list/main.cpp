#include "List.h"
#include <iostream>

int main()
{
    List<int> list;
    list.add(1);
    list.add(1);
    list.add(2);
    list.add(3);
    list.add(4);
    list.add(5);
    list.pop();
    list.deleteElement(0);
    list.deleteElement(1);
    list.deleteElement(3);
    list.deleteElement(5);
    list.print();
    return 0;
}