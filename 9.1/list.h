#pragma once
#include <string>
#include <iostream>

using namespace std;

class List
{
public:
    List();

    ~List();

    void add(string const &word);

    bool check(string const &word);

    void print();

    bool doExist() const;

    int size() const;

private:
    class ListElement
    {
    public:
        ListElement(string const &word);

        ~ListElement();

        void addChild(string const &word);

        void addFrequency();

        string getWord() const;

        long long getFrequency() const;

        ListElement * getNext() const;

    private:
        string word;
        long long frequency;
        ListElement * next;
    };

    ListElement * first;
    ListElement * last;
};