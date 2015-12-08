#include "list.h"

List::ListElement::ListElement(int value)
    : value(value), next(nullptr)
{
    this->value = value;
    next = nullptr;
}

List::ListElement::~ListElement()
{}

List::ListElement * List::ListElement::add(int value)
{
    ListElement * newElement = new ListElement(value);
    next = newElement;
    return newElement;
}

int List::ListElement::getValue() const
{
    return value;
}

List::ListElement * List::ListElement::getNext() const
{
    return next;
}

List::List()
    : first(nullptr), last(nullptr), currentElement(nullptr)
{
    first = nullptr;
    last = nullptr;
    currentElement = nullptr;
}

List::~List()
{
    currentElement = first;
    while (currentElement != nullptr)
    {
        first = currentElement;
        currentElement = currentElement->getNext();
        delete first;
    }
    first = nullptr;
    last = nullptr;
}

void List::add(int value)
{
    if (first == nullptr)
    {
        ListElement * newElement = new ListElement(value);
        first = newElement;
        last = newElement;
    }
    else
    {
        last->add(value);
        last = last->getNext();
    }
}

void List::setCurrentFirst()
{
    currentElement = first;
}

bool List::isCurrentNull()
{
    return currentElement == nullptr;
}

void List::moveFurther()
{
    currentElement = currentElement->getNext();
}

int List::getCurrentValue() const
{
    return currentElement->getValue();
}

