#include <iostream>
#include <cstdlib>
#include <ctime>
#include <algorithm> 
using namespace std;

int const N = 1e1;

void generateArray(int* array, int max)
{
	for (int i = 0; i < N; ++i)
	{
		array[i] = rand() % max;
	}
	return;
}

void sort(int * array, int keyElement)
{
	int i = 0, j = N - 1;
	while (i < j)
	{
		if (array[i] > keyElement)
		{
			while (j > i)
			{
				if (array[j] <= keyElement)
				{
					array[j] ^= array[i] ^= array[j] ^= array[i];
					break;
				}
				--j;
			}
		}
		++i;
	}
}

void seeOut(int * array)
{
	for (int i = 0; i < N; ++i)
	{
		cout << array[i] << ' ';
	}
	cout << '\n';
}

int main()
{
	srand(time(0));
	int max, keyElement;
	cout << "Set the max value.\n";
	cin >> max;
	int array[N] = {};
	generateArray(array, max);
	seeOut(array);
	cout << "Set the value for the Key Element.\n";
	cin >> keyElement;
	sort(array, keyElement);
	seeOut(array);
}
