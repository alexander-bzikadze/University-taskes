#pragma once

#include <iostream>

#include "array.h"

void greeting();

void enterCommand(int & command);

void addContact(Contact * base, int & dataSize);

void searchPhone(Contact * base, int & dataSize);

void searchName(Contact * base, int & dataSize);

void save(Contact * base, int & dataSize);

void seeOut(Contact * base, int & dataSize);

void dialogue();