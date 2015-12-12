#pragma once
#include "BasicPointerList.h"
#include "BasicArrayList.h"

template <typename T>
class List
{
public:
    List() : list() {}

    ///Adds new element to the list
    void add(T value)
    {
        list.add(value);
    }

    ///Deletes element with chosen value
    void deleteElement(T value)
    {
        list.deleteElement(value);
    }

    ///Deletes first element and returns its value
    T pop()
    {
        return list.pop();
    }

    ///Returns value of the first element
    T top()
    {
        list.setIteratorFirst();
        return list.getIteratorValue();
    }

    ///Prints the whole list
    void print();

    ///Returns boolean value after searching for an element
    bool search(T value);

private:
    BasicPointerList<T> list;
    // BasicArrayList<T> list;
};

template <typename T>
void List<T>::print()
{
    list.setIteratorFirst();
    while (!list.isIteratorNull())
    {
        std::cout << list.getIteratorValue() << ' ';
        list.moveIteratorForward();
    }
    std::cout << std::endl;
    list.setIteratorFirst();
}

template <typename T>
bool List<T>::search(T value)
{
    list.setIteratorFirst();
    while (!list.isIteratorNull())
    {
        if (list.getIteratorValue() == value)
        {
            list.setIteratorFirst();
            return true;
        }
        list.moveIteratorForward();
    }
    list.setIteratorFirst();
    return false;
}