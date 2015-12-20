#include "cycleList.h"

struct CycleListElement
{
    int number = 0;
    CycleListElement * next = nullptr;
};

struct CycleList
{
    int size = 0;
    CycleListElement * first = nullptr;
    CycleListElement * last = nullptr;
};


CycleList *  constructList()
{
   return new CycleList;
}

void appendElement(CycleList * list, int inNumber)
{
    CycleListElement * tmp = new CycleListElement;
    tmp -> number = inNumber;
    tmp -> next = list -> first;
    if (!list -> size)
    {
        list -> first = tmp;
    }
    else
    {
        list -> last -> next = tmp;
    }
    ++list -> size;
    list -> last = tmp;
}

void constructCycleList(CycleList * list, int squadSize)
{
    for (int i = 0; i < squadSize; ++i)
    {
        appendElement(list, i + 1);
    }
}

void deleteElement(CycleList * list, CycleListElement * currentElement)
{
    if (currentElement == list -> last)
    {
        list -> first = currentElement -> next -> next;
    }
    else if (currentElement -> next == list -> last)
    {
        list -> last = currentElement;
    }
    CycleListElement * tmp = new CycleListElement;
    tmp = currentElement -> next;
    currentElement -> next = currentElement -> next -> next;
    delete tmp;
    tmp = nullptr;
    --list -> size;
}

void delition(CycleList * list, int k)
{
    --k;
    CycleListElement * currentElement = list -> last;
    while (list -> size > 1)
    {
        for (int i = 0; i < k % list -> size ; ++i)
        {
            currentElement = currentElement -> next;
        }
        // std::cout << currentElement -> next -> number << std::endl;
        deleteElement(list, currentElement);
    }
}

void seeAllList(CycleList * list)
{
    if (!list -> size)
    {
        return;
    }
    CycleListElement * currentElement = list -> first;
    std::cout << ' ' << currentElement -> number;
    while (currentElement -> next != list -> first)
    {
        currentElement = currentElement -> next;
        std::cout << ' ' << currentElement -> number;
    }
    std::cout << std::endl;
}