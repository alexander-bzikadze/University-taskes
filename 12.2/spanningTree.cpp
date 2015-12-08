#include "spanningTree.h"
using namespace std;

SpanningTree::SpanningTree() : graph()
{
    ifstream file("main.in");
    if (!file.is_open())
    {
        cout << '!' << endl;
        return;
    }   
    int size = 0;
    file >> size;
    graph.setSize(size);
    int value = 0;
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            file >> value;
            graph.setValue(i, j, value);
        }
    }
}

SpanningTree::~SpanningTree()
{

}

void SpanningTree::print()
{
    for (int i = 0; i < graph.getSize(); ++i)
    {
        for (int j = 0; j < graph.getSize(); ++j)
        {
            cout << graph.getValue(i, j) << ' ';
        }
        cout << endl;
    }
}

int SpanningTree::minRoad(int j)
{
    int min = 0;
    for (int i = 0; i < graph.getSize(); ++i)
    {
        if (!marked[i] && graph.getValue(i, j)
         && (!graph.getValue(min, j) || marked[min]
         || graph.getValue(min, j) > graph.getValue(i, j)))
        {
            min = i;
        }
    }
    return min;
}

void SpanningTree::setClear(int i, int above)
{
    for (int j = 0; j < graph.getSize(); ++j)
    {
        if (j != above)
        {
            graph.setValue(i, j, 0);
        }
    }
    marked[i] = true;
}

bool SpanningTree::allAreMarked() const
{
    bool result = true;
    for (int i = 0; i < graph.getSize(); ++i)
    {
        result &= marked[i];
    }
    return result;
}

void SpanningTree::mainProcess()
{
    int minI = 0;
    int minJ = 0;
    for (int j = 0; j < graph.getSize(); ++j)
    {
        if (!graph.getValue(minI, minJ)
         || graph.getValue(minI, minJ) > graph.getValue(minRoad(j), j))
        {
            minJ = minRoad(j);
            minI = j;
        }
    }
    setClear(minI, minJ);
    setClear(minJ, maxSize);
    while (!allAreMarked())
    {
        int minI = 0;
        int minJ = 0;
        for (int j = 0; j < graph.getSize(); ++j)
        {
            if (marked[j]
             && (!graph.getValue(minI, minJ)
             || graph.getValue(minI, minJ) > graph.getValue(minRoad(j), j)))
            {
                minI = minRoad(j);
                minJ = j;
            }
        }
        setClear(minI, minJ);
    }
}
