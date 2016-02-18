#pragma once

class List
{
public:
    List();

    ~List();

    void add(int value);

    void setCurrentFirst();

    bool isCurrentNull();

    void moveFurther();

    int getCurrentValue() const;

private:
    class ListElement
    {
    public:
        ListElement(int value);

        ~ListElement();

        ListElement * add(int value);

        int getValue() const;

        ListElement * getNext() const;
    public:
        int value;
        ListElement * next;
    };

    ListElement * first;
    ListElement * last;
    ListElement * currentElement;
};