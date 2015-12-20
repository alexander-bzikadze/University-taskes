#include "pointerList.h"

PointerList::PointerListElement::PointerListElement(int value)
    : value(value), next(nullptr)
{
}

PointerList::PointerListElement::~PointerListElement()
{

}

void PointerList::PointerListElement::addChild(int  value)
{
    PointerListElement * newElement = new PointerListElement(value);
    next = newElement;
}

void PointerList::PointerListElement::deleteChild()
{
    PointerListElement * deletedElement = next;
    next = next->next;
    delete deletedElement;
    deletedElement = nullptr;
}

int PointerList::PointerListElement::getValue() const
{
    return value;
}

PointerList::PointerListElement * PointerList::PointerListElement::getNext() const
{
    return next;
}

PointerList::PointerList()
    : first(nullptr), last(nullptr)
{
}

PointerList::~PointerList()
{
    PointerListElement * currentElement = first;
    PointerListElement * deletedElement = nullptr;
    while (currentElement != nullptr)
    {
        deletedElement = currentElement;
        currentElement = currentElement->getNext();
        delete deletedElement;
    }
    first = nullptr;
    last = nullptr;
    deletedElement = nullptr;
}

void PointerList::add(int value)
{
    if (first == nullptr)
    {
        PointerListElement * currentElement = new PointerListElement(value);
        first = currentElement;
        last = currentElement;
        currentElement = nullptr;
    }
    else
    {
        last->addChild(value);
        last = last->getNext();
    }
}

void PointerList::deleteElement(int value)
{
    if (first == nullptr)
    {
        return;
    }
    PointerListElement * currentElement = first;
    if (currentElement->getValue() == value)
    {
        if (last == first)
        {
            last = nullptr;
        }
        first = first->getNext();
        delete currentElement;
        currentElement = nullptr;
    }
    else 
    {
        while (currentElement->getNext() != nullptr && currentElement->getNext()->getValue() != value)
        {
            currentElement = currentElement->getNext();
        }
        if (currentElement->getNext() != nullptr)
        {
            if (currentElement->getNext() == last)
            {
                last = currentElement;
            }
            currentElement->deleteChild();
        }
    }
    currentElement = nullptr;
}

bool PointerList::search(int value) const
{
    PointerListElement * currentElement = first;
    while (currentElement != nullptr && currentElement->getValue() != value)
    {
        currentElement = currentElement->getNext();
    }
    if (currentElement != nullptr)
    {
        currentElement = nullptr;
        return true;
    }
    else
    {
        currentElement = nullptr;
        return false;
    }
}

int PointerList::size() const
{
    PointerListElement * currentElement = first;
    int size = 0;
    while (currentElement != nullptr)
    {
        currentElement = currentElement->getNext();
        ++size;
    }
    currentElement = nullptr;
    return size;
}

void PointerList::print() const
{
    PointerListElement * currentElement = first;
    while (currentElement != nullptr)
    {
        cout << currentElement->getValue() << ' ';
        currentElement = currentElement->getNext();
    }
    currentElement = nullptr;
    std::cout << std::endl;
}

int PointerList::pop()
{
    PointerListElement * deletedElement = first;
    int valueWeSeek = 0;
    if (deletedElement != nullptr)
    {
        if (deletedElement == last)
        {
            last = nullptr;
        }
        valueWeSeek = first->getValue();
        first = first->getNext();
        delete deletedElement;
        deletedElement = nullptr;
    }
    return valueWeSeek;
}

int PointerList::top() const
{
    if (first != nullptr)
    {
        return first->getValue();
    }
    else
    {
        return 0;
    }
}

void PointerList::copy(PointerList * subList)
{
    while (subList->size() > 0)
    {
        add(subList->pop());
    }
}