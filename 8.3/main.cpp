#include "tree.h"

int main()
{
    Tree tree;
    char input[100] = "(+ (- (* 56 41) 2000) 81)"; //
    tree.build(input);
    tree.print();
    cout << " = " <<tree.getValue() << endl;
    return 0;
}