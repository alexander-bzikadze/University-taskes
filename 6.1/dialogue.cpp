#include "dialogue.h"

#include <iostream>

short const maxSize = 100;

void greeting()
{
    std::cout << "Use one of the following commands:\n0 - exit;\n1 - enter new contact;\n2 - find name by phone number;\n3 - find phone number by name;\n4 - save current contacts." << std::endl;
}

void enterCommand(int & command)
{
    std::cout << "Enter a command." << std::endl;
    std::cin >> command;
}

void addContact(Contact * base, int & dataSize)
{
    std::cout << "Enter new name and phone number for a contact.\n";
    inputContact(base, dataSize);
    std::cout << "The entered contact is " << base[dataSize - 1].name << " - " << base[dataSize - 1].phoneNumber << ".\n";
}

void searchPhone(Contact * base, int & dataSize)
{
    std::cout << "Enter a phone to search.\n";
    std::string phone = "";
    std::cin >> phone;
    std::string name = searchByPhone(base, dataSize, phone);
    if (name != "")
    {
        std::cout << name << " owns " << phone << ".\n";
    }
    else
    {
        std::cout << "No math found!";
    }
}

void searchName(Contact * base, int & dataSize)
{
    std::cout << "Enter a name to search.\n";
    std::string name = "";
    std::cin >> name;
    std::string phone = searchByName(base, dataSize, name);
    if (phone != "")
    {
        std::cout << phone << " is owned by " << name << ".\n";
    }
    else
    {
        std::cout << "No math found!";
    }
}

void save(Contact * base, int & dataSize)
{
    std::cout << "Saving contacts.\n";
    saveDataBase(base, dataSize);
    std::cout << "Saving complete!\n";
}

void seeOut(Contact * base, int & dataSize)
{
    std::cout << "Current contacts are: \n";
    printDataBase(base, dataSize);
}

void dialogue()
{
    greeting();
    Contact base[maxSize];
    int dataSize = createDataBase(base);
    int command = 0;
    enterCommand(command);
    while (command)
    {
        switch (command)
        {
            case 1:
            {
                addContact(base, dataSize);
                break;
            }
            case 2:
            {
                searchPhone(base, dataSize);
                break;
            }
            case 3:
            {
                searchName(base, dataSize);
                break;
            }
            case 4:
            {
                save(base, dataSize);
                break;
            }
            case 5:
            {
                seeOut(base, dataSize);
                break;
            }
            case 405:
            {
                std::cout << "May the Fifth be with you!\n";
                break;
            }
        }
        enterCommand(command);
    }
}