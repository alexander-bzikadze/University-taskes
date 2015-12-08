#pragma once

#include <algorithm>
#include <utility>
#include <iostream>
#include <fstream>
#include <string>

short const maxNameSize = 20;

struct Contact
{
    std::string name;
    std::string phoneNumber;
};

int createDataBase(Contact * base);

void inputContact(Contact * base, int & dataSize);

void printContact(Contact contact);

void printDataBase(Contact * base, int & dataSize);

void saveDataBase(Contact * base, int & dataSize);

std::string searchByPhone(Contact * base, int & dataSize, std::string searchedPhone);

std::string searchByName(Contact * base, int & dataSize, std::string searchedName);