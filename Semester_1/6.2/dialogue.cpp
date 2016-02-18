#include "dialogue.h"

#include "list.h"

#include <iostream>

void greeting();

void enterCommand(int & command);

void addValue(List & sortedList);

void deleteValue(List & sortedList);

void seeOut(List sortedList);

void greeting()
{
    std::cout << "Use one of the following commands:\n0 - exit;\n1 - enter new value;\n2 - delete a value;\n3 - print the list." << std::endl;
}

void enterCommand(int & command)
{
    std::cout << "Enter a command." << std::endl;
    std::cin >> command;
}

void addValue(List & sortedList)
{
    std::cout << "Enter some value." << std::endl;
    int value = 0;
    std::cin >> value;
    std::cout << "The entered value is " << value << '.' << std::endl;
    sortedAdd(sortedList, sortedList.first, value);
}

void deleteValue(List & sortedList)
{
    std::cout << "Choose some value for deletion." << std::endl;
    int value = 0;
    std::cin >> value;
    std::cout << "You\'ve chosen to delete " << value << '.' << std::endl;
    if (!search(sortedList, sortedList.first, value))
    {  
        deleteElement(sortedList, sortedList.first, value);
        std::cout << "Successful deletion." << std::endl;
    }
    else
    {
        std::cout << "I'm sorry, Pal. I'm afraid I can't do that." << std::endl;
    }
}

void seeOut(List sortedList)
{
    std::cout << "Current list consists of:";
    if (seeAllList(sortedList, sortedList.first))
    {
        std::cout << " nothing";
    }
    std::cout << '.' << std::endl;
}

int dialogue()
{
    List sortedList;
    constrList(sortedList);
    int command = 0;
    greeting();
    enterCommand(command);
    while (command)
    {
        // std::cout << command << ' ';
        switch (command)
        {
            case 1:
            {
                addValue(sortedList);
                break;
            }
            case 2:
            {
                deleteValue(sortedList);
                // std::cout << '!' << std::endl;
                break;
            }
            case 3:
            {
                seeOut(sortedList);
                break;
            }
        }
        enterCommand(command);
    }
    std::cout << "Farewell!" << std::endl;
    return 0;
}