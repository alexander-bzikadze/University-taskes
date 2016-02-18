#include "tree.h"

using namespace std;

int main()
{
    Tree tree;
    char input[100] = "(+ (+ 1 2) (+ 3 4))"; //
    tree.build(input);
    tree.print();
    cout << " = " <<tree.getValue() << endl;
    return 0;
}