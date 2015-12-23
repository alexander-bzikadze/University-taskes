#include "stage.h"

using namespace std;

//const std::vector<std::vector<int>> Stage::table =
const Array2D<int> Stage::table =
    {{1, 1, 3, 3}, 
    {2, 1, 3, 1}, 
    {1, 3, 4, 3},
    {5, 5, 6, 6}};

int Stage::getStage(int i, int j) const
{
    return table[i][j];
}