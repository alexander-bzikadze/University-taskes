#include "array.h"

#include <iostream>
#include <string>
#include <fstream>

int createDataBase(Contact * base)
{
    std::ifstream file("main.in");
    if (!file)
    {
        return 0;
    }
    int size = 0;
    while (!file.eof())
    {
        file >> base[size].name;
        file >> base[size].phoneNumber;
        ++size;
    }
    file.close();
    return size;
}

void inputContact(Contact * base, int & dataSize)
{
    std::cin >> base[dataSize].name>> base[dataSize].phoneNumber;
    ++dataSize;
}

void printContact(Contact const &contact)
{
    std::cout << contact.name << ' ' << contact.phoneNumber <<std::endl;
}

void printDataBase(Contact * base, int const & dataSize)
{
    for (int i = 0; i < dataSize; ++i)
    {
        std::cout << i + 1 << ')';
        printContact(base[i]);
    }
}

void saveDataBase(Contact * base, int const & dataSize)
{
    std::ofstream file("main.in");
    for (int i = 0; i < dataSize; ++i)
    {
        file << base[i].name << " " << base[i].phoneNumber << '\n';
    }
}

std::string searchByPhone(Contact * base, int const & dataSize, std::string const &searchedPhone)
{
    for (int i = 0; i < dataSize; ++i)
    {
        if (base[i].phoneNumber == searchedPhone)
        {
            return base[i].name;
        }
    }
    return "";
}

std::string searchByName(Contact * base, int const & dataSize, std::string const &searchedName)
{
    for (int i = 0; i < dataSize; ++i)
    {
        if (base[i].name == searchedName)
        {
            return base[i].phoneNumber;
        }
    }
    return "";
}
