#include "list.h"

List::ListElement::ListElement(int value) : value(value), next(nullptr) {}

void List::ListElement::addChild(ListElement *newElement)
{
    next = newElement;
}

void List::ListElement::deleteChild()
{
    ListElement *deletedElement = next;
    next = next->next;
    delete deletedElement;
}

int List::ListElement::getValue() const
{
    return value;
}

List::ListElement *List::ListElement::getNext() const
{
    return next;
}

List::List() : first(nullptr), iterator(nullptr), last(nullptr) {}

List::~List()
{
    while (first != nullptr)
    {
        pop();
    }
}

void List::add(int value)
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

void List::deleteElement(int value)
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

int List::pop()
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

void List::setIteratorFirst()
{
    iterator = first;
}

void List::moveIteratorForward()
{
    iterator = iterator->getNext();
}

bool List::isIteratorNullptr()
{
    return iterator == nullptr;
}

int List::getIteratorValue() const
{
    return iterator->getValue();
}
