#include <iostream>
#include <fstream>
#include <string>

using namespace std;

/*
Test {aafgbbba

g
f
s
 3

fgm} gives 6 as an answer.
*/

bool hasChars(string inputString);

void fileCheck(int counter, ifstream & file)
{
    while (!file.eof())
    {
        string subString = "";
        getline(file, subString);
        if (hasChars(subString))
        {
            ++counter;
        }
    }
    cout << counter;
}

bool hasChars(string inputString)
{
    for (int i = 0; i < inputString.size(); ++i)
        {
            if ((inputString[i] != ' ') && (inputString[i] != '\n') && (inputString[i] != '\t'))
            {
                return true;
            }
        }
    return false;
}

int main()
{
    ifstream file("prog3.in", ios::in);
    if (!file)
    {
        cout << "Critical error!";
        return 1;
    }
    int counter = 0;
    fileCheck(counter, file);
    file.close();
    return 0;
}