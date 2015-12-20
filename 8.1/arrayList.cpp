#include "arrayList.h"

ArrayList::ArrayListElement::ArrayListElement()
    : value(0), next(-1)
{
}

ArrayList::ArrayListElement::~ArrayListElement()
{
}

void ArrayList::ArrayListElement::inputData(int value)
{
    this->value = value;
}

void ArrayList::ArrayListElement::addChild(int index)
{
    next = index;
}

int ArrayList::ArrayListElement::getValue() const
{
    return value;
}

int ArrayList::ArrayListElement::getNext() const
{
    return next;
}

ArrayList::ArrayList()
    : first(-1), last(-1)
{
    std::fill(array, array + maxSize, ArrayListElement());
}

ArrayList::~ArrayList()
{
    // array[maxSize] = {};
    // first = -1;
    // last = -1;
}

void ArrayList::add(int value)
{
    if (first == -1)
    {
        first = 0;
        last = 0;
        array[last].inputData(value);
    }
    else
    {
        int index = last + 1;
        while (index < maxSize && array[index].getNext() != -1)
        {
            ++index;
        }
        if (index == maxSize)
        {
            while (index < last && array[index].getNext() != -1)
            {
                ++index;
            }
            if (last == index)
            {
                cout << "Lol!" << endl;
                return;
            }
        }
        array[index].inputData(value);
        array[last].addChild(index);
        last = index;
    }
}

void ArrayList::deleteElement(int value)
{
    int index = first;
    if (array[index].getValue() == value)
    {
        if (first != last)
        {
            first = array[index].getNext();
        }
        else
        {
            first = -1;
            last = -1;
        }
        array[index].~ArrayListElement();
        index = 0;
        return;
    }
    while (array[array[index].getNext()].getValue() != value && array[index].getNext() != -1)
    {
        index = array[index].getNext();
    }
    int deletedIndex = array[index].getNext();
    if (deletedIndex == last)
    {
        last = index;
        array[index].addChild(-1);
    }
    else
    {
        array[index].addChild(array[deletedIndex].getNext());
    }
    array[deletedIndex].~ArrayListElement();
    deletedIndex = 0;
    index = 0;
}

bool ArrayList::search(int value)
{
    int index = first;
    while (index != -1 && array[index].getValue() != value)
    {
        index = array[index].getNext();
    }
    if (array[index].getValue() == value)
    {
        return true;
    }
    else
    {
        return false;
    }
    index = 0;
}

int ArrayList::size()
{
    int size = 0;
    int index = first;
    while (index != -1)
    {
        index = array[index].getNext();
        ++size;
    }
    index = 0;
    return size;
}

void ArrayList::print()
{
    int index = first;
    while (index != -1)
    {
        cout << array[index].getValue() << ' ';
        index = array[index].getNext();
    }
    cout << endl;
}

int ArrayList::pop() 
{
    if (first == -1)
    {
        return 0;
    }
    int valueWeSeek = array[first].getValue();
    int indexWeDelete = first;
    first = array[first].getNext();
    if (first == -1)
    {
        last = -1;
    }
    array[indexWeDelete].addChild(-1);
    return valueWeSeek;
}

int ArrayList::top() const
{
    return array[first].getValue();
}

void ArrayList::copy(ArrayList * subList)
{
    while (subList->size() > 0)
    {
        add(subList->pop());
    }
}