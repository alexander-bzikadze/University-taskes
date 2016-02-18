#include "dialogue.h"

Dialogue::Dialogue()
    : value(0), command(0), tree()
{
}

Dialogue::~Dialogue()
{
    // tree.~Tree();
}

bool Dialogue::mainProcess()
{
    greating();
    while (command)
    {
        switch (command)
        {
            case 1:
            {
                addValue();
                break;
            }
            case 2:
            {
                deleteValue();
                break;
            }
            case 3:
            {
                checkValue();
                break;
            }
            case 4:
            {
                seeOut();
                break;
            }
            default:
            {
                std::cout << "Error happened!";
                return true;
            }
        }
        commanding();
    }
    farewelling();
    return false;
}

void Dialogue::greating()
{
    std::cout << "Greatings, my friend! Use the following commands:\n0 - to quit.\n1 - to add some value.\n2 - to delete some value\n3 - to check the existense of some value.\n4 - to see all the values." << std::endl;
    commanding();
}

void Dialogue::commanding()
{
    std::cout << std::endl << "Enter a command." << std::endl;
    std::cin >> command;
    if (command != 0 && command!= 4)
    {
        std::cout << "Enter the value." << std::endl;
        std::cin >> value;
        std::cout << "The entered value is " << value << '.' << std::endl;
    }
}

void Dialogue::addValue()
{
    tree.add(value);
    std::cout << value << " successfully added." << std::endl;
}

void Dialogue::deleteValue()
{
    if (tree.check(value))
    {
        tree.deleteValue(value);
        std::cout << value << " successfully deleted." << std::endl;
    }
    else
    {
        std::cout << "No element to delete." << std::endl;
    }
}

void Dialogue::checkValue()
{
    std::cout << "Checking " << value << " for existense, please, stand by." << std::endl;
    std::cout << value;
    if (!tree.check(value))
    {
        std::cout << " not";
    }
    std::cout << " found in the tree." << std::endl;
}

void Dialogue::seeOut()
{
    std::cout << "Current tree consists of:";
    tree.show();
    std::cout << '.' << std::endl;
}

void Dialogue::farewelling()
{
    std::cout << "Farewell, friend" << std::endl;
}
