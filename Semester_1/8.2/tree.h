#pragma once

#include <iostream>

class Tree
{
public:
    Tree();

    ~Tree();

    void show() const;

    void add(int value);

    bool check(int value) const;

    void deleteValue(int value);

private:
    class Node
    {
    public:
        Node(int value);

        ~Node();

        int getValue() const;

        Node * getRightChild() const;

        Node * getLeftChild() const;

        void addChild(int const , bool command);

        void showNode() const;

        // void changeValue(int const &value);

        void felicide(bool isRight);

        void adoptRoot(Node * root);

        void deleteRoot();

    private:
        int value;

        Node * rigthChild;
        Node * leftChild;
    };

    void fatherInLaw();

    Node * root;
};