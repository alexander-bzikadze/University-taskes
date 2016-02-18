#pragma once

class Graph
{
public:
    Graph();

    ~Graph();

    ///Gets integer and changes its private field size into input integer
    void setSize(int size);

    ///Gets three integer values: two coordinates and a value
    ///Then changes value in the table with current coord.s to the input value
    void setValue(int i, int j, int value);

    ///Returns value of private field size
    int getSize() const;

    ///Returns value from the table with input coord.s
    short getValue(int i, int j) const;

private:
    static int const maxSize = 100;
    short table[maxSize][maxSize];
    int size;
};