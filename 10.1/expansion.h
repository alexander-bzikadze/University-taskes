#pragma once
#include <fstream>
#include "list.h"
#include "graph.h"
#include <iostream>
using namespace std;

class Expansion
{
public:
    Expansion();

    ~Expansion();

    void mainProcess();
private:

    void seeAll();
    void showState(int number);
    void showCities() const;
    bool isAllControlled() const; //extra
    int getStateSize(int number); //extra


    static const int maxCities = 100;
    int numberOfCities;
    static const int maxStates = 50;
    int numberOfStates;
    List states[maxStates] = {};
    Graph cities;
    bool underControl[maxCities] = {};
};