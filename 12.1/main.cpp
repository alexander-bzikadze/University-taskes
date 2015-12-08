#include "stringSearch.h"
#include <fstream>

int main()
{
    fstream file("main.in");
    if (!file.is_open())
    {
        cout << "File!" << endl;
    }
    string mainString = "";
    string subString = "";
    file >> mainString;
    cin >> subString;
    StringSearch search = StringSearch(mainString, subString);
    cout << search.search() << endl;
    return 0;
}