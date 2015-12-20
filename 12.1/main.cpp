#include "stringSearch.h"
#include <fstream>

int main()
{
    fstream file("main.in");
    if (!file.is_open())
    {
        cout << "File!" << endl;
        return 1;
    }
    string mainString = "";
    string subString = "";
    file >> mainString;
    cin >> subString;
    StringSearch search(mainString, subString);
    cout << search.search() << endl;
    return 0;
}