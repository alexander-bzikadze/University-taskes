#pragma once
#include <algorithm>
#include <vector>

template <typename T>
using Array2D = typename std::vector<std::vector<T>>;
    
class Stage
{
public:
    int getStage(int i, int j) const;

private:
    static const Array2D<int> table;
};