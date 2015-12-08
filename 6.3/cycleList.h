#pragma once

#include <iostream>

struct CycleListElement;

struct CycleList; 

CycleList *  constructList();

void appendElement(CycleList * list, int inNumber);

void constructSycarii(CycleList * list);

void deleteElement(CycleList * list, CycleListElement * currentElement);

void delition(CycleList * list, int k);

void seeAllList(CycleList * list);