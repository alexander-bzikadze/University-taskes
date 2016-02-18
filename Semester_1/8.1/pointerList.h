#pragma once
#include <iostream>

using namespace std;

class PointerList
{
public:
    PointerList();

    ~PointerList();

    void add(int value);

    void deleteElement(int value);

    bool search(int value) const;

    int size() const;

    void print() const;
    
    int pop();

    int top() const;

    void copy(PointerList * subList);

private:
    class PointerListElement
    {
    public:
        PointerListElement(int value);

        ~PointerListElement();

        void addChild(int value);

        void deleteChild();

        int getValue() const;

        PointerListElement * getNext() const;

        void noChildren();

        void insert(int value);

    private:
        int value;
        PointerListElement * next;
    };

    PointerListElement * first;
    PointerListElement * last;
};