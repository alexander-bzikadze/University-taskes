#pragma once
#include <fstream>

const int maxSize = 1000;

int typeArray(int * array, std::ifstream & file);

void seeOut(int * array, int size);

int fillAuliliaryArray(int * array, int * auxiliaryArray, int size);

int findMaxElement(int * array, int size, int maxRange);
