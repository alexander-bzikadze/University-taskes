#include <iostream>
using namespace std;

const int N = 1e3, K = 1e3; // N - max number of elements; K - their max range.

void bubble(int * array, int size, bool isSortedIncreasing)
{
	for (int i = 0; i < size; ++i)
		for (int j = size - 1; j > i; j--)
		{
			if ((array[j] > array[j-1]) ^ isSortedIncreasing)
			{
				swap(array[j], array[j-1]);
			}
		}
}

void count(int * array, int size, bool isSortedIncreasing)
{
	int extArray[K] = {};
	for (int i = 0; i < size; ++i)
	{
		++extArray[array[i]];
	}
	int index = 0;
	if (!isSortedIncreasing)
	{
		index = size - 1;
	}
	for (int i = 0; i < K; ++i) 
	{
		for (int j = 0; j < extArray[i]; ++j)
		{
			array[index] = i;
			if (isSortedIncreasing)
			{
				++index;
			}
			else
			{
				--index;
			}

		}
	}
}

int generateAnArray (int * array, bool isUserEntrance)
{
	int size = 0;
	cout << "Enter the size.\n";
	cin >> size;
	if (isUserEntrance)
	{
		cout << "Please, begin entering the array.\n";
		for (int i = 0; i < size; ++i)
		{
			cin >> array[i];
		}
	}
	else
	{
		for (int i = 0; i < size; ++i)
		{
			array[i] = i;
		}
	}
	return size;
}

void seeOut(int * array, int size)
{
	for (int i = 0; i < size; ++i)
	{
		cout << array[i] << ' ';
	}
	cout << '\n';
}

bool transformBooleanInput()
{
	bool variable = false;
	cin >> variable;
	if (variable == 1)
	{
		return true;
	}
	return false;
}

int main()
{
	cout << "Please, use 1 for true-value and 0 for false-value.\n";
	cout << "Do you want to form an array yourself?\n";
	bool isUserEntrance = false;
	bool isSortedIncreasing = false;
	bool sortWay = false;
	int size = 0;
	isUserEntrance = transformBooleanInput();
	int array[N] = {};
	size = generateAnArray(array, isUserEntrance);
	cout << "Sort increasing?\n";
	isSortedIncreasing = transformBooleanInput();
	cout << "Type 0 for count-sort, 1 for bubble-sort\n";
	sortWay = transformBooleanInput();
	if (sortWay)
	{
		count(array, size, isSortedIncreasing);
	}
	else
	{
		bubble(array, size, isSortedIncreasing);
	}
	seeOut(array, size);
	return 0; 
}