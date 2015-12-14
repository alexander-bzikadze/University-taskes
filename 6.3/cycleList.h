#pragma once

#include <iostream>

struct CycleListElement;

struct CycleList; 

CycleList *  constructList();

void appendElement(CycleList * list, int inNumber);

void constructCycleList(CycleList * list, int squadSize);

void deleteElement(CycleList * list, CycleListElement * currentElement);

void delition(CycleList * list, int k);

void seeAllList(CycleList * list);