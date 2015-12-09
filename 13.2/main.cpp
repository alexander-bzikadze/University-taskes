#include "lexAnalyzer.h"
#include <fstream>

using namespace std;

int main()
{
    ifstream file("main.in");
    string sentence = "";
    while (!file.eof())
    {
        string buffer;
        file >> buffer;
        sentence += ' ' + buffer;
    }
    LexAnanyzer check(sentence);
    if (check.mainProcess()) 
    {
        cout << "Reading Failed!" << endl;
    }
    else
    {
        cout << "Succesful Reading!" << endl;
    }
    return 0;
}