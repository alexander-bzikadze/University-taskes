#include "stage.h"

using namespace std;

//const std::vector<std::vector<int>> Stage::table =
const Array2D<int> Stage::table =
    {{2, 3, 1}, 
    {3, 1, 2}};

int Stage::getStage(int i, int j) const
{
    return table[i][j];
}