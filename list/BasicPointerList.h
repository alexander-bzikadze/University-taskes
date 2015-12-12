#pragma once
#include <iostream>

template <typename T>
class BasicPointerList
{
public:
    BasicPointerList();
    ~BasicPointerList();

    ///Adds new element to the end of the list
    void add(T value);

    ///Searches for an element and deletes it
    void deleteElement(T value);

    ///Deletes first element in the list and returns its value
    T pop();

    ///Sets iterator as first element
    void setIteratorFirst();

    ///Sets iterator as next element
    void moveIteratorForward();

    ///Returns result of comparison iterator to nullptr
    bool isIteratorNull() const;

    ///Returns iterators value
    T getIteratorValue() const;

private:
    class ListElement
    {
    public:
        ListElement(T value = T());

        ///Adds child to the current element
        void addChild(ListElement *newElement);

        ///Deletes child of the current element with no protection
        void deleteChild();

        ///Returns current element's value
        T getValue() const;

        ///Returns pointer to the next element
        ListElement *getNext() const;

    private:
        T value;
        ListElement *next;
    };

    ListElement *first;
    ListElement *iterator;
    ListElement *last;
};

template <typename T>
BasicPointerList<T>::ListElement::ListElement(T value) : value(value), next(nullptr) {}

template <typename T>
void BasicPointerList<T>::ListElement::addChild(ListElement *newElement)
{
    next = newElement;
}

template <typename T>
void BasicPointerList<T>::ListElement::deleteChild()
{
    ListElement *deletedElement = next;
    next = next->next;
    delete deletedElement;
}

template <typename T>
T BasicPointerList<T>::ListElement::getValue() const
{
    return value;
}

template <typename T>
typename BasicPointerList<T>::ListElement *BasicPointerList<T>::ListElement::getNext() const
{
    return next;
}

template <typename T>
BasicPointerList<T>::BasicPointerList() : first(nullptr), iterator(nullptr), last(nullptr) {}

template <typename T>
BasicPointerList<T>::~BasicPointerList()
{
    while (first != nullptr)
    {
        pop();
    }
}

template <typename T>
void BasicPointerList<T>::add(T value)
{
    if (last == nullptr)
    {
        ListElement *newElement = new ListElement(value);
        first = newElement;
        last = newElement;
        setIteratorFirst();
    }
    else
    {
        ListElement *newElement = new ListElement(value);
        last->addChild(newElement);
        last = last->getNext();
    }
}

template <typename T>
void BasicPointerList<T>::deleteElement(T value)
{
    if (first == last || first->getValue() == value)
    {
        pop();
    }
    else
    {
        setIteratorFirst();
        while (iterator->getNext() != nullptr && iterator->getNext()->getValue() != value)
        {
            moveIteratorForward();
        }
        if (iterator->getNext() != nullptr)
        {
            if (iterator->getNext() == last)
            {
                last = iterator;
            }
            ListElement *newElement = iterator->getNext()->getNext();
            iterator->deleteChild();
            iterator->addChild(newElement);
        }
    }
}

template <typename T>
T BasicPointerList<T>::pop()
{
    if (last == nullptr)
    {
        return T(); 
    }
    if (first == last)
    {
        last = nullptr;
    }
    ListElement *deletedElement = first;
    first = first->getNext();
    setIteratorFirst();
    int value = deletedElement->getValue();
    delete deletedElement;
    return value;
}

template <typename T>
void BasicPointerList<T>::setIteratorFirst()
{
    iterator = first;
}

///There's no nullptr-protection as is supposed to be used with isIteratorNull()
template <typename T>
void BasicPointerList<T>::moveIteratorForward()
{
    iterator = iterator->getNext();
}

template <typename T>
bool BasicPointerList<T>::isIteratorNull() const
{
    return iterator == nullptr;
}

template <typename T>
T BasicPointerList<T>::getIteratorValue() const
{
    if (isIteratorNull())
    {
        return T();
    }
    return iterator->getValue();
}