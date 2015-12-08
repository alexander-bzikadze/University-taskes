#include <iostream>
#include <cstdlib>
#include <ctime>
#include <algorithm>

/*
For n = 5000 and k = 300000 found 4 of kes in the array[n]
For n = 5001 and k = 300000 found a critical error
*/

using namespace std;

int const maxSize = 5000;

int const maxElement = 1000000000;

void seeOut (int * array, int size)
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
}

bool binarySearch(int * array, int size, int requiredElement)
{
	if (size == 0)
	{
		return false;
	}
	int middleElement = size / 2;
	if (array[middleElement] == requiredElement)
	{
		// cout << " - true"; //use this to see true elements among all
		return true;
	}
	if (array[middleElement] > requiredElement)
	{
		return binarySearch(array, middleElement, requiredElement);
	}
	return binarySearch(array + middleElement + 1, size - middleElement - 1, requiredElement);
}

int main()
{
	int array[maxSize] = {};
	int size = 0;
	srand(time(0));
	int k = 0;
	cout << "Please, type in n < 5e3 and k < 3e5\n";
	cin >> size >> k;
	if (size > 5e3 || k > 3e5)
	{
		cout << "Critical error!!! Shutting down...";
		return 1;
	}
	generateArray(array, maxElement, size);
	sort(array, array + size);
	// seeOut(array, size); //use this to see the array through
	int randomNumber = 0;
	int numberOfKinArray = 0;
	for (int i = 0; i < k; ++i)
	{
		randomNumber = rand() % maxElement;
		// cout << i << ' ';
		// cout << randomNumber << ' '; //use this to see all the elements
		if (binarySearch(array, size, randomNumber))
		{
			// cout << i << ' ' << randomNumber << " true\n"; //use this to see only the number and the element that is true
			++numberOfKinArray;
		}
		// cout << endl;
	}
	cout << "Found " << numberOfKinArray << " of k in the array";
	return 0;
}