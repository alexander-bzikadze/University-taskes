#include "arrayList.h"
#include "pointerList.h"

template <class T>
class AbstractList
{
public:
    AbstractList() : globalIterator(0)
    {
    }

    ~AbstractList() 
    {
    }

    void add(int value) 
    {
        list.add(value);
    }

    void print()
    {
        list.print();
    }

    int getGlobal() const
    {
        return globalIterator;
    }

    void sort()
    {
        if (list.size() == 0)
        {
            return;
        }
        T * subList = new T();
        globalIterator++;
        while (list.size() > 0)
        {
            subList->add(list.pop());
        }
        subList = mergeSort(subList);
        while (subList->size() > 0)
        {
            list.add(subList->pop());
        }
        delete subList;
        globalIterator--;
    }

private:
    int globalIterator;

    T list;

    T * split(T * list);

    T * merge(T * firstList, T * secondList);

    T * mergeSort(T * firstList);

};

template <class T>
T * AbstractList<T>::split(T * list)
{
    T * subList = new T();
    for(int i = 0; i < list->size() / 2 + 1; ++i)
    {
        subList->add(list->pop());
    }
    return subList;
}

template <class T>
T * AbstractList<T>::merge(T * firstList, T * secondList)
{
    globalIterator++;
    T * mergedList = new T();
    while (firstList->size() > 0 && secondList->size() > 0)
    {
        if (firstList->top() < secondList->top())
        {
            mergedList->add(firstList->pop());
        }
        else
        {
            mergedList->add(secondList->pop());
        }
    }
    if (firstList->size() > 0)
    {
        mergedList->copy(firstList);
    }
    else if (secondList->size() > 0)
    {
        mergedList->copy(secondList);
    }
    globalIterator--;
    delete firstList;
    globalIterator--;
    delete secondList;
    return mergedList;
}

template <class T>
T * AbstractList<T>::mergeSort(T * firstList)
{
    globalIterator++;
    T * secondList = split(firstList);
    if (firstList->size() > 1)
    {
        firstList = mergeSort(firstList);
    }
    if (secondList->size() > 1)
    {
        secondList = mergeSort(secondList);
    }
    return merge(firstList, secondList);
}