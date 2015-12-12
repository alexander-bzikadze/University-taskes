#pragma once
#include <vector>
#include <iostream>

template <typename T>
class BasicArrayList
{
public:
    BasicArrayList() : array(), iterator() {}

    ///Pushes back current value
    void add(T value);

    ///Searches for value and deletes it, if found
    void deleteElement(T value);

    ///Deletes first element and returnes it value
    T pop();

    ///Sets iterator 0
    void setIteratorFirst();

    ///Increments iterator
    void moveIteratorForward();

    ///Returns result of comparison of iterator to array size
    bool isIteratorNull() const;

    ///Returns value, which iterator points on
    T getIteratorValue() const;

private:
    std::vector<T> array;
    size_t iterator;
};

template <typename T>
void BasicArrayList<T>::add(T value)
{
    array.push_back(value);
}

template <typename T>
void BasicArrayList<T>::deleteElement(T value)
{
    setIteratorFirst();
    while (!isIteratorNull() && array[iterator] != value)
    {
        moveIteratorForward();
    }
    if (!isIteratorNull())
    {
        array.erase(array.begin() + iterator);
    }
    setIteratorFirst();
}

template <typename T>
T BasicArrayList<T>::pop()
{
    if (array.size() != 0)
    {
        T returnedValue = array[0];
        array.erase(array.begin());
        return returnedValue;
    }
    return T();
}

template <typename T>
void BasicArrayList<T>::setIteratorFirst()
{
    iterator = 0;
}

template <typename T> 
void BasicArrayList<T>::moveIteratorForward()
{
    ++iterator;
}

template <typename T>
bool BasicArrayList<T>::isIteratorNull() const
{
    return iterator == array.size();
}

template <typename T>
T BasicArrayList<T>::getIteratorValue() const
{
    return array[iterator];
}
