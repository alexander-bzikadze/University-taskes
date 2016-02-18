#include "stage.h"

using namespace std;

//const std::vector<std::vector<int>> Stage::table =
const Array2D<int> Stage::table =
    {{1, 1, 3, 3, 3, 1}, 
    {2, 1, 3, 6, 3, 1}, 
    {1, 5, 4, 3, 3, 1},
    {7, 7, 8, 8, 3, 1}};

int Stage::getStage(int i, int j) const
{
    return table[i][j];
}