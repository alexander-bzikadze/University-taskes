#include <iostream>
#include <string>
#include "reader.h"

using namespace std;

int main()
{
    bool command = false;

    cout << "Type 1 to use stack on array and 0 to use stack on list" << endl;
    cin >> command;
    if (command)
    {
        cout << "You're currently using array for calculating." << endl;
        cout << "Type your sentence." << endl;
        Reader<ArrayStack> run;
        run.read();
        run.calculate();
        cout << "Current result is ";
        cout << run.result();
    }
    else
    {
        cout << "You're currently using list for calculating." << endl;
        cout << "Type your sentence." << endl;
        Reader<Stack> run;
        run.read();
        run.calculate();
        cout << "Current result is ";
        cout << run.result();
    }
    cout << endl << "Farewell!" << endl;
    return 0;
}