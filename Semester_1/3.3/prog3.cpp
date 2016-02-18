#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

/* Tested on array = {3 7 3 1 6 6 1 9 1 3 } => 1
But it will show the least of them
Also tested with size = 100 and range = 100: {35 6 60 46 25 92 98 82 25 70 3 26 87 99 93 43 80 58 49 12 64 88 27 29 35 84 99 15 22 16 45 58 22 58 56 0 50 54 82 27 24 38 6 64 89 51 7 21 9 56 34 25 97 61 54 32 97 6 47 20 74 45 30 48 55 86 48 5 93 31 84 17 21 42 81 10 94 40 32 55 49 66 81 46 79 87 30 28 93 77 48 19 74 78 68 29 17 16 86 10 } => 6
Tested with size = 1001 - critical error found
It should work O(n + k), where n is size and k is range
*/

const int ultimateRange = 1e3;
const int maxSize = 1e3;

void seeOut(int * array, int size)
{
	for ( int i = 0; i < size; ++i)
	{
		cout << array[i] << ' ';
	}
	cout << '\n';
}

void generateArray(int * array, int max, int size)
{
	for (int i = 0; i < size; ++i)
	{
		array[i] = rand() % max;
	}
	return;
}

void fillAuliliaryArray(int * array, int * auxiliaryArray, int size)
{
	for (int i = 0; i < size; ++i)
	{
		++auxiliaryArray[array[i]];
	}
}

int findMaxElement(int * array, int size, int maxRange)
{
	int auxiliaryArray[ultimateRange] = {};
	fillAuliliaryArray(array, auxiliaryArray, size);
	int imax = 0;
	for (int i = 1; i < maxRange; ++i)
	{
		if (auxiliaryArray[i] > auxiliaryArray[imax])
		{
			imax = i;
		}
	}
	// seeOut(auxiliaryArray, maxRange);
	return imax;
}

int main()
{
	srand(time(0));
	cout << "Would you kindly, type in the size of an array and its max element value\n";
	cout << "Size and max element value should be less then 1000\n";
	int array[maxSize] = {};
	int max = 0;
	int size = 0;
	cin >> size >> max;
	if (max > 1e3 || size > 1e3)
	{
		cout << "Critical erreor!!! Shuting down...";
		return 1;
	}
	generateArray(array, max, size);
	// seeOut(array, size);
	cout << findMaxElement(array, size, max);
	return 0;
}