#include "reader.h"
using namespace std;

int main()
{
    Reader run;
    cout << "Enter a string to be checked." << endl;
    run.read();
    run.check();
    if (run.result())
    {
        cout << "None mistakes found.\n";
    }
    else
    {
        cout << "Mistakes found\n.";
    }
    return 0;
}