#include "lexAnalyzer.h"

using namespace std;
//erase(0, 1);
//pop_back();

// Tested on:
// 1) 1.3E10 -> 1
// 2) 1.3E -> 0
// 3) 1.3 -> 1
// 4) 1. -> 0
// 5) 1 -> 1
// 6) 1E10 -> 1
// 7) 1E -> 0
// 8) 1Efj -> 0
// 9) 10473792 -> 1

int main()
{
    string subStr = "10473792";
    LexAnalyzer check(subStr);
    if (check.mainProcess())
    {
        cout << "True";
    }
    else
    {
        cout << "False";
    }
    cout << endl;
    return 0;
}