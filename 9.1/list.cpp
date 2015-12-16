#include "list.h"

List::ListElement::ListElement(string const &word)
    : word(word), frequency(1), next(nullptr)
{
}

List::ListElement::~ListElement()
{
}

void List::ListElement::addChild(string const &word)
{
    ListElement * newElement = new ListElement(word);
    next = newElement;
}

void List::ListElement::addFrequency()
{
    ++frequency;
}

string List::ListElement::getWord() const
{
    return word;
}

long long List::ListElement::getFrequency() const
{
    return frequency;
}

List::ListElement * List::ListElement::getNext() const
{
    return next;
}

List::List()
{
    first = nullptr;
    last = nullptr;
}

List::~List()
{
    ListElement * currentElement = first;
    ListElement * deletedElement = nullptr;
    while (currentElement != nullptr)
    {
        deletedElement = currentElement;
        currentElement = currentElement->getNext();
        delete deletedElement;
    }
    deletedElement = nullptr;
    first = nullptr;
    last = nullptr;
}

void List::add(string const &word)
{
    if (first == nullptr)
    {
        ListElement * newElement = new ListElement(word);
        first = newElement;
        last = newElement;
    }
    else
    {
        if (!check(word))
        {
            last->addChild(word);
            last = last->getNext();
        }
        else
        {
            ListElement * currentElement = first;
            while (currentElement->getWord() != word)
            {
                currentElement = currentElement->getNext();
            }
            currentElement->addFrequency();
        }
    }
}

bool List::check(string const &word)
{
    ListElement * currentElement = first;
    while (currentElement != nullptr && currentElement->getWord() != word)
    {
        currentElement = currentElement->getNext();
    }
    return currentElement != nullptr;
}

void List::print()
{
    ListElement * currentElement = first;
    while (currentElement != nullptr)
    {
        cout << currentElement->getWord() << " - " << currentElement->getFrequency() << endl;
        currentElement = currentElement->getNext();
    }
}

bool List::doExist() const
{
    return first != nullptr;
}

int List::size() const
{
    int size = 0;
    ListElement * currentElement = first;
    while (currentElement != nullptr)
    {
        ++size;
        currentElement = currentElement->getNext();
    }
    return size;
}