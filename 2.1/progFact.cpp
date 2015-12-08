#include <iostream>
using namespace std;

double fact1(int inp)
{
	if (inp < 2)
	{
		return 1;
	}
	return inp * fact1(inp-1);
}

double fact2(int inp)
{
	double result = 1;
	for (int i = 1; i <= inp; ++i)
	{
		result *= i;
	}
	return result;
}

int main()
{
	int inp = 0;
	cin >> inp;
	cout << fact1(inp) << '\n';
	cout << fact2(inp);
}