#include <iostream>
using namespace std;

int fibonacciRecursive(int ind)
{
	if (ind < 3)
	{
		return 1;
	}
	return fibonacciRecursive(ind-1) + fibonacciRecursive(ind-2);
}

int fibonacciCyclical(int ind)
{
	int currentFibonacciNumber = 1;
	int previousFibonacciNumber = 1;
	int prePreviousFibonacciNumber = 0;
	for (int i = 2; i < ind; ++i)
	{
		prePreviousFibonacciNumber = previousFibonacciNumber;
		previousFibonacciNumber = currentFibonacciNumber;
		currentFibonacciNumber += prePreviousFibonacciNumber;
	}
	return currentFibonacciNumber;
}

const int matrixSize = 2;

void exp(long long a[][matrixSize], long long b[][matrixSize], long long mod)
{
	long long c[matrixSize][matrixSize];
	c[0][1] = (a[0][1] * b[1][1] + a[0][0] * b[0][1]) % mod;
	c[0][0] = (a[0][0] * b[0][0] + a[1][0] * b[1][0]) % mod;
	c[1][1] = (a[1][0] * b[0][1] + a[1][1] * b[1][1]) % mod;
	c[1][0] = c[0][1];
	for(int i = 0; i < matrixSize; ++i)
		for(int j = 0; j < matrixSize; ++j)
			a[i][j] = c[i][j];
}

int fibonacciMatrix(long long index, long long mod)
{
	long long currentMatrix[matrixSize][matrixSize] = {{1,1}, {1,0}};
	long long auxiliaryMatrix[matrixSize][matrixSize] = {{1,1}, {1,0}};
	int k = 0;
	for (long long i = index; i > 0; i >>= 1)
	{
		if (i & 1)
		{
			exp(currentMatrix, auxiliaryMatrix, mod);
		}
		// cout << currentMatrix[0][0] << currentMatrix[0][1] << currentMatix[1][0] << currentMatrix[1][1] << ' ';
		exp(auxiliaryMatrix, auxiliaryMatrix, mod);
	}
	return currentMatrix[0][0];
}

int main()
{
	long long index = 0, mod = 0;
	cout << "Type 0 for recursion, 1 for iteration, 2 for matrix use.\n";
	char choice = '0';
	cin >> choice;
	cout << "Type the needed number.\n";
	cin >> index;
	if (choice == '0')
	{	
		cout << fibonacciRecursive(index);
	}
	else if (choice == '1')
	{
		cout << fibonacciCyclical(index);
	}
	else
	{
		cout << "Type a number for mod operation.\n";
		cin >> mod;
		cout << fibonacciMatrix(index - 2, mod);
	}
}