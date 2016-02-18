#pragma once

struct ListEl
{
    int number;
    ListEl * next;
};

struct List
{
    ListEl * first;
    ListEl * last;
};

void constrList(List & list);

void add(List & list, int number);

bool search(List list, ListEl * currentElement, int searchedNumber);

bool deleteElement(List & list, ListEl *  currentElement, int deletedNumber);

void sortedAdd(List & list, ListEl * currentElement, int inNumber);

bool seeAllList(List list, ListEl * currentElement);