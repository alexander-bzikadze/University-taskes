#pragma once
#include "list.h"
#include <fstream>

class HashTable
{
public:
    HashTable();

    ~HashTable();

    void mainProcess(); 

private:
    // int const static maxSize = 702;
    int const static maxSize = 65792;

    List list[maxSize];

    void input();

    int hashFunction(string const &word);

    void print();

    // bool HashTable::isFromAlphabet(char const &i);

    // bool HashTable::isFromHighAlphabet(char const &i);

};

bool isFromAlphabet(char i);

bool isFromHighAlphabet(char i);