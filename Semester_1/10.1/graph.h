#pragma once

class Graph
{
public:
    Graph();

    ~Graph();

    void setSize(int size);

    void setValue(int i, int j, int value);

    int getSize() const;

    short getValue(int i, int j) const;

private:
    static int const maxSize = 100;
    short table[maxSize][maxSize];
    int size;
};