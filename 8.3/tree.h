#pragma once
#include <iostream>

class Tree
{
public:
    Tree();

    ~Tree();

    void build(char * string);

    void print();

    int getValue();

private:
    class TreeElement
    {
    public:
        TreeElement(int value = 0);

        TreeElement(char operation);

        ~TreeElement();

        void setChild(bool isRight, TreeElement * newChild);

        void deleteChild(bool isRight);

        int getValue();

        bool hasSons();

        char * build(char * string);

        void print();

    private:
        int value;
        char operation;
        TreeElement * left;
        TreeElement * right;
    };

    TreeElement * root;
};