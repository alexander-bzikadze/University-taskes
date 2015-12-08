#include <iostream>
using namespace std;

int fib1(int ind)
{
	if (ind < 3)
	{
		return 1;
	}
	return fib1(ind-1) + fib1(ind-2);
}

int fib2(int ind)
{
	int a = 1, b = 1, c = 0;
	for (int i = 2; i < ind; ++i)
	{
		c = b;
		b = a;
		a += c;
	}
	return a;
}

const int H = 2;

void exp(int a[][H], int b[][H])
{
	a[0][1] = a[0][1] * b[1][1] + a[0][0] * b[0][1];
	a[0][0] = a[0][0] * b[0][0] + a[1][0] * b[1][0];
	a[1][1] = a[1][0] * b[0][1] + a[1][1] * b[1][1];
	a[1][0] = a[0][1];
}

int fib3(int index)
{
	int a[H][H] = {{1,1} , {1,0}}, b[H][H] = {};
	for (int i = 0; i < H; ++i)
		for (int j = 0; j < H; ++j)
			b[i][j] = a[i][j];
	for (int i = index; i > 0; i >>= 1)
	{
		if (i & 1)
		{
			exp(a, b);
		}
		exp(b, b);
	}
	return a[0][0];
}

int main()
{
	int index = 0;
	cin >> index;
	cout << fib1(index) << '\n';
	cout << fib2(index) << '\n';
	cout << fib3(index - 2);
}