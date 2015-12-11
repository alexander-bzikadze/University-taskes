#pragma once

template <typename T>
class List
{
public:
    List();
    ~List();

    void add(T value);
    void deleteElement(T value);

    T pop();

    void setIteratorFirst();
    void moveIteratorForward();
    bool isIteratorNullptr();
    T getIteratorValue() const;

private:
    class ListElement
    {
    public:
        ListElement(T value);

        void addChild(ListElement *newElement);
        void deleteChild();

        T getValue() const;
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
List<T>::ListElement::ListElement(T value) : value(value), next(nullptr) {}

template <typename T>
void List<T>::ListElement::addChild(ListElement *newElement)
{
    next = newElement;
}

template <typename T>
void List<T>::ListElement::deleteChild()
{
    ListElement *deletedElement = next;
    next = next->next;
    delete deletedElement;
}

template <typename T>
T List<T>::ListElement::getValue() const
{
    return value;
}

template <typename T>
List<T>::ListElement *List::ListElement::getNext() const
{
    return next;
}

template <typename T>
List<T>::List() : first(nullptr), iterator(nullptr), last(nullptr) {}

template <typename T>
List<T>::~List()
{
    while (first != nullptr)
    {
        pop();
    }
}

template <typename T>
void List<T>::add(T value)
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
void List<T>::deleteElement(T value)
{
    if (first == last)
    {
        pop();
    }
    else
    {
        setIteratorFirst();
        while (iterator->getNext()->getValue() != value && !isIteratorNullptr())
        {
            moveIteratorForward();
        }
        if (!isIteratorNullptr())
        {
            ListElement *newElement = iterator->getNext()->getNext();
            iterator->deleteChild();
            iterator->addChild(newElement);
        }
    }
}

template <typename T>
T List<T>::pop()
{
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
void List<T>::setIteratorFirst()
{
    iterator = first;
}

template <typename T>
void List<T>::moveIteratorForward()
{
    iterator = iterator->getNext();
}

template <typename T>
bool List<T>::isIteratorNullptr()
{
    return iterator == nullptr;
}

template <typename T>
T List<T>::getIteratorValue() const
{
    return iterator->getValue();
}