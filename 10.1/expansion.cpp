#include "expansion.h"

using namespace std;

Expansion::Expansion()
{
    ifstream file("main.in");
    if (!file.is_open())
    {
        cout << "File!!!" << endl;
        return;
    }
    file >> numberOfCities;
    cities.setSize(numberOfCities);
    int numberOfRoads = 0;
    file >> numberOfRoads;
    int firstCity = 0;
    int secondCity = 0;
    int length = 0;
    cities = Graph();
    for (int i = 0; i < numberOfRoads; ++i)
    {
        file >> firstCity >> secondCity >> length;
        cities.setValue(firstCity - 1, secondCity - 1, length); //to use properly in graph
    }
    file >> numberOfStates;
    int capital = 0;
    for (int i = 0; i < numberOfStates; ++i)
    {
        file >> capital;
        states[i].add(capital - 1); //same reason as it was with graphs
        underControl[capital - 1] = true;
    }
    file.close();
}

Expansion::~Expansion()
{
}

void Expansion::showState(int number)
{
    states[number].setCurrentFirst();
    while (!states[number].isCurrentNull())
    {
        cout << ' ' << states[number].getCurrentValue() + 1; //as we stack them as we would use in graph
        states[number].moveFurther();
    }
    cout << endl;
}

void Expansion::seeAll()
{
    cout << "Table of Cities: " << endl;
    showCities();
    cout << "States are:" << endl;
    for (int i = 0; i < numberOfStates; ++i)
    {
        cout << "State " << i + 1 << ':';
        showState(i);
    }
}

void Expansion::showCities() const
{
    for (int i = 0; i < numberOfCities; ++i)
    {
        for (int j = 0; j < numberOfCities; ++j)
        {
            cout << cities.getValue(i, j) << ' ';
        }
        cout << endl;
    }
}

int Expansion::getStateSize(int number)
{
    states[number].setCurrentFirst();
    int size = 0;
    while (!states[number].isCurrentNull())
    {
        ++size;
        states[number].moveFurther();
    }
    return size;
}

bool Expansion::isAllControlled() const
{
    bool result = true;
    for (int i = 0; i < numberOfCities; ++i)
    {
        result &= underControl[i];
    }
    return result;
}

void Expansion::mainProcess()
{
    int SI = 0; //Special i = i % numberOfStates
    int minJ = 0;
    for (int i = 0; !isAllControlled(); ++i)
    {
        SI = i % numberOfStates;

        while (underControl[minJ])
        {
            minJ++;
        }
        int addedCity = minJ;
        states[SI].setCurrentFirst();
        int bestOrigin = states[SI].getCurrentValue();
        while (!states[SI].isCurrentNull())
        {
            int originCity = states[SI].getCurrentValue();
            states[SI].moveFurther();
            for (int j = minJ; j < numberOfCities; ++j)
            {
                if ((cities.getValue(originCity, j) != 0)
                 && !underControl[j] 
                 && (cities.getValue(bestOrigin, addedCity) == 0 || 
                 cities.getValue(originCity, j) < cities.getValue(bestOrigin, addedCity)))
                {
                    bestOrigin = originCity;
                    addedCity = j;
                }
            }
        }
        if (cities.getValue(bestOrigin, addedCity))
        {
            states[SI].add(addedCity);
            underControl[addedCity] = true;
        }
    }
    seeAll();
}
