#include "graph.h"
using namespace std;

Graph::Graph()
    : size(0)
{
    table[maxSize][maxSize] = {};
}

Graph::~Graph()
{
}

void Graph::setSize(int size)
{
    this->size = size;
}

void Graph::setValue(int i, int j, int value)
{
    if (i == j)
    {
        return;
    }
    table[i][j] = value;
}

int Graph::getSize() const
{
    return size;
}

short Graph::getValue(int i, int j) const
{
    return table[i][j];
}