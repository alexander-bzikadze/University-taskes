#include "list.h"
#include <iostream>

void constrList(List & list)
{
    list.first = nullptr;
    list.last = nullptr;
}

void add(List & list, int inNumber)
{
    ListEl * tmp = new ListEl;
    tmp -> number = inNumber;
    tmp -> next = nullptr;
    if (list.first == nullptr)
    {
        list.first = tmp;
    }
    else
    {
        list.last -> next = tmp;
    }
    list.last = tmp;
}

bool search(List list, ListEl * currentElement, int searchedNumber)
{
    if (list.first == nullptr)
    {
        return 1;
    }
    if (currentElement != nullptr)
    {  
        if (currentElement -> number == searchedNumber)
        {
            return 0;
        }
        return search(list, currentElement -> next, searchedNumber);
    }
    return 1;
}

bool deleteElement(List & list, ListEl * currentElement, int deletedNumber)
{
    if (deletedNumber == list.first -> number)
    {
        if (list.first == list.last)
        {
            delete currentElement;
            currentElement = nullptr;
            constrList(list);
        }
        else
        {
            list.first = currentElement -> next;
            delete currentElement;
            currentElement = nullptr;
        }
        return 0;
    }
    if (currentElement -> next != nullptr)
    {
        if (currentElement -> next -> number == deletedNumber)
        {
            if (currentElement -> next == list.last)
            {
                list.last = currentElement;
            }
            ListEl * tmp = currentElement -> next -> next;
            delete currentElement -> next;
            currentElement -> next = tmp;
            return 0;
        }
        return deleteElement(list, currentElement -> next, deletedNumber);
    }
    return 1;
}

void sortedAdd(List & list, ListEl * currentElement, int inNumber)
{
    if (currentElement != nullptr)
    {
        if (inNumber < currentElement -> number)
        {
            ListEl * tmp = new ListEl;
            tmp -> number = currentElement -> number;
            currentElement -> number = inNumber;
            tmp -> next = currentElement -> next;
            currentElement -> next = tmp;
        }
        else
        {
            sortedAdd(list, currentElement -> next, inNumber);
        }
    }
    else
    {
        add(list, inNumber);
    }
}

bool seeAllList(List list, ListEl * currentElement)
{
    if (list.first == nullptr)
    {
        return 1;
    }
    if (currentElement -> next != nullptr)
    {
        seeAllList(list, currentElement -> next);
    }
    std::cout << ' '<< currentElement -> number;
    return 0;
}