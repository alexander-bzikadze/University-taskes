#include "list.h"
using namespace std;

struct ListElement
{
    string number;
    ListElement * next;
    string name;
};

struct List
{
    ListElement * first;
    ListElement * last;
};

List * createList()
{
    List * list = new List;
    list->first = nullptr;
    list->last = nullptr;
    return list;
}

void append(List * list, string inNumber, string inName)
{
    ListElement * tmp = new ListElement;
    tmp->number = inNumber;
    tmp->name = inName;
    tmp->next = nullptr;
    if (list->first == nullptr)
    {
        list->first = tmp;
    }
    else
    {
        list->last->next = tmp;
    }
    list->last = tmp;
}

bool inputList(List * list)
{
    ifstream file("main.in");
    if (!file.is_open())
    {
        return 1;
    }
    string inNumber = "";
    string inName = "";
    while (!file.eof())
    {
        file >> inName >> inNumber;
        // std::cout << inName << ' ' << inNumber << std::endl;
        append(list, inNumber, inName);
    }
    file.close();
    return 0;
}

void deleteList(List * list)
{
    ListElement * currentElement = list->first;
    while (currentElement != nullptr)
    {
        // std::cout << currentElement -> name << std::endl;
        ListElement * tmp = currentElement;
        currentElement = currentElement->next;
        delete tmp;
    }
    list->first = nullptr;
    list->last = nullptr;
}

int sizeList(List * list)
{
    int size = 0;
    ListElement * currentElement = list->first;
    while (currentElement != nullptr)
    {
        currentElement = currentElement->next;
        ++size;
    }
    return size;
}

void appendList(List * list, ListElement * currentElement)
{
    while (currentElement != nullptr)
    {
        // std::cout << currentElement -> name << std::endl;
        append(list, currentElement->number, currentElement -> name);
        currentElement = currentElement->next;
    }
}

List * splitList(List * list)
{
    ListElement * currentElement = list->first;
    for (int i = 0; i < sizeList(list) / 2 - 1; ++i)
    {
        currentElement = currentElement->next;
    }
    list->last = currentElement;
    currentElement = currentElement->next;
    List * subList = createList();
    List * listToDelete = createList();
    listToDelete->first = currentElement;
    listToDelete->last = list->last;
    appendList(subList, currentElement);
    deleteList(listToDelete);
    list->last->next = nullptr;
    return subList;
}

bool seeAllList(List * list)
{
    if (list->first == nullptr)
    {
        return 1;
    }
    ListElement * currentElement = list->first;
    while (currentElement != nullptr)
    {
        cout << currentElement -> name << " - " << currentElement -> number << endl;
        currentElement = currentElement->next;
    }
    return 0;
}

inline bool compareNumber(const ListElement & el1, const ListElement & el2)
{
    return el1.number < el2.number;
}

inline bool compareName(const ListElement & el1, const ListElement & el2)
{
    return el1.name < el2.name;
}

List * merge(List * first, List * second, bool command)
{
    List * mergedList = createList();
    ListElement *  firstCurrentElement = first->first;
    ListElement * secondCurrentElement = second->first;
    while (firstCurrentElement != nullptr && secondCurrentElement)
    {
        if (command)
        {
            if (compareName(*firstCurrentElement, *secondCurrentElement))
            {
                append(mergedList, firstCurrentElement->number, firstCurrentElement->name);
                firstCurrentElement = firstCurrentElement->next;
            }
            else
            {
                append(mergedList, secondCurrentElement->number, secondCurrentElement->name);
                secondCurrentElement = secondCurrentElement->next;
            }
        }
        else
        {
            if (compareNumber(*firstCurrentElement, *secondCurrentElement))
            {
                append(mergedList, firstCurrentElement->number, firstCurrentElement->name);
                firstCurrentElement = firstCurrentElement->next;
            }
            else
            {
                append(mergedList, secondCurrentElement->number, secondCurrentElement->name);
                secondCurrentElement = secondCurrentElement->next;
            }
        }
    }
    if (firstCurrentElement == nullptr)
    {
        appendList(mergedList, secondCurrentElement);
    }
    else
    {
        // std::cout << '!';
        appendList(mergedList, firstCurrentElement);
    }
    deleteList(first);
    deleteList(second);
    return mergedList;
}