#pragma once
#include <fstream>
#include <iostream>

#include "graph.h"

class SpanningTree
{
public:
    SpanningTree();

    ~SpanningTree();

    void mainProcess();

    void print();

    int const minRoad(int j);
private:
    bool allAreMarked() const;

    void setClear(int i, int above);

    static const int maxSize = 100;
    bool marked[maxSize] = {};
    Graph graph;

};