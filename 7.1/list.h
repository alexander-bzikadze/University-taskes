#pragma once
#include <iostream>
#include <string>
#include <fstream>

struct ListElement;

struct List;

List * createList();

void append(List * list, std::string inNumber, std::string inName);

bool inputList(List * list);

void deleteList(List * list);

int sizeList(List * list);

List * splitList(List * list);

bool seeAllList(List * list);

inline bool compareNumber(const ListElement & el1, const ListElement & el2);

inline bool compareName(const ListElement & el1, const ListElement & el2);

List * merge(List * first, List * second, bool command);