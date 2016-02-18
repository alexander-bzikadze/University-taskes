#include "stringSearch.h"
#include <fstream>

using namespace std;

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
    if (search.search() != -1)
    {
        cout << "Number a position of the first match: " << search.search();
    }
    else
    {
        cout << "No match found.";
    }
    cout << endl;
    return 0;
}