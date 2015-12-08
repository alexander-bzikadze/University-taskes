#include <iostream>

#include "cycleList.h"

using namespace std;

void killingProcess()
{
    int k = 0;
    cout << "Enter the k value." << endl;
    cin >> k;
    CycleList * list;
    list = constructList();
    constructSycarii(list);
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