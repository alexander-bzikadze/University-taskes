#include "reader.h"

int main()
{
    Reader run = Reader();
    run.read();
    run.fillStacks();
    run.result();
    return 0;
}