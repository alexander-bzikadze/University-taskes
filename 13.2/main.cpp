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
    LexAnalyzer check(sentence);
    if (check.mainProcess()) 
    {
        cout << "Succesful Reading!" << endl;
    }
    else
    {
        cout << "Reading Failed!" << endl;
    }
    return 0;
}