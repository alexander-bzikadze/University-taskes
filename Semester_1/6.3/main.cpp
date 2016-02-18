#include <iostream>

#include "cycleList.h"

using namespace std;

void killingProcess()
{
    int k = 0;
    cout << "Enter the k value." << endl;
    cin >> k;
    int squadSize = 0;
    cout << "Enter the squadSize value." << endl;
    cin >> squadSize;
    CycleList * list = constructList();
    constructCycleList(list, squadSize);
    // seeAllList(list);
    delition(list, k);
    cout << "In order to survive stand on following positions: ";
    seeAllList(list);
    cout << "Thank you for using killingProcess advice. Farewell!";
}

int main()
{
    killingProcess();
    return 0;
}