#pragma once

#include <string>

short const maxNameSize = 20;

struct Contact
{
    std::string name;
    std::string phoneNumber;
};

int createDataBase(Contact * base);

void inputContact(Contact * base, int &dataSize);

void printContact(Contact const &contact);

void printDataBase(Contact * base, int const &dataSize);

void saveDataBase(Contact * base, int const &dataSize);

std::string searchByPhone(Contact * base, int const &dataSize, std::string const &searchedPhone);

std::string searchByName(Contact * base, int const &dataSize, std::string const &searchedName);