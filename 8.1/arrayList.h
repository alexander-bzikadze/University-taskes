#pragma once
#include <iostream>

using namespace std;

class ArrayList
{
public:
    ArrayList();

    ~ArrayList();

    void add(int value);

    void deleteElement(int value);

    bool search(int value);

    int size();

    void print();

    int pop();

    int top() const;

    void copy(ArrayList * subList);

private:
    class ArrayListElement
    {
    public:
        ArrayListElement();

        ~ArrayListElement();

        void inputData(int value);

        void addChild(int index);

        int getValue() const;

        int getNext() const;

    private:
        int value;

        int next;
    };

    int const static maxSize = 100;

    int first;

    int last;

    ArrayListElement array[maxSize];
};